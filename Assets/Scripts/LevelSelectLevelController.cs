using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectLevelController : MonoBehaviour {
	public Button[] buttons = new Button[4];

	void Start () {
		int unlockLevel = PlayerPrefs.GetInt("unlockLevel", 0);  
		for (int i = 0; i <= unlockLevel; i++) {
			buttons[i].interactable = true;
		}
	}
}
