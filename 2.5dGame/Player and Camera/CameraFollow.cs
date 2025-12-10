using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float zoomSpeed = 2f;
    public float minFOV = 20f;
    public float maxFOV = 80f;

    private Camera mainCamera;
    private InputAction zoomAction;

    void Awake()
    {
        mainCamera = GetComponent<Camera>();

        zoomAction = new InputAction(type: InputActionType.Value, binding: "<Mouse>/scroll/y");
        zoomAction.Enable();
    }

    void LateUpdate()
    {
        // Follow target
        transform.position = target.position + offset;
        transform.rotation = Quaternion.Euler(40, 0, 0);

        // Zoom (Perspective)
        float scrollInput = zoomAction.ReadValue<float>();
        if (scrollInput != 0f)
        {
            float newFOV = mainCamera.fieldOfView - scrollInput * zoomSpeed;
            mainCamera.fieldOfView = Mathf.Clamp(newFOV, minFOV, maxFOV);
        }
    }
}
