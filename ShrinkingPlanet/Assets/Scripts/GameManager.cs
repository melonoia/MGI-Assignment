using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject gameOverUI;
	public GameObject controlsPanel;
	
	public static bool isGameOver;

	void Awake ()
	{
		instance = this;
	}

	public void EndGame ()
	{
		isGameOver = true;
		controlsPanel.SetActive(false);
		gameOverUI.SetActive(true);
	}

	public void Restart ()
	{
		isGameOver = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
