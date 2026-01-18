using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
