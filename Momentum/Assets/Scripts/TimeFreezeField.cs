using UnityEngine;
using System.Collections.Generic;

public class TimeFreezeField : MonoBehaviour
{
    CircleCollider2D fieldCollider;
    bool timeFrozen;

    HashSet<TimeFreezable> frozenObjects = new HashSet<TimeFreezable>();

    void Awake()
    {
        fieldCollider = GetComponent<CircleCollider2D>();
        fieldCollider.isTrigger = true;
    }

    public void ActivateFreeze()
    {
        timeFrozen = true;

        Collider2D[] hits = Physics2D.OverlapCircleAll(
            transform.position,
            fieldCollider.radius
        );

        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out TimeFreezable tf))
            {
                tf.Freeze();
                frozenObjects.Add(tf);
            }
        }
    }

    public void DeactivateFreeze()
    {
        timeFrozen = false;

        foreach (TimeFreezable tf in frozenObjects)
        {
            tf.Unfreeze();
        }

        frozenObjects.Clear();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!timeFrozen) return;

        if (other.TryGetComponent(out TimeFreezable tf))
        {
            tf.Freeze();
            frozenObjects.Add(tf);
        }
    }

    // 🚫 DO NOTHING ON EXIT WHILE TIME IS FROZEN
    void OnTriggerExit2D(Collider2D other)
    {
        // intentionally empty
    }
}


