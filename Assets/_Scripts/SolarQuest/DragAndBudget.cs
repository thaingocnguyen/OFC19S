using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndBudget : MonoBehaviour
{
    Vector3 initialPosition;
    Quaternion initialRotation;

    public float dragDistance = 10.8f; //distance to drag mouse
    float zPosSolar;
    private Vector3 objPos;
    public GameObject GridGeneratorScript;

    public GameObject panel;
    
    bool budgetMoreThanZero;

    SolarPanel currentPanel;

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
        string panelCost = gameObject.tag;
        budgetMoreThanZero = BudgetSystem.Instance.ifBudgetNotZero(panelCost);
        GridGenerator grid = GridGeneratorScript.GetComponent<GridGenerator>();

        //Find the closest Vector3 of the grid, if it returns (0,0,0) -> nothing is close
        int[] gridPos = grid.GetGridPos(transform.position);

        currentPanel = panel.GetComponent<SolarPanel>();

        // Return panel to the pile if the location placed is not near grid 
        if (gridPos[0] < 0)
        {
            // Only if panel has been placed will the budget be incremented
            if (currentPanel.PanelPlaced)
            {
				StartCoroutine(BudgetSystem.Instance.IncrementBudget(panelCost));
				grid.ClearPanelOccupancy(currentPanel.gridRow, currentPanel.gridCol, panelCost);
                grid.UpdateGridScore();
                SolarScoring.Instance.UpdateScore();
            }
           
            transform.position = initialPosition;
        }
        // Place panel on grid
        else if (budgetMoreThanZero)
        {
            transform.position = grid.GetNearestPointOnGrid(gridPos[0], gridPos[1]);

            if (!panel.GetComponent<SolarPanel>().PanelPlaced)
            {
                if (SolarGamePopupManager.Instance != null)
                {
                    SolarGamePopupManager.Instance.FirstPanelPlaced();
                }
   
                grid.UpdateOccupiedPositions(gridPos[0], gridPos[1], panelCost);
                StartCoroutine(BudgetSystem.Instance.DecrementBudget(panelCost));
                panel.GetComponent<SolarPanel>().PanelPlaced = true;
            }
            else
            {
                grid.ClearPanelOccupancy(currentPanel.gridRow, currentPanel.gridCol, panelCost);
                grid.UpdateOccupiedPositions(gridPos[0], gridPos[1], panelCost);
            }

            currentPanel.gridRow = gridPos[0];
            currentPanel.gridCol = gridPos[1];

            grid.UpdateGridScore();
            SolarScoring.Instance.UpdateScore();
        }
        else
		{
			Destroy(gameObject);
		}
    }
}
