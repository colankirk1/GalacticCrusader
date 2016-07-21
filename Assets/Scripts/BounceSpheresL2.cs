using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson {

public class BounceSpheresL2 : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }



    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter(Collision collision)
    {
        //TODO figure out how to get the character to "bounce on the collision"
        ThirdPersonCharacter charScript = collision.gameObject.GetComponent<ThirdPersonCharacter>();
        Vector3 moveVec = new Vector3(100.0f, 10.0f, 50.0f);
        charScript.Move(moveVec, false, true);
    }
}
}
