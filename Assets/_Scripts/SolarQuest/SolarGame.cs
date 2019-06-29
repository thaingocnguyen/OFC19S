using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarGame : MonoBehaviour
{

    [SerializeField] float dragDistance = 10.8f;
    [SerializeField] GameObject smallPanel;
    [SerializeField] GameObject bigPanel;
    [SerializeField] Camera currentCamera;
    [SerializeField] GameObject GridGeneratorScript;

    Vector3 smallPanelPosition;
    Quaternion smallPanelRotation;

    Vector3 bigPanelPosition;
    Quaternion bigPanelRotation;

    GameObject currentPanel;


    private void Start()
    {
        smallPanelPosition = smallPanel.transform.position;
        smallPanelRotation = smallPanel.transform.rotation;

        bigPanelPosition = bigPanel.transform.position;
        bigPanelRotation = bigPanel.transform.rotation;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform)
                {
                    Debug.Log("Clicked");
                    if (hit.transform.CompareTag("SmallPanel"))
                    {
                        Instantiate(smallPanel, smallPanelPosition, smallPanelRotation);
                    }
                    else
                    {
                        Instantiate(bigPanel, bigPanelPosition, bigPanelRotation);
                    }

                    currentPanel = hit.transform.gameObject;
                }

            }
        }
    }


    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dragDistance);
        currentPanel.transform.position = currentCamera.ScreenToWorldPoint(mousePosition);
    }

    void OnMouseUp()
    {
        GridGenerator grid = GridGeneratorScript.GetComponent<GridGenerator>();

        //Find the closest Vector3 of the grid, if it returns (0,0,0) -> nothing is close
        int[] gridPos = grid.GetGridPos(transform.position);

        if (gridPos[0] < 0)
        {
            if (currentPanel.CompareTag("SmallPanel"))
            {
                currentPanel.transform.position = smallPanelPosition;
            }
            else
            {
                currentPanel.transform.position = bigPanelPosition;
            }
            
        }
        else
        {
            currentPanel.transform.position = grid.GetNearestPointOnGrid(gridPos[0], gridPos[1]);
        }


    }
}
