using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    public GameObject[] SpawnAnimalPrefab;
    Vector3 spawnPosition;
    float spawnPositionMin = -5.0f;
    float spawnPositionMax = 5.0f;
    float randomZPosition;
    float randomXPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("spawnShit", 2.0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            spawnShit();
        }
    }

    private void spawnShit()
    {
        int animalIndex = Random.Range(0, SpawnAnimalPrefab.Length);
        randomZPosition = Random.Range(spawnPositionMin, spawnPositionMax);
        randomXPosition = Random.Range(spawnPositionMin, spawnPositionMax);
        Vector3 spawnPosition = new Vector3(randomXPosition, 0, randomZPosition);
        Instantiate(SpawnAnimalPrefab[animalIndex], spawnPosition, SpawnAnimalPrefab[animalIndex].transform.rotation);
    }
}
