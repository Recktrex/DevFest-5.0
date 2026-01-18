using UnityEngine;

public class YellowDot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("YOU WIN!");
            // You can load next level here later
        }
    }
}
