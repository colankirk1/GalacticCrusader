using UnityEngine;
using System.Collections;

public class RotateCameraSlowly : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void LateUpdate()
    {
        float turnVal = Time.deltaTime * 4;
        Vector3 rotationValue = new Vector3(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y + turnVal, Camera.main.transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(rotationValue);
    }
}
