using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class CheckPointSystem : MonoBehaviour
    {

        Vector3 resetPos;

        // Use this for initialization
        void Start()
        {
            resetPos = getStartPos();
        }

        Vector3 getStartPos()
        {
            Vector3 startPos = new Vector3();
			string level = Application.loadedLevelName;
            if (level.Equals("TutorialLevel")) {
                startPos = new Vector3(20.0f, 0.0f, 10.0f);
			} else if (level.Equals("Level 1")) {
				startPos = new Vector3(2.0f, 0.5f, 148.0f);
			} else if (level.Equals("Level 2")) {
				startPos = new Vector3(2.0f, 0.5f, 150.0f);
			} else if (level.Equals("Level 3")) {
				startPos = new Vector3(0.0f, 0.0f, -5.0f);
			}
            return startPos;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R)) {
				resetPlayer();
            }
            else if (Input.GetKeyDown(KeyCode.F5)) {
				resetLevel();
            }
        }

        public void resetPlayer() {
			gameObject.transform.position = resetPos;
            ThirdPersonUserControl ourControl = gameObject.GetComponent<ThirdPersonUserControl>();
            ourControl.setScore(0);
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<PauseController> ().togglePaused ();

        }

		public void resetLevel() {
			Application.LoadLevel(Application.loadedLevel);
		}

        void OnTriggerEnter(Collider collision)
        {
            if(collision.gameObject.tag.Equals("Checkpoint"))
            {
                Light checkpointLight = collision.gameObject.GetComponent<Light>();
                if (checkpointLight.color != Color.blue)
                {
                    resetPos = collision.gameObject.transform.position;
                    checkpointLight.color = Color.blue;
                }
            }
        }
    }
}