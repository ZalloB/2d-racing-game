using UnityEngine;

public class SceneLoadManager : MonoBehaviour
{

    public void LoadScreen(string name)
    {
        Time.timeScale = 1;
        SoundManager.instance.musicSource.UnPause();
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        GameObject.Find("CanvasMenu").SetActive(false);
        SoundManager.instance.musicSource.UnPause();
    }
}
