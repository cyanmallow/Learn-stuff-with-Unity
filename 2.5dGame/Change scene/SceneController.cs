using System;
using System.Collections;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    public string lastSpawnPoint;

    //make sure player isn't teleported multiple times
    public bool isTeleporting = false;
    public float teleportCooldown = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToScene(string sceneName, string spawnLocation)
    {
        if (isTeleporting) return; // Prevent multiple teleports

        isTeleporting = true;

        lastSpawnPoint = spawnLocation;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

        // Reset teleporting flag after cooldown
        Instance.StartCoroutine(TeleportCooldown());
    }


    private IEnumerator TeleportCooldown()
    {
        yield return new WaitForSeconds(teleportCooldown);
        isTeleporting = false;
    }
}
