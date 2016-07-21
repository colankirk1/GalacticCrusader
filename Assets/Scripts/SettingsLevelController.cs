using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsLevelController : MonoBehaviour {
	public Text statsText;

	private int[] stats = {0,0,0,0,0,0,0,0};
	
	void Start()
	{
		stats[0] = PlayerPrefs.GetInt("numGrn", 0);  
		stats[1] = PlayerPrefs.GetInt("numRed", 0);  
		stats[2] = PlayerPrefs.GetInt("numBlu", 0);  
		stats[3] = PlayerPrefs.GetInt("numPur", 0);  
		stats[4] = PlayerPrefs.GetInt("highscore", 0);  
		stats[5] = PlayerPrefs.GetInt("lvl1HS", 0);  
		stats[6] = PlayerPrefs.GetInt("lvl2HS", 0);  
		stats[7] = PlayerPrefs.GetInt("numDth", 0);  
		getStats ();

	}

	public void getStats() {
		string stats3 = "";
		if (stats [3] > 0) {
			stats3 = "# Pur Orbs: " + stats[3] + "\n";
		}
		statsText.text = 
			"# GRN Orbs: " + stats[0] + "\n" +
			"# RED Orbs: " + stats[1] + "\n" +
			"# BLU Orbs: " + stats[2] + "\n" +
			stats3 +
			"Total Score: " + stats[4] + "\n" +
			//"Level 1 Highscore: \n" +
			//"Level 2 Highscore: \n" +
			"# Deaths: " + stats[7];
	}

	public void reset() {
		GameObject temp = GameObject.FindGameObjectWithTag ("ButtonSound");
		if (temp != null) {
			temp.GetComponentsInChildren<AudioSource> () [0].Play ();
		}
		stats =  new int[] {0,0,0,0,0,0,0,0};
		PlayerPrefs.SetInt("unlockLevel", 0);  
		PlayerPrefs.SetInt("numGrn", 0);  
		PlayerPrefs.SetInt("numRed", 0);  
		PlayerPrefs.SetInt("numBlu", 0);  
		PlayerPrefs.SetInt("numPur", 0);  
		PlayerPrefs.SetInt("highscore", 0);  
		PlayerPrefs.SetInt("lvl1HS", 0);  
		PlayerPrefs.SetInt("lvl2HS", 0);  
		PlayerPrefs.SetInt("numDth", 0);  
		PlayerPrefs.Save ();
		getStats();
	}
}
