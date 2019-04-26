using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageRotate : MonoBehaviour {

    float rotSpeed = 90; //speed to rotate the object
    private GameObject rotationBtns;
    bool isSelected = false; //when the object is selected
    Material m_Material;
    //public GameObject solar;


	// Use this for initialization
	void Start () {
        rotationBtns.SetActive(false);
        m_Material = GetComponent<Renderer>().material;
        rotationBtns =  GameObject.Find("RotationBtns");

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void RotateClockwise()
    {
        if (isSelected)
        {
            float xRot = rotSpeed * Mathf.Deg2Rad;

            this.transform.Rotate(Vector3.up, -xRot);
            Debug.Log("rotating ClockWise");
        }
    }

    public void RotateCounterClockwise()
    {
        if (isSelected)
        {
            float xRot = rotSpeed * Mathf.Deg2Rad;

            this.transform.Rotate(Vector3.up, xRot);
            Debug.Log("rotating Counter ClockWise");
        }
    }

    void OnMouseDown()
    {
        if(isSelected == false) //if the object is not selected
        {
            isSelected = true; //object becomes selected
            
            m_Material.color = Color.green;
        }
        else
        {
            isSelected = false; //object becomes selected
            
            m_Material.color = Color.gray;
        }
    }

    
}
