using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public Transform target;        // The player (set in the Inspector)
    public float smoothSpeed = 5f;  // How smoothly the camera follows
    public Vector3 offset;          // Offset from the player

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;     // target position with offset

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);// Smoothly move camera to desired position
    }
}
