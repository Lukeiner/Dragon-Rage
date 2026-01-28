using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI References")]
    public TextMeshProUGUI textPoints;
    public TextMeshProUGUI lifePoints;

    [Header("Estadística")]
    public int points = 0;
    public int lifes = 3;

    public bool gameFinished = false;
    public HUD hud;

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

}
