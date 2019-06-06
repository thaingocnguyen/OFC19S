using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tetrisLogic_UI : MonoBehaviour {

    private float rotateRight = 90.0f;
    private float rotateLeft = -90.0f;
    private float currentRot;
    public GameObject roof;
    public bool isMoving = true;
    public bool isRotated = false;
    private Button b_clockwise, b_counter, b_up, b_right, b_left, b_down;



    // Use this for initialization
    void Start()
    {
        //find the buttons
        b_clockwise = GameObject.FindGameObjectWithTag("ClockButton").GetComponent<Button>();
        b_counter = GameObject.FindGameObjectWithTag("CounterClockButton").GetComponent<Button>();
        b_up = GameObject.FindGameObjectWithTag("UpButton").GetComponent<Button>();
        b_down = GameObject.FindGameObjectWithTag("DownButton").GetComponent<Button>();
        b_right = GameObject.FindGameObjectWithTag("RightButton").GetComponent<Button>();
        b_left = GameObject.FindGameObjectWithTag("LeftButt").GetComponent<Button>();

        //add listeners to the buttons
        b_clockwise.onClick.AddListener(RotateClockwise);
        b_counter.onClick.AddListener(RotateCounterClockwise);
        b_up.onClick.AddListener(MoveUp);
        b_down.onClick.AddListener(MoveDown);
        b_right.onClick.AddListener(MoveRight);
        b_left.onClick.AddListener(MoveLeftPls);

        currentRot = transform.rotation.z;
        gameObject.transform.rotation = Quaternion.Euler(-128.248f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        movingDown();
        if (isMoving)
        {
            speedDown();
            rotator();
            mover();
            
        }
    }

    public void movingDown()
    {
        if (isMoving)
        {

            gameObject.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
        }

    }

    void OnCollisionEnter(Collision col)
    {
        isMoving = false;
        Debug.Log("hit");
    }

    public void rotator()
    {
        if (Input.GetKeyDown("left"))
        {
            gameObject.transform.rotation = Quaternion.Euler(-128.248f, 0, currentRot + rotateRight);
            currentRot += rotateRight;

        }

        if (Input.GetKeyDown("right"))
        {
            gameObject.transform.rotation = Quaternion.Euler(-128.248f, 0, currentRot + rotateLeft);
            currentRot += rotateLeft;

        }
    }

    public void mover()
    {
        Vector3 rightMov = new Vector3(10f, 0f, 0f);
        Vector3 leftMov = new Vector3(-10f, 0f, 0f);
        Vector3 upMov = new Vector3(0f, 0f, 10f);
        Vector3 downMov = new Vector3(0f, 0f, -10f); 
        if (Input.GetKeyDown("w"))
        {
            gameObject.transform.Translate(upMov * Time.deltaTime, Space.World);
        }
        else if (Input.GetKeyDown("s"))
        {
            gameObject.transform.Translate(downMov * Time.deltaTime, Space.World);
        }
        else if (Input.GetKeyDown("a"))
        {
            gameObject.transform.Translate(leftMov * Time.deltaTime, Space.World);
        }
        else if (Input.GetKeyDown("d"))
        {
            gameObject.transform.Translate(rightMov * Time.deltaTime, Space.World);
        }
    }

    void speedDown()
    {
        if (Input.GetKeyDown("space"))
        {
            // gameObject.transform.position = new Vector3(gameObject.transform.position.x,
            //                                             0.1f,
            //                                             gameObject.transform.position.z);
            gameObject.transform.Translate(Vector3.down * 0.08f, Space.World);
        }
    }

    // UI stuff below here
    public void RotateClockwise()
    {
        if (isMoving)
        {
            //float xRot = rotSpeed * Mathf.Deg2Rad;

            // this.transform.Rotate(Vector3.up, -90);
            gameObject.transform.rotation = Quaternion.Euler(-128.248f, 0, currentRot + rotateLeft);
            currentRot += rotateLeft;
            Debug.Log("rotating ClockWise");
        }
    }

    public void RotateCounterClockwise()
    {
        if (isMoving)
        {
            //float xRot = rotSpeed * Mathf.Deg2Rad;

            // this.transform.Rotate(Vector3.up, 90);
            gameObject.transform.rotation = Quaternion.Euler(-128.248f, 0, currentRot + rotateRight);
            currentRot += rotateRight;
            Debug.Log("rotating Counter ClockWise");
        }
    }

    void MoveUp()
    {
        Vector3 upMov = new Vector3(0f, 0f, 10f);
        if (isMoving)
        {
            gameObject.transform.Translate(upMov * Time.deltaTime, Space.World);
        }
    }

    void MoveDown()
    {
        Vector3 downMov = new Vector3(0f, 0f, -10f); 
        if (isMoving)
        {
            gameObject.transform.Translate(downMov * Time.deltaTime, Space.World);
        }
    }

    void MoveLeftPls()
    {
        Vector3 leftMov = new Vector3(-10f, 0f, 0f);
        Debug.Log("Click Move Left");
        if (isMoving)
        {
            Debug.Log("is moving left");
            gameObject.transform.Translate(leftMov * Time.deltaTime, Space.World);
        }
    }

    void MoveRight()
    {
        Vector3 rightMov = new Vector3(10f, 0f, 0f);
        if (isMoving)
        {
            gameObject.transform.Translate(rightMov * Time.deltaTime, Space.World);
        }
    }

    
}
