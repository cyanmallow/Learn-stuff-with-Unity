using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float Boundary = -30.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < Boundary)
        {
            Debug.Log("GameOver");
            Destroy(gameObject);
        }
    }
}
