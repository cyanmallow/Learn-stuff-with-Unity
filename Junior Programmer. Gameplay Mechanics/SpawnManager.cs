using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    float spawnRangeZ = 10.0f;

    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<enemy>(FindObjectsSortMode.None).Length;


        if (enemyCount == 0)
        {
            waveNumber++;

            SpawnEnemyWave(waveNumber*2);
            SpawnPowerup();
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, new Vector3(0, 0, Random.Range(-spawnRangeZ, spawnRangeZ)), enemyPrefab.transform.rotation);
        }
       
    }

    private void SpawnPowerup()
    {
        Instantiate(powerupPrefab, new Vector3(0, 0, Random.Range(-spawnRangeZ, spawnRangeZ)), enemyPrefab.transform.rotation);
       
    }
}
