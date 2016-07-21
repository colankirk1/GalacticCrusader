using UnityEngine;
using System.Collections;

/**
 * Script is unused and should not be applied to any game object.
 */
public class CameraController : MonoBehaviour {
	public GameObject player;
	//private Vector3 offset;

	// Use this for initialization
	void Start () {
		Debug.Log ("ERROR - Unused script in use!");
		//offset = new Vector3 (-1.5f, 2, 0);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//Vector3 temp = player.transform.position;
		//transform.position = temp + offset;
	}
}
