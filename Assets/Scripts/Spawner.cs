using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float SpawnTime = 2f;
    public float rangeX = 8f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, SpawnTime);
        
    }

    void SpawnEnemy()
    {
        if (GameManager.instance.gameFinished)  return;

        float xAleatory = Random.Range(-rangeX, rangeX);
        Vector3 SpawnPos = new Vector3(xAleatory, 6f, 0f);

        Instantiate(enemyPrefab, SpawnPos, Quaternion.identity);

    }

    private void destroy(GameObject gameObject)
    {
        throw new System.NotImplementedException();
    }

    public void StopSpawn ()
    {
        CancelInvoke("SpawnEnemy");

    }
}

