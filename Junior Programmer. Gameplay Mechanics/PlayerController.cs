using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform cameraTransform;

    private Rigidbody rb;
    private Vector2 movementInput;

    public bool hasPowerup = false;

    public GameObject powerupIndicator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
    }

    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        // Get camera direction on horizontal plane
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // Translate input to world space relative to camera
        Vector3 move = camForward * movementInput.y + camRight * movementInput.x;

        rb.linearVelocity = move * speed;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);

            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
       {
           Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
           Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            enemyRb.AddForce(awayFromPlayer.normalized * 10f, ForceMode.Impulse);
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
