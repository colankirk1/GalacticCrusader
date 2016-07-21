using UnityEngine;
using System.Collections;

public class MovingPlatformController : MonoBehaviour {
	public string type; //x y or z
	public float boundMin;
	public float boundMax;

	//private float curPos = 0.0f;

	public float speed;
	private bool moveNeg = false;

	void Start() {
		switch (type) {
		case "x":
			//curPos = transform.position.x;
			break;
		case "y":
			boundMin = (transform.localScale.y / 2);
			//curPos = transform.position.y;
			break;
		case "z":
			//curPos = transform.position.z;
			break;
		}
	}
	// Update is called once per frame
	void LateUpdate () {
		Vector3 movePos = Vector3.zero;
		float upInc = 0.5f;
		float downInc = -upInc;

		switch (type) {
		case "x":
			if(transform.position.x <= boundMin) {
				moveNeg = false;
			}
			if(transform.position.x >= boundMax) {
				moveNeg = true;
			}

			movePos.x = (moveNeg) ? downInc : upInc;
			break;
		case "y":
			if(transform.position.y <= boundMin) {
				moveNeg = false;
			}
			if(transform.position.y >= boundMax) {
				moveNeg = true;
			}

			movePos.y = (moveNeg) ? downInc : upInc;
			break;
		case "z":
			if(transform.position.z <= boundMin) {
				moveNeg = false;
			}
			if(transform.position.z >= boundMax) {
				moveNeg = true;
			}

			movePos.z = (moveNeg) ? downInc : upInc;
			break;
		}

		transform.position += movePos * speed * Time.deltaTime;
	}
}