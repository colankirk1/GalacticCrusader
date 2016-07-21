using UnityEngine;
using System.Collections;

public class CameraOcclusion : MonoBehaviour {
	public float DistanceToPlayer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Debug.DrawRay(transform.position, transform.forward*DistanceToPlayer); 
		RaycastHit[] hits;
		hits = Physics.RaycastAll(transform.position, transform.forward, DistanceToPlayer);

		foreach (RaycastHit hit in hits) {
			//add exception for pickups.
			Renderer R = hit.collider.GetComponent<Renderer>();
			if(R == null) {
				continue;
			}
			Occlude AT = R.GetComponent<Occlude>();
			if (AT == null) {
				AT = R.gameObject.AddComponent<Occlude>();
			}
			AT.occlude(); 
		}
	}
}
