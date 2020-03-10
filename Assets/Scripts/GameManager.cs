using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	bool gameHasEnded = false;
	float highscore;
	float restartDelay = 0.06f;
	GameObject player;

	void Start()
    {
		player = GameObject.Find("player");
		Application.targetFrameRate = 60;
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
			Invoke("Restart", restartDelay);
		}
	}
    public void Restart()
	{
		PauseMenu.resetPauseStatus();
		Time.timeScale = 1f;
		Time.fixedDeltaTime = 0.01666667f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void Menu()
    {
		SceneManager.LoadScene("Welcome");
	}
}
