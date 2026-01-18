using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void EndGame()
    {
        SceneManager.LoadScene("gameOver");
    }
}
