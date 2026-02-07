using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Estadística")]
    private int lifes;

    public bool gameFinished = false;
    private bool firstLevelWin = false;
    public HUD hud;
    public int enemiesToWin = 10;
    private int defeatedCount = 0;

    public GameObject eggPreFab;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Time.timeScale = 1f;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (DragonHealth.instance != null)
        {
            lifes = DragonHealth.instance.getActualHealth();
            hud.updateEnemiesCount(0);
        }
        
    }

    public bool firstLevelWon ()
    {
        return firstLevelWin;
    }

    private void setLifes(int l)
    {
        lifes = l;
    }

    public int getLifes()
    {
        return lifes;
    }

    public void EndGame()
    {
        if (gameFinished) return;

        gameFinished = true;
        Debug.Log("Game Over");

        if (hud.panelGameOver != null)
        {
            hud.panelGameOver.SetActive(true);
        }
        Time.timeScale = 0f;
        
    }

    public void LoseLifes ()
    {
        if (firstLevelWin) return;

        if (DragonHealth.instance == null)
        {
            Debug.LogError("¡DragonHealth.instance no existe!");
            return;
        }

        DragonHealth.instance.getDamage(1);
        hud.LifeOff(DragonHealth.instance.getActualHealth());
    }

    public void enemyKilled()
    {
        defeatedCount++;
        if (defeatedCount < enemiesToWin)
        {
            hud.updateEnemiesCount(defeatedCount);
        }
        else
        {
            SecuenciaVictoria();
        }
    }

    void SecuenciaVictoria()
    {
        firstLevelWin = true;
        Object.FindFirstObjectByType<Spawner>().StopSpawn();

        foreach (GameObject enemigo in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemigo);
        }

        foreach (GameObject bala in GameObject.FindGameObjectsWithTag("EnemyBullet"))
        {
            Destroy(bala);
        }

        Object.FindFirstObjectByType<DragonMovement>().startReturn();
    }

    public void appearEgg()
    {
        Instantiate(eggPreFab, Vector3.zero, Quaternion.identity);
        Debug.Log("El huevo ha descendido");
    }

    public void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

}
