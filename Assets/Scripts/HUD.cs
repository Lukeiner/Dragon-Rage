using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public static HUD instance;

    public GameObject panelGameOver;
    public GameObject pausePanel;
    public TextMeshProUGUI enemiesDestroyed;

    private bool onPause = false;
    public bool gameFinished = false;

    public GameObject[] lifes;
    
    void Start()
    {
        for (int i = 0; i < lifes.Length; i++)
        {
            lifes[i].SetActive(true);
        }

        enemiesDestroyed.SetText("Enemigos derrotados: ");
        
    }

    public void RestartLevel()
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

    public void Pausar()
    {
        onPause = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void Continuar()
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

    public void LifeOff (int i)
    {
        lifes[i].SetActive(false);
    }

    public void LifeOn(int i)
    {
        lifes[i].SetActive(true);
    }

    public void updateEnemiesCount (int e)
    {
        enemiesDestroyed.SetText("Enemigos derrotados: " + e);
    }
}
