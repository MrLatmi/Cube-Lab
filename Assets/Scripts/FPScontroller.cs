using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScontroller : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody = default;
    [SerializeField] private Transform playerCamera = default;
    [SerializeField] private float cameraZoomFOV = 30f;
    [SerializeField] private float normalFOV = 60f;

    private bool isSprinting = false;
    private bool isZoomed = false;
    private float currentFOV = 0f;
    private float verticalLookRotation = 0f;
    private CharacterController controller = default;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentFOV = normalFOV;
    }

    void Update()
    {
        // Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        float speed = isSprinting ? sprintSpeed : moveSpeed;

        controller.Move(move * speed * Time.deltaTime);

        // Jumping
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpForce);
            controller.Move(Vector3.up * jumpVelocity * Time.deltaTime);
        }

        // Sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }

        // Camera movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        playerCamera.localEulerAngles = Vector3.right * verticalLookRotation;
        playerBody.Rotate(Vector3.up * mouseX);

        // Camera zoom
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isZoomed)
            {
                currentFOV = cameraZoomFOV;
                isZoomed = true;
            }
            else
            {
                currentFOV = normalFOV;
                isZoomed = false;
            }
        }

        // Apply camera zoom
        Camera.main.fieldOfView = currentFOV;
    }
}
