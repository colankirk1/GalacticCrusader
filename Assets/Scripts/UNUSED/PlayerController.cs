using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Script is unused and should not be applied to any game object.
 */
public class PlayerController : MonoBehaviour {
	public float speed;
	public float jumpSpeed;
	public float distToGround;

	public Camera mainCamera;

	private Rigidbody rb;
	private Vector3 startPos;
	
	void Start() {
		Debug.Log ("ERROR - Unused script in use!");
		rb = GetComponent<Rigidbody> ();
		startPos = transform.position;
		distToGround = GetComponent<SphereCollider> ().bounds.extents.y;
	}
	
	void FixedUpdate () {
		//playerMovement ();
	}

	void playerMovement() {
		//int cameraRotation = (int)mainCamera.transform.rotation.eulerAngles.y;
		float moveHorizontal = 0;
		float moveVeritcal = 0;

		if (Input.GetKey (KeyCode.A)) {
			moveHorizontal = -1;
		}
		if(Input.GetKey (KeyCode.D)) {
			moveHorizontal = 1;
		}

		if (Input.GetKey (KeyCode.W)) {
			moveVeritcal = 1;
		}
		if(Input.GetKey (KeyCode.S)) {
			moveVeritcal = -1;
		}

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVeritcal);
		movement = Camera.main.transform.TransformDirection(movement);
		movement.y = 0.0f;

		transform.position = transform.position + (movement * Time.deltaTime * speed);

		if (Input.GetKey (KeyCode.Space) && isPlayerOnTheGround() == true) {
			Vector3 jump = new Vector3 (0, jumpSpeed, 0);
			rb.AddForce(jump);
		} 

		if (transform.position.y < -5) {
			resetPlayerPosition();
		}

		if (isPlayerOnTheGround ()) {
			rb.angularVelocity = Vector3.zero;
		}
	}

	void resetPlayerPosition () {
		transform.position = startPos;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}

	bool isPlayerOnTheGround() {
		return Physics.Raycast(transform.position, (Vector3.up * -1), distToGround + 0.1f);
	}
}
