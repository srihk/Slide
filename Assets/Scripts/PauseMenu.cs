using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    GameObject pauseMenuUI;

    public void pauseGame()
    {
        Time.timeScale = 0.02f;
        Time.fixedDeltaTime *= 0.02f;
        pauseMenuUI = GameObject.Find("Canvas");
        pauseMenuUI.transform.Find("Pause").gameObject.SetActive(true);
        GameObject.Find("PauseButton").gameObject.SetActive(false);
    }

    public void resumeGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime /= 0.02f;
        pauseMenuUI = GameObject.Find("Canvas");
        pauseMenuUI.transform.Find("Pause").gameObject.SetActive(false);
        pauseMenuUI.transform.Find("PauseButton").gameObject.SetActive(true);
    }

    public void openMenu()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime /= 0.02f;
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime /= 0.02f;
        Application.Quit();
    }
}
