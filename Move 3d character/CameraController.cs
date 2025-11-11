using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float sensitivity = 2f;
    public float minYAngle = -30f;
    public float maxYAngle = 60f;

    private Vector2 lookInput;
    private float rotationX;
    private float rotationY;

    // Add this line 👇
    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = target.GetComponent<PlayerInput>();

        // Subscribe to the "Look" action from the PlayerInput
        playerInput.actions["Look"].performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        playerInput.actions["Look"].canceled += ctx => lookInput = Vector2.zero;
    }

    private void LateUpdate()
    {
        rotationX += lookInput.x * sensitivity;
        rotationY -= lookInput.y * sensitivity;
        rotationY = Mathf.Clamp(rotationY, minYAngle, maxYAngle);

        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);
        transform.position = target.position - rotation * Vector3.forward * distance;
        transform.LookAt(target);
    }
}
