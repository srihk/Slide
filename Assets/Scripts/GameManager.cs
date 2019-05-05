using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	bool gameHasEnded = false;
	float highscore;
	public float restartDelay = 2f;

	public GameObject completeLevelUI;
	public GameObject player;
    public void CompletedLevel()
	{
		completeLevelUI.SetActive(true);
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
			Invoke("Restart", restartDelay);
		}
	
	}
    public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
