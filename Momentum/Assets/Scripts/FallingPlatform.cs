using UnityEngine;

public class FallingPlatform : TimeFreezable
{
    public float delayBeforeFall = 1f;

    float timer;
    bool activated;

    protected override void Awake()
    {
        base.Awake();

        // Start as a stable platform
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (activated) return;
        if (!collision.collider.CompareTag("Player")) return;

        // Only activate if player lands on TOP
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                activated = true;
                timer = delayBeforeFall;
                return;
            }
        }
    }

    void Update()
    {
        if (!activated) return;
        if (isFrozen) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            StartFalling();
        }
    }

    void StartFalling()
    {
        // Allow falling straight down, no rotation
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 1f;

        enabled = false; // logic no longer needed
    }
}


