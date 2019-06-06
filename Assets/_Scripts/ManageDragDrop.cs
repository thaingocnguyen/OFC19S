using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageDragDrop : MonoBehaviour {

    Vector3 initialPosition;
    public GameObject placement; //the placement of the puzzle piece
    float dragDistance = 10; //distance to drag mouse
    float zPosSolar;
    float zPosPlacement;
    

	// Use this for initialization
	void Start () {
        initialPosition = gameObject.transform.position;
        zPosPlacement = placement.transform.eulerAngles.y;
        //dragDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        //Debug.Log(dragDistance);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDrag()
    {
        Debug.Log("drag");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dragDistance);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPos;
    }

    void OnMouseUp()
    {
        Debug.Log("mouse up");

        float distance = Vector3.Distance(transform.position, placement.transform.position); //distance between placement and solar
        zPosSolar = this.transform.eulerAngles.z; //y rotation of the solar object

        if (distance < 0.5)
        {
            Debug.Log(distance);
            Debug.Log("this tag" + this.tag);
            Debug.Log("other tag" + placement.tag);
            if (this.gameObject.CompareTag(placement.tag)
                && zPosSolar < (zPosPlacement + 30)
                && zPosSolar > (zPosPlacement - 30)) 
            { transform.position = placement.transform.position; }
            else { transform.position = initialPosition; }
        }
        else { transform.position = initialPosition; }
        }
    
}
