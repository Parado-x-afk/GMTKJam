using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonCamera : MonoBehaviour
{
    // Variables
    public Transform player;
    public float mouseSensitivity = 2f;
    public float moveSpeed = 5f;

    private CharacterController controller;
    private float cameraVerticalRotation = 0f;

    void Start()
    {
        // Lock and hide cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Get the CharacterController attached to the player
        controller = player.GetComponent<CharacterController>();
    }

    void Update()
    {
        // --- Camera Rotation ---
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Vertical camera rotation (up/down)
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        // Horizontal player rotation (left/right)
        player.Rotate(Vector3.up * inputX);

        // --- Movement ---
        float moveZ = Input.GetAxis("Vertical"); // W/S or Up/Down arrow
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow

        Vector3 move = player.transform.right * moveX + player.transform.forward * moveZ;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }
}
