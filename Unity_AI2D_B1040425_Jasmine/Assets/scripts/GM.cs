using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene("scene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}