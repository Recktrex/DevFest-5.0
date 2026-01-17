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

    private Rigidbody2D rb;
    private bool isGrounded;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // -------- INPUT --------
        float targetInput = 0f;

        if (Input.GetKey(KeyCode.A))
            targetInput = -1f;
        else if (Input.GetKey(KeyCode.D))
            targetInput = 1f;

        // -------- GROUND CHECK --------
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        // -------- SMOOTH MOVEMENT --------
        float targetSpeed = targetInput * moveSpeed;

        if (Mathf.Abs(targetInput) > 0.01f)
        {
            // Accelerate
            currentSpeed = Mathf.Lerp(
                currentSpeed,
                targetSpeed,
                acceleration * Time.deltaTime
            );
        }
        else
        {
            // Decelerate
            currentSpeed = Mathf.Lerp(
                currentSpeed,
                0f,
                deceleration * Time.deltaTime
            );
        }

        rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);

        // -------- JUMP --------
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}




