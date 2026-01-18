// using UnityEngine;

// public class FallingPlatform : TimeFreezable
// {
//     public float delayBeforeFall = 1f;

//     bool activated;
//     float timer;

//     protected override void Awake()
//     {
//         base.Awake();

//         // Floating block
//         rb.gravityScale = 0f;
//         rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
//     }

//     void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (activated) return;
//         if (!collision.collider.CompareTag("Player")) return;

//         // Only trigger if player lands on TOP face
//         foreach (ContactPoint2D contact in collision.contacts)
//         {
//             if (contact.normal.y > 0.6f)
//             {
//                 activated = true;
//                 timer = delayBeforeFall;
//                 return;
//             }
//         }
//     }

//     void Update()
//     {
//         if (!activated) return;
//         if (isFrozen) return;

//         timer -= Time.deltaTime;

//         if (timer <= 0f)
//         {
//             rb.gravityScale = 1f;   // turn gravity ON → falls
//             enabled = false;
//         }
//     }
// }


using UnityEngine;

public class FallingPlatform : TimeFreezable
{
    public float delayBeforeFall = 1f;

    bool activated;
    float timer;

    protected override void Awake()
    {
        base.Awake();

        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (activated) return;
        if (!collision.collider.CompareTag("Player")) return;

        Rigidbody2D playerRb = collision.collider.attachedRigidbody;

        // Only trigger if player is falling DOWN onto the block
        if (playerRb.linearVelocity.y <= 0f)
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // Player is above the block
                if (contact.point.y > transform.position.y)
                {
                    activated = true;
                    timer = delayBeforeFall;
                    return;
                }
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
            rb.gravityScale = 1f;   // gravity ON
            enabled = false;
        }
    }
}
