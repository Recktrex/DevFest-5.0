using UnityEngine;

public class TimeFreezable : MonoBehaviour
{
    protected bool isFrozen;
    protected Rigidbody2D rb;

    RigidbodyConstraints2D originalConstraints;
    float originalGravity;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Freeze()
    {
        isFrozen = true;
        if (rb == null) return;

        originalConstraints = rb.constraints;
        originalGravity = rb.gravityScale;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public virtual void Unfreeze()
    {
        isFrozen = false;
        if (rb == null) return;

        rb.constraints = originalConstraints;
        rb.gravityScale = originalGravity;
    }
}





