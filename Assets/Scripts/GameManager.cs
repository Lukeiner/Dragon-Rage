using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public TextMeshProUGUI textPoints;
    public TextMeshProUGUI lifePoints;

    [Header("Estadística")]
    public int lifes = 3;

    public bool gameFinished = false;
    public HUD hud;
    public int enemiesToWin = 10;
    private int defeatedCount = 0;

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
        Time.timeScale = 0f;
    }

    public void LoseLifes ()
    {
        lifes--;
        hud.LifeOff(lifes);
    }

    public void enemyKilled()
    {
        defeatedCount++;
        if (defeatedCount < enemiesToWin)
        {
            hud.updateEnemiesCount(defeatedCount);
        }
    }

}
