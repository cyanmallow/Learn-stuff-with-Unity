using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10.0f;
    public float turnSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }
}
