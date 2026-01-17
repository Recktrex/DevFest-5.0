using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f; // Lower = smoother/slower lag
    public Vector3 offset; // Set X, Y, Z offset in Inspector

    // LateUpdate runs after the Player has finished moving in Update/FixedUpdate
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        
        // Lerp (Linear Interpolation) creates the smooth drift effect
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        transform.position = smoothedPosition;
    }
}