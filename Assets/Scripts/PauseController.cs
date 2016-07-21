using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseController : MonoBehaviour {
	private bool isPaused = false;
	public Canvas pausedModal;
	public AudioSource music;

	void Start() {
		GameObject temp = GameObject.FindGameObjectWithTag ("MenuMusic");
		if (temp != null) {
			temp.GetComponentsInChildren<AudioSource> () [0].mute = true;
		}

		//Disable the paused modal.
		pausedModal.enabled = false;
	}

	void Update() {
		keyHandler ();
	}

	// Private
	// Handles input from the keyboard.
	// ESC to pause.
	void keyHandler() {
		//(Un)Pause the game if the player is not dead.
		if (Input.GetKeyDown (KeyCode.Escape)) {
			togglePaused();
		} 
	}

	// Public
	// Returns true if the level is paused.
	public bool isLevelPaused () {
		return isPaused;
	}
	
	// Public
	// Pauses and unpauses the game.
	public void togglePaused () {
		//Toggle the paused state.
		isPaused = !isPaused;

		//Toggle the paused modal window.
		pausedModal.enabled = isPaused;
		
		//Toggle the music.
		if (isPaused) {
			music.Pause ();
		} else {
			music.Play ();
		}
	}

	public void quitGame() {
		GameObject temp = GameObject.FindGameObjectWithTag ("MenuMusic");
		if (temp != null) {
			temp.GetComponentsInChildren<AudioSource> () [0].mute = false;
		}
		int deaths = PlayerPrefs.GetInt("numDth", 0);  
		PlayerPrefs.SetInt ("numDth", ++deaths);
		PlayerPrefs.Save ();
		Application.LoadLevel(7);
	}
}
