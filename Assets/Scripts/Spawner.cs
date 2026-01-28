using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPreFab;
    public float SpawnTime = 2f;
    public float rangeX = 8f;
    private float cronometro;

    void Start()
    {
        
    }

    private void Update()
    {
        cronometro += Time.deltaTime;

        if (cronometro >= SpawnTime)
        {
            SpawnEnemy();
            cronometro = 0;
        }
    }

    void SpawnEnemy()
    {
        if ((GameManager.instance.gameFinished) || (enemyPreFab.Length) <= 0)  return;

        int RandomInd = Random.Range(0, enemyPreFab.Length);

        float xAleatory = Random.Range(-rangeX, rangeX);
        Vector3 SpawnPos = new Vector3(xAleatory, 6f, 0f);

        Instantiate(enemyPreFab[RandomInd], SpawnPos, Quaternion.identity);

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

