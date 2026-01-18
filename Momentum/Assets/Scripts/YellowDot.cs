using UnityEngine;
using UnityEngine.SceneManagement;

public class YellowDot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("YOU WIN!");
            // You can load next level here later
            if (SceneManager.GetActiveScene().name == "level 2")
            {
                FindObjectOfType<gameManager>().EndGame();
            }
        }
    }
}
