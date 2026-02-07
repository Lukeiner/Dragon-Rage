using UnityEngine;
using UnityEngine.SceneManagement;

public class EggGoal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Level2");
        }
    }
}
