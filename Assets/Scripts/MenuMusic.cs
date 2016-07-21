using UnityEngine;
using System.Collections;

public class MenuMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectWithTag("MenuMusic") == this.gameObject) {
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}
}
