using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody enemyRb;
    GameObject player;
    public float speed = 5.0f;
    Vector3 lookDirection;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);


        if (transform.position.y < -10)
        {
            Debug.Log("Game Over for the ball that just fell!");
            Destroy(gameObject);
        }
    }
}
