using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    // trigger when something lands on the platform
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object colliding is the Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Make the player a child of the platform
            collision.transform.SetParent(transform);
        }
    }

    // trigger when the player jumps off or walks off
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Remove the parent so the player moves independently again
            collision.transform.SetParent(null);
        }
    }
}