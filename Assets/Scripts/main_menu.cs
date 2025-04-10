using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene("Game Progress Demo");
    }

    public void Quit() {
        Application.Quit();
    }
}
