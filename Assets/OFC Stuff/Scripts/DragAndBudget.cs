using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndBudget : MonoBehaviour
{
    Vector3 initialPosition;
    Quaternion initialRotation;

    float dragDistance = 9.1f; //distance to drag mouse
    float zPosSolar;
    private Vector3 objPos;
    public GameObject PuzzleCreatorScript;
    public GameObject BudgetSystem;
    public GameObject Prefab;
    bool budgetMoreThanZero;

    //public energyScoring engScore;

    void Awake()
    {

        BudgetSystem = GameObject.Find("BudgetSystem");
        PuzzleCreatorScript = GameObject.Find("PuzzleCreatorScript");

    }
    // Use this for initialization
    void Start()
    {
        initialPosition = gameObject.transform.position;
        initialRotation = gameObject.transform.rotation;



        //dragDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        //Debug.Log(dragDistance);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Instantiate(Prefab, initialPosition, initialRotation);
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

        if (budgetMoreThanZero)
        {
            //Find the closest Vector3 of the grid, if it returns (0,0,0) -> nothing is close

            Vector3 closest = PuzzleCreatorScript.GetComponent<CreatePuzzle>().GetNearestPointOnGrid(transform.position);

            if (closest == new Vector3(0, 0, 0))
            {
                //transform.position = initialPosition;
                Destroy(gameObject);
            }
            else
            {
                transform.position = closest;
                StartCoroutine(BudgetSystem.GetComponent<BudgetSystem>().UpdateBudget(gameObject.tag));
                //engScore.count++;
            }
        }
        else
        {
            Destroy(gameObject);
            //StartCoroutine(BudgetSystem.GetComponent<BudgetSystem>().NoMoney());
        }
    }
}
