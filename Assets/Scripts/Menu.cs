using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public Text highScore;
    float highScoreint;
    public void Start()
    {
        highScoreint = PlayerPrefs.GetFloat("HighScore");
        highScore.text = highScoreint.ToString("0");
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void openCredits()
    {
        SceneManager.LoadScene(2);
    }
    public void openMenu()
    {
        SceneManager.LoadScene(0);
    }
}
