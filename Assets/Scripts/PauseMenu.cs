using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    Slider sensitivitySlider;
    GameObject pauseMenuUI; 
    static bool gamePaused = false;

    public void pauseGame()
    {
        gamePaused = true;
        Time.timeScale *= 0.01666667f;
        Time.fixedDeltaTime *= 0.01666667f;
        pauseMenuUI = GameObject.Find("Canvas");
        pauseMenuUI.transform.Find("Pause").gameObject.SetActive(true);
        GameObject.Find("PauseButton").gameObject.SetActive(false);
        sensitivitySlider = GameObject.Find("SensitivitySlider").GetComponent<Slider>();
        sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity", 0.5f);
    }

    public void resumeGame()
    {
        resetPauseStatus();
        Time.timeScale /= 0.01666667f;
        Time.fixedDeltaTime /= 0.01666667f;
        pauseMenuUI = GameObject.Find("Canvas");
        pauseMenuUI.transform.Find("Pause").gameObject.SetActive(false);
        pauseMenuUI.transform.Find("PauseButton").gameObject.SetActive(true);
    }

    public void openMenu()
    {
        resetPauseStatus();
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.01666667f;
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        resetPauseStatus();
        Time.timeScale = 1f;
        Time.fixedDeltaTime /= 0.01666667f;
        Application.Quit();
    }

    public static bool isGamePaused()
    {
        return gamePaused;
    }

    public static void resetPauseStatus()
    {
        gamePaused = false;
    }

    public void onSensitivityChanged()
    {
        PlayerMovement.setSensitivity(sensitivitySlider.value);
        PlayerPrefs.SetFloat("Sensitivity", PlayerMovement.getSensitivity());
    }
}
