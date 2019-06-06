using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPlacer : MonoBehaviour
{ 

    [SerializeField]
    float dragDistance = 10.8f; //distance to drag mouse
    [SerializeField]
    int panelCount;

    Vector3 initialPosition;
    Quaternion initialRotation;
    float zPosSolar;
    private Vector3 objPos;
    public GameObject GridGeneratorScript;

    public GameObject panel;



    void Start()
    {
        initialPosition = gameObject.transform.position;
        initialRotation = gameObject.transform.rotation;
    }


    void OnMouseDown()
    {
        // Instantiate a new solar panel when it is clicked on 
        Instantiate(panel, initialPosition, initialRotation);
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dragDistance);
        objPos = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPos;
    }



    void OnMouseUp()
    {
        if (panelCount > 0)
        {
            //Find the closest Vector3 of the grid, if it returns (0,0,0) -> nothing is close
            Vector3 closest = GridGeneratorScript.GetComponent<GridGenerator>().GetNearestPointOnGrid(transform.position);

            // Return panel to the pile if the location placed is not near grid 
            if (closest == new Vector3(0, 0, 0))
            {
                // Only if panel has been placed will the budget be incremented
                if (panel.GetComponent<SolarPanel>().PanelPlaced)
                {
                    panelCount++;
                    if (gameObject.tag == "12000")
                    {
                    }
                    else if (gameObject.tag == "3000")
                    {
                    }
                }
                Destroy(gameObject);
            }
            // Place panel on grid
            else
            {
                transform.position = closest;
                if (!panel.GetComponent<SolarPanel>().PanelPlaced)
                {
                    panel.GetComponent<SolarPanel>().PanelPlaced = true;
                    panelCount--; 

                    if (gameObject.tag == "12000")
                    {
                    }
                    else if (gameObject.tag == "3000")
                    {
                    }
                }
            }
        }
        // If there is not enough budget, do not allow the user to place more solar panels 
        else
        {
            Destroy(gameObject);
        }
    }
}
