using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    Slider sensitivitySlider;
    GameObject pauseMenuUI;
    static bool gamePaused = false;
    public static bool showingTutorial = false;

    public void pauseGame()
    {
        gamePaused = true;
        slowTime();
        pauseMenuUI = GameObject.Find("Canvas");
        pauseMenuUI.transform.Find("Pause").gameObject.SetActive(true);
        GameObject.Find("PauseButton").gameObject.SetActive(false);
        GameObject.Find("showFPSToggle").GetComponent<Toggle>().isOn = (PlayerPrefs.GetInt("showFPS", 1) == 1);
        sensitivitySlider = GameObject.Find("SensitivitySlider").GetComponent<Slider>();
        sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity", 0.6f);
    }

    public void resumeGame()
    {
        resetPauseStatus();
        resumeTime();
        pauseMenuUI = GameObject.Find("Canvas");
        pauseMenuUI.transform.Find("Pause").gameObject.SetActive(false);
        pauseMenuUI.transform.Find("PauseButton").gameObject.SetActive(true);
    }

    public void restartLevel()
    {
        resetPauseStatus();
        resetTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void openMenu()
    {
        resetPauseStatus();
        resetTime();
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        resetPauseStatus();
        resetTime();
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

    public static void showScoreCard()
    {
        GameObject.Find("Canvas").transform.Find("ScoreCard").gameObject.SetActive(true);
        GameObject.Find("ScoreCard").transform.Find("Score").GetComponent<Text>().text = GameObject.Find("player").transform.position.z.ToString("0");
        GameObject.Find("Canvas").transform.Find("Score").gameObject.SetActive(false);
    }

    public static void showTutorial()
    {
        showingTutorial = true;
        if (gamePaused)
            GameObject.Find("Canvas").transform.Find("Pause").gameObject.SetActive(false);
        else
        {
            slowTime();
            gamePaused = true;
            GameObject.Find("PauseButton").gameObject.SetActive(false);
        }
        GameObject.Find("Canvas").transform.Find("Tutorial").gameObject.SetActive(true);
    }

    public void stopTutorial()
    {
        showingTutorial = false;
        resetPauseStatus();
        GameObject.Find("Canvas").transform.Find("Tutorial").gameObject.SetActive(false);
        resumeTime();
        GameObject.Find("Canvas").transform.Find("PauseButton").gameObject.SetActive(true);
    }

    public static void slowTime()
    {
        Time.timeScale *= 0.01666667f;
        Time.fixedDeltaTime *= 0.01666667f;
    }

    public static void resumeTime()
    {
        Time.timeScale /= 0.01666667f;
        Time.fixedDeltaTime /= 0.01666667f;
    }

    public static void resetTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.01666667f;
    }

}
