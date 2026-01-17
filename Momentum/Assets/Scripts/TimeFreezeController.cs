using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TimeFreezeController : MonoBehaviour
{
    public TimeFreezeField freezeField;
    public float freezeDuration = 2f;

    bool isFrozen;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && !isFrozen)
        {
            StartCoroutine(FreezeRoutine());
        }
    }

    IEnumerator FreezeRoutine()
    {
        isFrozen = true;

        freezeField.ActivateFreeze();

        yield return new WaitForSeconds(freezeDuration);

        freezeField.DeactivateFreeze();

        isFrozen = false;
    }
}


