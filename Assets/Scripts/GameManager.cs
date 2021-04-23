using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public bool showFps = false;
    float highscore;
    float restartDelay = 0.06f;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("player");
        Application.targetFrameRate = 60;
        if (PlayerPrefs.GetInt("FirstPlay", 1) == 1)
        {
            PlayerPrefs.SetInt("FirstPlay", 0);
            showTutorial();
        }
        GameObject.Find("Canvas").transform.Find("FPSCounter").gameObject.SetActive((PlayerPrefs.GetInt("showFPS", 1) == 1));
    }

    public void showTutorial()
    {
        PauseMenu.showTutorial();
    }

    public void showFPS()
    {
        showFps = GameObject.Find("showFPSToggle").GetComponent<Toggle>().isOn;
        PlayerPrefs.SetInt("showFPS", (showFps ? 1 : 0));
        GameObject.Find("Canvas").transform.Find("FPSCounter").gameObject.SetActive(showFps);
    }

    public void EndGame()
    {
        if (PlayerPrefs.GetFloat("HighScore", 0) < player.transform.position.z)
        {
            PlayerPrefs.SetFloat("HighScore", player.transform.position.z);
        }
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Time.timeScale = 0.01666667f;
            Time.fixedDeltaTime = 0.0002777f;
            if (PauseMenu.showingTutorial)
                GameObject.Find("Tutorial").gameObject.SetActive(false);
            else if (PauseMenu.isGamePaused())
                GameObject.Find("Pause").gameObject.SetActive(false);
            else
                GameObject.Find("PauseButton").gameObject.SetActive(false);
            Invoke("showScoreCard", restartDelay);
        }
    }

    public void showScoreCard()
    {
        PauseMenu.showScoreCard();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Welcome");
    }
}
