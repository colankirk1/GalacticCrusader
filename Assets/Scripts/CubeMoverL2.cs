using UnityEngine;
using System.Collections;

public class CubeMoverL2 : MonoBehaviour {

    float moveXSpeed;
    float moveYSpeed;
    float moveZSpeed;
    float moveXDist;
    float moveYDist;
    float moveZDist;
    float DistMovedX;
    float DistMovedY;
    float DistMovedZ;
    Vector3 asteroidSpawn;

    // Use this for initialization
    void Start () {
        DistMovedX = 0.0f;
        DistMovedY = 0.0f;
        DistMovedZ = 0.0f;
        moveXSpeed = 0.0f;
        moveYSpeed = 0.0f;
        moveZSpeed = 0.0f;
        moveXDist = 0.0f;
        moveYDist = 0.0f;
        moveZDist = 0.0f;
        asteroidSpawn = new Vector3();
        initializeGlobals();
	}
	
    //Will initialize the globals of this script based on the holding game object
    void initializeGlobals()
    {
        string objName = gameObject.name;

        //Level dependent global initialization
        if (objName.Equals("UpDown"))
        {
            moveYDist = 3.0f;
            moveYSpeed = 0.05f;
        }
        else if (objName.Equals("UpDown2"))
        {
            moveYDist = 5.0f;
            moveYSpeed = 0.05f;
        }
        else if(objName.Equals("TransitionStair"))
        {
            moveYDist = 14.0f;
            moveYSpeed = -0.1f;
        }
        else if(objName.Equals("UpDownStair"))
        {
            moveYDist = 7.0f;
            moveYSpeed = 0.1f;
        }
        else if(objName.Equals("UpDownStair2"))
        {
            moveYDist = 14.0f;
            moveYSpeed = 0.15f;
		}
		else if (objName.Equals("SideToSide"))
		{
			moveXDist = 3.0f;
			moveXSpeed = 0.05f;
		}
		else if (objName.Equals("SideToSide2"))
		{
			moveXDist = 5.0f;
			moveXSpeed = 0.1f;
		}
        else if (objName.Equals("Asteroid"))
        {
            asteroidSpawn = new Vector3(-90, transform.position.y, transform.position.z);
            moveXSpeed = Random.Range(.3f, .7f);
        }
        else if (objName.Equals("Asteroid2"))
        {
            asteroidSpawn = new Vector3(-90, transform.position.y, transform.position.z);
            moveXSpeed = Random.Range(.3f, .7f);
        }
    }

	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (gameObject.name.Equals("Asteroid"))
        {
            transform.Rotate(30 * Time.deltaTime, 13 * Time.deltaTime, 0);
        }
        else if (gameObject.name.Equals("Asteroid2"))
        {
            transform.Rotate(5 * Time.deltaTime, 8 * Time.deltaTime, 12 * Time.deltaTime);
        }
        else if (gameObject.name.Equals("Rotate"))
        {
            transform.Rotate(30 * Time.deltaTime, 0, 0);
        }


        if (moveXSpeed != 0)
        {
            
			DistMovedX += moveXSpeed;
			if (gameObject.name.Equals ("Asteroid") || gameObject.name.Equals ("Asteroid2")) {
				gameObject.transform.position = new Vector3(gameObject.transform.position.x + moveXSpeed, gameObject.transform.position.y, gameObject.transform.position.z);
				if(transform.position.x > 30){
					transform.position = asteroidSpawn;
				}
			}
			else if(Mathf.Abs(DistMovedX) > moveXDist)
			{
				DistMovedX -= moveXSpeed;
				moveXSpeed *= -1;
			}
			else
			{
				gameObject.transform.position = new Vector3(gameObject.transform.position.x + moveXSpeed, gameObject.transform.position.y, gameObject.transform.position.z);
			}
        }

        if (moveYSpeed != 0)
        {

            DistMovedY += moveYSpeed;
            if (Mathf.Abs(DistMovedY) > moveYDist)
            {
                DistMovedY -= moveYSpeed;
                moveYSpeed *= -1;
            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + moveYSpeed, gameObject.transform.position.z);
            }
        }

        if (moveZSpeed != 0)
        {

            DistMovedZ += moveZSpeed;
            if (Mathf.Abs(DistMovedZ) > moveZDist)
            {
                DistMovedZ -= moveZSpeed;
                moveZSpeed *= -1;
            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + moveZSpeed);
            }
        }

    }
}
