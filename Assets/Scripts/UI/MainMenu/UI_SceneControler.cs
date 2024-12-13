using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_SceneControler : MonoBehaviour
{
    public void LoadScene(string sceneName)                 //load given scene
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()                              //quit game
    {
        Application.Quit();
    }
}
