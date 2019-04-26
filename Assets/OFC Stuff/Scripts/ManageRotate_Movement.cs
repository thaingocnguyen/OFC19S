using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageRotate_Movement : MonoBehaviour {

    Vector3 initialPosition;
  
    float yPosSolar;
    float yPosPlacement;
    bool isSelected = false;
    float moveSpeed = 30;
    bool moveLeft = false;

    // Use this for initialization
    void Start()
    {
        initialPosition = gameObject.transform.position;
        isSelected = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            transform.Translate(Vector3.down * Time.deltaTime, Space.World);
            if (moveLeft)
            {
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }
        }
    }
    //check to see if tags match && rotation is right && distance is >0.5
    //if match tag ->stay
    // if not -> destroy
    void OnTriggerEnter(Collider other)
    {
       // float distance = Vector3.Distance(transform.position, other.transform.position); //distance between placement and solar

        yPosSolar = this.transform.eulerAngles.y; //y rotation of the solar object
        yPosPlacement = other.gameObject.transform.eulerAngles.y;
        
            
            Debug.Log("this tag" + this.tag);
            Debug.Log("other tag" + other.gameObject.tag);
            if (this.gameObject.CompareTag(other.gameObject.tag)
                && yPosSolar < (yPosPlacement + 30)
                && yPosSolar > (yPosPlacement - 30))
            {
                //transform.position = other.gameObject.transform.position;
                isSelected = false;
            }
            else
            {
                Destroy(this.gameObject);
                isSelected = false;
            }
        }
        
    

    public void RotateClockwise()
    {
        if (isSelected)
        {
            //float xRot = rotSpeed * Mathf.Deg2Rad;

            this.transform.Rotate(Vector3.up, -90);
            Debug.Log("rotating ClockWise");
        }
    }

    public void RotateCounterClockwise()
    {
        if (isSelected)
        {
            //float xRot = rotSpeed * Mathf.Deg2Rad;

            this.transform.Rotate(Vector3.up, 90);
            Debug.Log("rotating Counter ClockWise");
        }
    }

    public void OnMoveLeft()
    {
        
        

            moveLeft = true;
            this.transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y, transform.position.z);
            //this.transform.Translate(Vector3.left* Time.deltaTime * moveSpeed, Space.World);
            //this.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            Debug.Log("move left");
        
    }

    public void NoMoveLeft()
    {
        if (isSelected)
        {

            moveLeft = false;
            Debug.Log("stop move left");
        }
    }
}
