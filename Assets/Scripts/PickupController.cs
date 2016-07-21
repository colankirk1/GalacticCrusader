using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {
	public GameObject GreenOrbyThing;
	public Light Spotlight;
	public float bounceAmount;
	private float curY;
	private float speed = 0.5f;
	private bool moveUp = true;

	public int varScore;
	public int varHealth;

	// Use this for initialization
	void Start () {
		curY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveUp) {
			transform.position += Vector3.up * speed * Time.deltaTime;
		} else {
			transform.position -= Vector3.up * speed * Time.deltaTime;
		}
		if (transform.position.y > curY + bounceAmount) {
			moveUp = false;
		}
		if (transform.position.y < curY - bounceAmount) {
			moveUp = true;
		}

		GreenOrbyThing.transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
