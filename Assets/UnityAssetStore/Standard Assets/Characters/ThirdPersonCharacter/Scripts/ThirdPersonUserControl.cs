using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

		private int score;
		public Text scoreObject;

		public int health;
		public Text healthObject;
		
		public AudioSource greenPickupSound;
		public AudioSource redPickupSound;
		public AudioSource bluePickupSound;
		     
		private int[] stats = {0,0,0,0,0,0,0,0};

		private PauseController pausedController;

        private void Start()
		{
			pausedController = GameObject.FindWithTag ("GameController").GetComponent<PauseController> ();
			stats[0] = PlayerPrefs.GetInt("numGrn", 0);  
			stats[1] = PlayerPrefs.GetInt("numRed", 0);  
			stats[2] = PlayerPrefs.GetInt("numBlu", 0);  
			stats[3] = PlayerPrefs.GetInt("numPur", 0);  
			stats[4] = PlayerPrefs.GetInt("highscore", 0);  
			stats[5] = PlayerPrefs.GetInt("lvl1HS", 0);  
			stats[6] = PlayerPrefs.GetInt("lvl2HS", 0);  
			stats[7] = PlayerPrefs.GetInt("numDth", 0);  


			score = 0;
			setHealth (health);
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        // Fixed update is called in sync with physics
		private void FixedUpdate()
		{
			// read inputs
			float h = CrossPlatformInputManager.GetAxis ("Horizontal");
			float v = CrossPlatformInputManager.GetAxis ("Vertical");
			bool crouch = Input.GetKey (KeyCode.C);

			// calculate move direction to pass to character
			if (m_Cam != null) {
				// calculate camera relative direction to move:
				m_CamForward = Vector3.Scale (m_Cam.forward, new Vector3 (1, 0, 1)).normalized;
				m_Move = v * m_CamForward + h * m_Cam.right;
			} else {
				// we use world-relative directions in the case of no main camera
				m_Move = v * Vector3.forward + h * Vector3.right;
			}
			#if !MOBILE_INPUT
			// walk speed multiplier
			if (Input.GetKey (KeyCode.LeftShift) && v > 0)
				m_Move *= 0.5f;
			#endif
			if (pausedController.isLevelPaused ()) { 
				m_Move = Vector3.zero;
				m_Jump = false;
				crouch = true;
			}

			// pass all parameters to the character control script
			m_Character.Move (m_Move, crouch, m_Jump);
			m_Jump = false;
	}

		/**
		 * The player has picked up an object. Destroy that sucker!
		 */
		void OnTriggerEnter(Collider other) 
		{
			if (other.gameObject.CompareTag ("GreenOrbyThing")) {
				stats[4] += other.gameObject.GetComponent<PickupController>().varScore;
				PlayerPrefs.SetInt ("numGrn", ++stats[0]);
				PlayerPrefs.SetInt ("highscore", stats[4]);
				PlayerPrefs.Save ();

				greenPickupSound.Play();
				setScore(score + other.gameObject.GetComponent<PickupController>().varScore);
				Destroy(other.gameObject);
			} else if (other.gameObject.CompareTag ("HealthDownPickup")) {
				stats[4] -= other.gameObject.GetComponent<PickupController>().varScore;
				PlayerPrefs.SetInt ("numRed", ++stats[1]);
				PlayerPrefs.SetInt ("highscore", stats[4]);
				PlayerPrefs.Save ();

				redPickupSound.Play();
				setScore(score - other.gameObject.GetComponent<PickupController>().varScore);
				setHealth(health - other.gameObject.GetComponent<PickupController>().varHealth);
				Destroy(other.gameObject);
			} else if (other.gameObject.CompareTag ("HealthUpPickup")) {
				stats[4] += other.gameObject.GetComponent<PickupController>().varScore;
				PlayerPrefs.SetInt ("numBlu", ++stats[2]);
				PlayerPrefs.SetInt ("highscore", stats[4]);
				PlayerPrefs.Save ();

				bluePickupSound.Play();
				setScore(score + other.gameObject.GetComponent<PickupController>().varScore);
				setHealth(health + other.gameObject.GetComponent<PickupController>().varHealth);
				Destroy(other.gameObject);
			} else if (other.gameObject.CompareTag ("PurpleSurprise")) {
				stats[4] += other.gameObject.GetComponent<PickupController>().varScore;
				PlayerPrefs.SetInt ("numPur", ++stats[3]);
				PlayerPrefs.SetInt ("highscore", stats[4]);
				PlayerPrefs.Save ();

				greenPickupSound.Play();
				bluePickupSound.Play();
				setScore(score + other.gameObject.GetComponent<PickupController>().varScore);
				setHealth(health + other.gameObject.GetComponent<PickupController>().varHealth);
				Destroy(other.gameObject);
			} else if (other.gameObject.CompareTag ("DialogBubble")) {
				greenPickupSound.Play();
				Destroy(other.gameObject);
			}
		}

		// Public
		// Sets the current score and changes the score/highscore texts as applicable.
		public void setScore(int newScore) {
			score = newScore;
			scoreObject.text = "Score: " + newScore;
		}

		// Public
		// Sets the current score and changes the score/highscore texts as applicable.
		public void setHealth(int newHealth) {
			health = newHealth;
			healthObject.text = "Health:        x" + newHealth;
			if (newHealth <= 0) {
				GameObject temp = GameObject.FindGameObjectWithTag ("MenuMusic");
				if (temp != null) {
					temp.GetComponentsInChildren<AudioSource> () [0].mute = false;
				}
				PlayerPrefs.SetInt ("numDth", ++stats[7]);
				PlayerPrefs.Save ();
				Application.LoadLevel(7);
			}
		}

    }
}
