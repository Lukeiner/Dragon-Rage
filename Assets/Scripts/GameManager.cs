using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI References")]
    public GameObject panelGameOver;
    public GameObject pausePanel;

    public int points = 0;
    public bool gameFinished = false;
    private bool onPause = false;

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

    public void EndGame ()
    {
        if (gameFinished) return;

        gameFinished = true;
        Debug.Log("Game Over");
        Time.timeScale = 0f;

        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
        }
    }
  
    public void RestartLevel ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (onPause)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar ()
    {
        onPause = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void Continuar ()
    {
        onPause = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);

    }

    public void SalirAlMenu()
    {
        Application.Quit();
        Debug.Log("Salimos");
    }


}
