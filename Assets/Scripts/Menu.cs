using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour {
	public GameObject completeLevelUI;
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
    public void startinfinite()
	{
		SceneManager.LoadScene(5);
	}
}
