using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicesScript : MonoBehaviour {

    public GameObject reponse;
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;

    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public GameObject r4;

    private bool hasClickedChoice = false;

    void Start()
    {
        r1.SetActive(false);
        r2.SetActive(false);
        r3.SetActive(false);
        r4.SetActive(false);
    }

    public void choice1()
    {
        reponse.GetComponent<Text>().text = r1.GetComponent<Text>().text;
        hasClickedChoice = true;
    }
    public void choice2()
    {
        reponse.GetComponent<Text>().text = r2.GetComponent<Text>().text;
        hasClickedChoice = true;
    }
    public void choice3()
    {
        reponse.GetComponent<Text>().text = r3.GetComponent<Text>().text;
        hasClickedChoice = true;
    }
    public void choice4()
    {
        reponse.GetComponent<Text>().text = r4.GetComponent<Text>().text;
        hasClickedChoice = true;
    }

    // Update is called once per frame
    void Update () {
        if (hasClickedChoice)
        {
            c1.SetActive(false);
            c2.SetActive(false);
            c3.SetActive(false);
            c4.SetActive(false);
        }
	}
}
