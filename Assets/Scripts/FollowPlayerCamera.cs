using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = playerTransform.position + offset;
        transform.LookAt(playerTransform);
    }
}
