using UnityEngine;
using System.Collections;

//Put this on the goal object in order to end the level
public class EndLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Will change the level when the player hits the goal object
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // If anything specific needs to happen at the end of the level, add it here
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
