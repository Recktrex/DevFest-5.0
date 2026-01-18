using UnityEngine;
using UnityEngine.SceneManagement;

public class RedDot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Restart level on death
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
