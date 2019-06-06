using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBudgetVsEnergy : MonoBehaviour {

    Vector3 initialPosition;
    
    float dragDistance = 9.1f; //distance to drag mouse
    float zPosSolar;
    private Vector3 objPos;
    public GameObject PuzzleCreatorScript;
    public energyScoring engScore;
    private int placedTimes = 0;

    

    // Use this for initialization
    void Start()
    {
        initialPosition = gameObject.transform.position;
        

        //dragDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        //Debug.Log(dragDistance);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dragDistance);
        objPos = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPos;
    }

   

    void OnMouseUp()
    {
        //Find the closest Vector3 of the grid, if it returns (0,0,0) -> nothing is close

        Vector3 closest = PuzzleCreatorScript.GetComponent<GridGenerator>().GetNearestPointOnGrid(transform.position);

        if (closest == new Vector3(0, 0, 0))
        {
            transform.position = initialPosition;
            engScore.count--;
            placedTimes = 0;

            if (gameObject.tag == "2x2")
            {
                if (engScore.score > 0)
                {
                    engScore.score -= 4;
                }
            }
            else if (gameObject.tag == "4x4")
            {
                if (engScore.score > 0)
                {
                    engScore.score -= 16;
                }
            }
            else if (gameObject.tag == "2x3")
            {
                if (engScore.score > 0)
                {
                    engScore.score -= 6;
                }
            }
            else if (gameObject.tag == "3x4")
            {
                if (engScore.score > 0)
                {
                    engScore.score -= 12;
                }
            }
            else if (gameObject.tag == "2x4")
            {
                if (engScore.score > 0)
                {
                    engScore.score -= 8;
                }
            }
            else if (gameObject.tag == "3x3")
            {
                if (engScore.score > 0)
                {
                    engScore.score -= 9;
                }

            }
        }
        else
        {
            transform.position = closest;
            engScore.count++;
            placedTimes++;
            

            if (gameObject.tag == "2x2" && placedTimes == 1)
                {
                    if (engScore.score < 55)
                    {
                        engScore.score += 4;
                    }
                }
                else if (gameObject.tag == "4x4" && placedTimes == 1)
                {
                    if (engScore.score < 55)
                    {
                        engScore.score += 16;
                    }
                }
                else if (gameObject.tag == "2x3" && placedTimes == 1)
                {
                    if (engScore.score < 55)
                    {
                        engScore.score += 6;
                    }
                }
                else if (gameObject.tag == "3x4" && placedTimes == 1)
                {
                    if (engScore.score < 55)
                    {
                        engScore.score += 12;
                    }
                } 
                else if (gameObject.tag == "2x4" && placedTimes == 1)
                {
                    if (engScore.score < 55)
                    {
                        engScore.score += 8;
                    }
                }
                else if (gameObject.tag == "3x3" && placedTimes == 1)
                {
                    if (engScore.score < 55)
                    {
                        engScore.score += 9;
                    }
              
            }
        }
    }

    
}