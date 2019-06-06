using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetrisLogic : MonoBehaviour {

    private float rotateRight = 90.0f;
    private float rotateLeft = -90.0f;
    private float currentRot;
    public GameObject roof;
    public bool isMoving = true;
    public bool isRotated = false;

    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject upWall;
    public GameObject downWall;

    
    public bool tetrisHit = false;


    // Use this for initialization
    void Start () {
        currentRot = transform.rotation.z;
		gameObject.transform.rotation = Quaternion.Euler(-128.248f, 0, 0);
        leftWall = GameObject.Find("leftWall");
        rightWall = GameObject.Find("rightWall");
        upWall = GameObject.Find("upWall");
        downWall = GameObject.Find("downWall");
    }
	
	// Update is called once per frame
	void Update () {
        movingDown();
        if (isMoving)
        {
            speedDown();
            rotator();
            mover(); ;
        }
	}

    public void movingDown()
    {
        if (isMoving)
       {
          
            gameObject.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
        } 

    }

	void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag != "wall")
        {
            isMoving = false;
        }

        if (col.gameObject.tag == "tetrisObj")
        {
            tetrisHit = true;
            //Debug.Log("block hit block");
        }
		//Debug.Log("hit");
	}


    public void rotator()
    {
        if (Input.GetKeyDown("right"))
        {
			gameObject.transform.rotation = Quaternion.Euler(-128.248f, 0, currentRot + rotateRight);
            currentRot += rotateRight;
            
        }

        if (Input.GetKeyDown("left"))
        {
			gameObject.transform.rotation = Quaternion.Euler(-128.248f, 0, currentRot - rotateLeft);
            currentRot += rotateLeft;
            
        }
    }

    public void mover()
    {
        Vector3 rightMov = new Vector3(5f,0f,0f);
        Vector3 leftMov = new Vector3(-5f, 0f, 0f);
        Vector3 upMov = new Vector3(0f, 0f, 5f);
        Vector3 downMov = new Vector3(0f, 0f, -5f); ;
        if (Input.GetKey("w") && gameObject.transform.position.z < upWall.transform.position.z)
        {
            gameObject.transform.Translate(upMov * Time.deltaTime, Space.World);
        } else if (Input.GetKey("s") && gameObject.transform.position.z > downWall.transform.position.z)
        {
            gameObject.transform.Translate(downMov * Time.deltaTime, Space.World);
        } else if (Input.GetKey("a") && gameObject.transform.position.x > leftWall.transform.position.x)
        {
            gameObject.transform.Translate(leftMov * Time.deltaTime, Space.World );
        } else if (Input.GetKey("d") && gameObject.transform.position.x < rightWall.transform.position.x)
        {
            gameObject.transform.Translate(rightMov * Time.deltaTime, Space.World);
        }
    }

    void speedDown()
    {
        if (Input.GetKey("down"))
        {
            // gameObject.transform.position = new Vector3(gameObject.transform.position.x,
            //                                             0.1f,
            //                                             gameObject.transform.position.z);
            Vector3 down = new Vector3(0f, -5f, 0f);
            gameObject.transform.Translate(down* Time.deltaTime, Space.World);
        }
    }

}
