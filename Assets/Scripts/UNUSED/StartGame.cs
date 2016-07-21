using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    Button startGameButton;

    void Listener()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

	// Use this for initialization
	void Start () {
        startGameButton = gameObject.GetComponent<Button>();
        startGameButton.onClick.AddListener(Listener);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    
}
