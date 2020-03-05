using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    GameObject pauseMenuUI;
    public float x = 0f;

    public void pauseGame()
    {
        x = Time.fixedDeltaTime;
        pauseMenuUI = GameObject.Find("Canvas");
        pauseMenuUI.transform.Find("Pause").gameObject.SetActive(true);
        Time.timeScale = 0.02f;
        Time.fixedDeltaTime *= 0.02f;
    }

    public void resumeGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime /= 0.02f;
        pauseMenuUI = GameObject.Find("Canvas");
        pauseMenuUI.transform.Find("Pause").gameObject.SetActive(false);
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
