using Spine.Unity;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    private Vector2 moveInput;
    public SkeletonAnimation skeleton;
    public NPCInteractable currentNPC;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // move the player
        Vector3 dir = new Vector3(moveInput.x, 0, moveInput.y);
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);

        // handle animation
        if (moveInput.x > 0.01f)
            skeleton.Skeleton.ScaleX = 1f;
        else if (moveInput.x < -0.01f)
            skeleton.Skeleton.ScaleX = -1f;
    }

    // PlayerInput calls this automatically
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log("move pressed!");
    }

    // PlayerInput calls this automatically
    public void OnInteract(InputValue value)
    {
        Debug.Log("Interact pressed!");
        if (currentNPC != null)
        {
            currentNPC.Interact();
        }
    }
}
