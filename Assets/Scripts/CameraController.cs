using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private InputActionReference lookAction;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private bool lockedCursor = true;

    float verticalRotation = 0f;

    void OnEnable()
    {
        lookAction.action.Enable();
    }

    void OnDisable()
    {
        lookAction.action.Disable();
    }

    void Start()
    {
        // Hide Cursor
        if (lockedCursor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {

        // Get Mouse Input
        Vector2 look = lookAction.action.ReadValue<Vector2>();

        float inputX = look.x * mouseSensitivity;
        float inputY = look.y * mouseSensitivity;

        // Rotate Camera
        verticalRotation -= inputY;
        verticalRotation = Mathf.Clamp(verticalRotation, -50f, 50f);

        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        player.Rotate(Vector3.up * inputX);
    }
}
