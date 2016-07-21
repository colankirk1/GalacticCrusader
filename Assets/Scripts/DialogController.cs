using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogController : MonoBehaviour {
	public GameObject myPanel;

	void OnDestroy() {
		GameObject[] gos = GameObject.FindGameObjectsWithTag("DialogPanel"); 
		for (int i = 0; i < gos.Length; i++) {
			if(gos[i] != null) {
				gos[i].SetActive(false);
			}
		}
		if (myPanel != null) {
			myPanel.SetActive (true);
		}

	}
}
