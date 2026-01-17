using UnityEngine;

public class SliderMovement : MonoBehaviour
{
    public float speed = 3f;
    public float startX = 7f;
    public float endX = 45f;

    Rigidbody2D rb;
    int direction = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void FixedUpdate()
    {
        if (rb.position.x >= endX)
            direction = -1;
        else if (rb.position.x <= startX)
            direction = 1;

        rb.velocity = new Vector2(direction * speed, 0f);
    }
}
