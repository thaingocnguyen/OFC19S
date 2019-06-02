using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSolarPuzzle : MonoBehaviour {

    //float rotSpeed = 90; //speed to rotate the object
    
    bool isSelected = false; //when the object is selected
    public bool correctPlace = false;
    public Material[] materials;
    Vector3 initialPosition;
    public GameObject placement; //the placement of the puzzle piece
    float dragDistance = 9.1f; //distance to drag mouse
    float zPosSolar;
    float zPosPlacement;
    Renderer rend;
    public GameObject puzzleMaster;

    //public GameObject solar;


    // Use this for initialization
    void Start()
    {

        rend = GetComponent<Renderer>();
        rend.sharedMaterial = materials[0];
        //m_Material = GetComponent<Renderer>().material;
        // oldMat = m_Material;
        //dragDistance = Vector3.Distance(transform.position, Camera.main.transform.position);

        initialPosition = gameObject.transform.position;
        zPosPlacement = placement.transform.eulerAngles.z;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RotateClockwise()
    {
        if (isSelected)
        {
            //float xRot = rotSpeed * Mathf.Deg2Rad;

            this.transform.Rotate(Vector3.forward, -90);
            Debug.Log("rotating ClockWise");
        }
    }

    public void RotateCounterClockwise()
    {
        if (isSelected)
        {
            //float xRot = rotSpeed * Mathf.Deg2Rad;

            this.transform.Rotate(Vector3.forward, 90);
            Debug.Log("rotating Counter ClockWise");
        }
    }

    void OnMouseDown()
    {
        Debug.Log("mouse is down");
        if (isSelected == false) //if the object is not selected
        {
            isSelected = true; //object becomes selected

            //m_Material = selectMat;
            rend.sharedMaterial = materials[1];
        }
        else
        {
            isSelected = false; //object becomes selected

            //m_Material = oldMat;
            rend.sharedMaterial = materials[0];
        }
    }

    void OnMouseDrag()
    {
        if (!isSelected && !correctPlace)
        {
            Debug.Log("dragging");

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dragDistance);
            Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = objPos;
            //Debug.Log(dragDistance);
        }
    }

    void OnMouseUp()
    {
        Debug.Log("mouse up");
        float distance = Vector3.Distance(transform.position, placement.transform.position); //distance between placement and solar
        zPosSolar = this.transform.eulerAngles.z; //y rotation of the solar object

        if (distance < 1)
        {
            Debug.Log(distance);
            Debug.Log("this tag" + this.tag);
            Debug.Log("other tag" + placement.tag);
            if (this.gameObject.CompareTag(placement.tag)
                && zPosSolar < (zPosPlacement + 30)
                && zPosSolar > (zPosPlacement - 30))
            {
                transform.position = placement.transform.position;
                correctPlace = true;
                puzzleMaster.GetComponent<CheckPuzzleCompleted>().isPuzzleComplete();
                }
            else { transform.position = initialPosition; }
        }
        else { transform.position = initialPosition; }
    }
}
