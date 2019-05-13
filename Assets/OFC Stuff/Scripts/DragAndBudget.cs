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
    private GameObject BudgetSystem;
    public GameObject panel;
    //public string puzzleName = "PuzzleCreatorScript";
    
    bool budgetMoreThanZero;


    public energyScoring engScore;

    void Awake()
    {
        //Debug.Log(puzzleName);
        BudgetSystem = GameObject.Find("BudgetSystem");
        //PuzzleCreatorScript = GameObject.Find("PuzzleCreatorScript");


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
        budgetMoreThanZero = BudgetSystem.GetComponent<BudgetSystem>().ifBudgetNotZero(gameObject.tag);
        //Debug.Log(budgetMoreThanZero);
        if (budgetMoreThanZero)
        {
            //Find the closest Vector3 of the grid, if it returns (0,0,0) -> nothing is close

            Vector3 closest = PuzzleCreatorScript.GetComponent<CreatePuzzle>().GetNearestPointOnGrid(transform.position);
            //Debug.Log(closest);


            if (closest == new Vector3(0, 0, 0))
            {
                // Only if panel has been placed will the budget be incremented
                if (panel.GetComponent<SolarPanel>().PanelPlaced)
                {
                    StartCoroutine(BudgetSystem.GetComponent<BudgetSystem>().IncrementBudget(gameObject.tag));
                    if (gameObject.tag == "12000")
                    {
                        if (engScore.score > 3f)
                        {
                            engScore.score -= 4f;
                        }
                    }
                    else if (gameObject.tag == "3000")
                    {
                        if (engScore.score > 1f)
                        {
                            engScore.score -= 2f;
                        }
                    }
                }
                Destroy(gameObject);
            }
            else 
            {
                if (!panel.GetComponent<SolarPanel>().PanelPlaced)
                {
                    transform.position = closest;
                    StartCoroutine(BudgetSystem.GetComponent<BudgetSystem>().DecrementBudget(gameObject.tag));
                    panel.GetComponent<SolarPanel>().PanelPlaced = true;
                    engScore.count++;
                    if (gameObject.tag == "12000")
                    {
                        if (engScore.score < 10)
                        {
                            engScore.score += 4f;
                        }
                    }
                    else if (gameObject.tag == "3000")
                    {
                        if (engScore.score < 10)
                        {
                            engScore.score += 2f;
                        }
                    }
                }
            }
        }
        else
        {
           
            Destroy(gameObject);
            //StartCoroutine(BudgetSystem.GetComponent<BudgetSystem>().NoMoney());
        }
    }
}
