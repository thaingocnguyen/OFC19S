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
    public GameObject PuzzleCreatorScript;

    public GameObject panel;
    
    bool budgetMoreThanZero;


    //public energyScoring engScore;

    void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        initialPosition = gameObject.transform.position;
        initialRotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

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
        budgetMoreThanZero = BudgetSystem.Instance.ifBudgetNotZero(gameObject.tag);
        if (budgetMoreThanZero)
        {
            //Find the closest Vector3 of the grid, if it returns (0,0,0) -> nothing is close
            Vector3 closest = PuzzleCreatorScript.GetComponent<CreatePuzzle>().GetNearestPointOnGrid(transform.position);

            // Return panel to the pile if the location placed is not near grid 
            if (closest == new Vector3(0, 0, 0))
            {
                // Only if panel has been placed will the budget be incremented
                if (panel.GetComponent<SolarPanel>().PanelPlaced)
                {
                    StartCoroutine(BudgetSystem.Instance.IncrementBudget(gameObject.tag));
                    if (gameObject.tag == "12000")
                    {
                        if (BudgetSystem.Instance.EnergyScore > 3)
                        {
                            BudgetSystem.Instance.decrementEnergyScore(4);
                        }
                    }
                    else if (gameObject.tag == "3000")
                    {
                        if (BudgetSystem.Instance.EnergyScore > 1)
                        {
                            BudgetSystem.Instance.decrementEnergyScore(2);
                        }
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
                    StartCoroutine(BudgetSystem.Instance.DecrementBudget(gameObject.tag));
                    panel.GetComponent<SolarPanel>().PanelPlaced = true;

                    if (gameObject.tag == "12000")
                    {
                        if (!panel.GetComponent<SolarPanel>().isShaded)
                        {
                            BudgetSystem.Instance.incrementEnergyScore(4);
                        }
                    }
                    else if (gameObject.tag == "3000")
                    {
                        if (!panel.GetComponent<SolarPanel>().isShaded)
                        {
                            BudgetSystem.Instance.incrementEnergyScore(4);
                        }
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
