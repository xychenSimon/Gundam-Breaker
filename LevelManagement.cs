using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour {
	public void LoadLevel(string name) {
		Debug.Log ("Level load requested for " + name);
		Brick.breakableCount = 0;
		SceneManager.LoadScene(name);
	}

	public void ReloadLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex); //new load level
	}

	public void QuitRequest() {
		Debug.Log("I wanna quit!"); 
		Application.Quit ();
	}

	public void LoadNextLevel () {
		Brick.breakableCount = 0;
		print (SceneManager.GetActiveScene ().buildIndex);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel ();
		}
	}
		
}


