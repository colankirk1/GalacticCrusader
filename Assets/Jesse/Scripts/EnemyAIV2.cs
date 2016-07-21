using UnityEngine;
using System.Collections;

public class EnemyAIV2 : MonoBehaviour {
	//Enemy AI movement based Upon script for ghost movement in  
	//Pacman Tutorial http://noobtuts.com/unity/2d-pacman-game
	public Transform[] track;      // array to store routes for enemy movement
	int current=0;                 // index of the array
	public float speed = .1f;      //speed of ai
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position != track [current].position) {
			Vector2 moveit = Vector2.MoveTowards (transform.position, track [current].position, speed);
			//Debug.DrawCube();
			GetComponent<Rigidbody2D>().MovePosition (moveit);
		} else 
			current = (current + 1)%track.Length;

		Vector2 dir = track[current].position - transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator> ().SetFloat ("DirY", dir.y);
}
}