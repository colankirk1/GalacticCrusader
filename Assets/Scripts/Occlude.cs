using UnityEngine;
using System.Collections;

public class Occlude : MonoBehaviour {
	private float curA = 0.2f;
	private const float tarA = 0.2f;
	private const float fadeTime = 0.5f; 
	private Color oldColor;
	private bool isTransparent;

	void Start() {
		if (GetComponent<Renderer>().material) {   
			oldColor = GetComponent<Renderer>().material.color;
			curA = oldColor.a;
		} else {
			curA = 1.0f;
		}
	}

	void OnDestroy()
	{
		GetComponent<Renderer> ().material.color = oldColor;
	}

	// Update is called once per frame
	void Update () {
		if (!isTransparent && curA >= 1.0f) {
			Destroy(this);
		}
		//Are we fading in our out?
		if (isTransparent) {
			//Fading out
			if (curA > tarA)
				curA -= ((1.0f - tarA) * Time.deltaTime) / fadeTime;
		} else {
			//Fading in
			curA += ( (1.0f - tarA) * Time.deltaTime) / fadeTime;
		}
		Color tempColor = GetComponent<Renderer> ().material.color;
		tempColor.a = curA;
		GetComponent<Renderer> ().material.color = tempColor;
		//The object will start to become visible again if BeTransparent() is not called
		isTransparent = false;
	}

	public void occlude() {
		isTransparent = true;
	}
}
