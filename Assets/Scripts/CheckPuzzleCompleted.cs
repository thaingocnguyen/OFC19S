using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPuzzleCompleted : MonoBehaviour {
    public GameObject[] puzzlePieces;
    public Text text;
    bool[] isComplete;
    bool check = false;
    int i = 0;
    public GameObject btn;
	// Use this for initialization
	void Start () {
        isComplete = new bool[puzzlePieces.Length];
        btn.SetActive(false);
        text.text = "Complete the solar panel!";
    }

    
	
	// Update is called once per frame
	void Update () {
             

    }

    bool checkIfComplete()
    {
        for (i = 0; i < puzzlePieces.Length; i++)
        {
            if (isComplete[i] == false)
            {
                return false;
            }
        }
        return true;
    }

    public void isPuzzleComplete()
    {
        // set array
        for (i = 0; i < puzzlePieces.Length; i++)
        {
            check = puzzlePieces[i].GetComponent<ManageSolarPuzzle>().correctPlace;
            Debug.Log("check is " + check);
            isComplete[i] = check;
            
        }
        if (checkIfComplete())
        {
            text.text = "Congratz! Now help your neighbors!";
            btn.SetActive(true);
        }
    }

    
}
