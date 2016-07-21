using UnityEngine;
using System.Collections;

public class ButtonSound : MonoBehaviour {
	void Start () {
		//Make sure we only have one of these.
		if (GameObject.FindGameObjectWithTag("ButtonSound") == this.gameObject) {
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}
}
