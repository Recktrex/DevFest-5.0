using UnityEngine;

public class SliderMovement : MonoBehaviour
{
    public float speed = 5f;
    private float startX = 7f;
    private float endX = 45f;

    void Update()
    {
        // Calculate the distance (38 units)
        float distance = endX - startX;
        
        // PingPong bounces value between 0 and distance
        float x = startX + Mathf.PingPong(Time.time * speed, distance);

        // Apply new position keeping Y and Z the same
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}