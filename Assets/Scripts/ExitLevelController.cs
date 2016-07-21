using UnityEngine;
using System.Collections;

public class ExitLevelController : MonoBehaviour {
	public int levelToLoad;

	public void loadThatLevel() {
		GameObject temp = GameObject.FindGameObjectWithTag ("ButtonSound");
		if (temp != null) {
			temp.GetComponentsInChildren<AudioSource> () [0].Play ();
		}
		Application.LoadLevel (levelToLoad);
	}

	public void loadSpecificLevel(int level) {
		GameObject temp = GameObject.FindGameObjectWithTag ("ButtonSound");
		if (temp != null) {
			temp.GetComponentsInChildren<AudioSource> () [0].Play ();
		}
		Application.LoadLevel (level);
	}

	public void quitGame() {
		Application.Quit();
	}
}
