using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float cameraSpeed = 5f;
    [SerializeField] private float cameraEdgeDistance = 10f;
    [SerializeField] private float cameraScrollSpeed = 500f;
    [SerializeField] private float minCameraHeight = 10f;
    [SerializeField] private float maxCameraHeight = 50f;

    private Vector3 cameraTargetPosition;

    void Start()
    {
        cameraTargetPosition = transform.position;
    }

    void Update()
    {
        // Move camera with arrow keys and mouse
        MoveCamera();

        // Adjust camera height with mouse scroll
        AdjustCameraHeight();
    }

    void MoveCamera()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move camera with arrow keys
        if (horizontalInput != 0f || verticalInput != 0f)
        {
            cameraTargetPosition += new Vector3(horizontalInput, 0f, verticalInput) * cameraSpeed * Time.deltaTime;
        }

        // Move camera with mouse
        if (Input.mousePosition.x <= cameraEdgeDistance || Input.GetKey(KeyCode.LeftArrow))
        {
            cameraTargetPosition -= new Vector3(cameraSpeed * Time.deltaTime, 0f, 0f);
        }
        if (Input.mousePosition.x >= Screen.width - cameraEdgeDistance || Input.GetKey(KeyCode.RightArrow))
        {
            cameraTargetPosition += new Vector3(cameraSpeed * Time.deltaTime, 0f, 0f);
        }
        if (Input.mousePosition.y <= cameraEdgeDistance || Input.GetKey(KeyCode.DownArrow))
        {
            cameraTargetPosition -= new Vector3(0f, 0f, cameraSpeed * Time.deltaTime);
        }
        if (Input.mousePosition.y >= Screen.height - cameraEdgeDistance || Input.GetKey(KeyCode.UpArrow))
        {
            cameraTargetPosition += new Vector3(0f, 0f, cameraSpeed * Time.deltaTime);
        }

        // Move camera towards target position
        transform.position = Vector3.Lerp(transform.position, cameraTargetPosition, Time.deltaTime * 10f);
    }

    void AdjustCameraHeight()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Adjust camera height with mouse scroll
        if (scrollInput != 0f)
        {
            float newHeight = transform.position.y - scrollInput * cameraScrollSpeed * Time.deltaTime;
            cameraTargetPosition.y = Mathf.Clamp(newHeight, minCameraHeight, maxCameraHeight);
        }

        // Adjust camera height with keyboard
        if (Input.GetKey(KeyCode.PageUp))
        {
            float newHeight = transform.position.y + cameraSpeed * Time.deltaTime;
            cameraTargetPosition.y = Mathf.Clamp(newHeight, minCameraHeight, maxCameraHeight);
        }
        if (Input.GetKey(KeyCode.PageDown))
        {
            float newHeight = transform.position.y - cameraSpeed * Time.deltaTime;
            cameraTargetPosition.y = Mathf.Clamp(newHeight, minCameraHeight, maxCameraHeight);
        }

        // Move camera towards target position
        transform.position = Vector3.Lerp(transform.position, cameraTargetPosition, Time.deltaTime * 10f);
    }
}
