using UnityEngine;

public class playermovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float acceleration = 12f;
    public float deceleration = 16f;
    public float jumpForce = 14f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Jump Assist")]
    public float coyoteTime = 0.15f;

    Rigidbody2D rb;
    Rigidbody2D groundRb;

    float inputX;
    float currentSpeed;
    float coyoteTimer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // INPUT ONLY
        inputX = Input.GetAxisRaw("Horizontal");

        Collider2D groundCol = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        if (groundCol != null)
        {
            coyoteTimer = coyoteTime;
            groundRb = groundCol.attachedRigidbody;
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
            groundRb = null;
        }

        if (Input.GetKeyDown(KeyCode.Space) && coyoteTimer > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            coyoteTimer = 0f;
        }
    }

    void FixedUpdate()
    {
        // Player-controlled movement
        float targetSpeed = inputX * moveSpeed;

        float accel = Mathf.Abs(targetSpeed) > 0.01f
            ? acceleration
            : deceleration;

        currentSpeed = Mathf.MoveTowards(
            currentSpeed,
            targetSpeed,
            accel * Time.fixedDeltaTime
        );

        // Platform carry (THIS is the fix)
        float platformVelocityX = 0f;
        if (groundRb != null && groundRb.bodyType == RigidbodyType2D.Kinematic)
        {
            platformVelocityX = groundRb.linearVelocity.x;
        }

        rb.linearVelocity = new Vector2(
            platformVelocityX + currentSpeed,
            rb.linearVelocity.y
        );
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}



