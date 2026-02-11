using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EggGoal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Destroy(gameObject);
            //SceneManager.LoadScene("Level2");
        }
    }
}
