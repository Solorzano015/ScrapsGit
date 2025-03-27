using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextScene()
    {
        int currenteSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currenteSceneIndex + 1);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("Menu");

    }

}
