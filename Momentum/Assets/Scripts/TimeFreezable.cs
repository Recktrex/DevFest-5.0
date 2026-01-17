using UnityEngine;

using UnityEngine;

public class TimeFreezable : MonoBehaviour
{
    Rigidbody2D rb;
    bool frozen;

    Vector2 savedVelocity;
    float savedAngularVelocity;
    float savedGravity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.LogError($"{name} has no Rigidbody2D!");
    }

    public void Freeze()
    {
        if (frozen || rb == null) return;

        frozen = true;

        savedVelocity = rb.linearVelocity;
        savedAngularVelocity = rb.angularVelocity;
        savedGravity = rb.gravityScale;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = 0f;
        rb.simulated = false;   // 🔑 THIS STOPS FALLING

        Debug.Log("FREEZE " + name);

    }

    public void Unfreeze()
    {
        if (!frozen || rb == null) return;

        frozen = false;

        rb.simulated = true;
        rb.gravityScale = savedGravity;
        rb.linearVelocity = savedVelocity;
        rb.angularVelocity = savedAngularVelocity;
    }
}

