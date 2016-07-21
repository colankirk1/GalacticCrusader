using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditsButton : MonoBehaviour {

    Button Credits;

    void Listener()
    {
        Application.LoadLevel(Application.levelCount - 1);
    }

    // Use this for initialization
    void Start () {
        Credits = gameObject.GetComponent<Button>();
        Credits.onClick.AddListener(Listener);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
