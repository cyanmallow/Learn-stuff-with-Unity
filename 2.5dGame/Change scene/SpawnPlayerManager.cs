using UnityEngine;

public class SpawnPlayerManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string spawnPoint = SceneController.Instance.lastSpawnPoint;
        if (!string.IsNullOrEmpty(spawnPoint))
        {
            
            Transform spawnLocation = GameObject.Find(spawnPoint).transform;
            
            if (spawnLocation != null ) {
                transform.position = spawnLocation.position;
                transform.rotation = spawnLocation.rotation;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
