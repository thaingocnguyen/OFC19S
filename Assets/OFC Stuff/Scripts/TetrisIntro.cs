using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TetrisIntro : MonoBehaviour {

    public Text mainTxt;
    public GameObject sunSlide;
    public GameObject directionBtns;
    public GameObject hint1;
    public GameObject hint2;
    public GameObject hint3;
    public GameObject hint1btn;
    public GameObject hint2btn;
    public GameObject hint3btn;
    public GameObject hintX;
    public GameObject giveHint;
    public GameObject topCam;
    public GameObject southCam;
    

    public float waitTime = 3f;

    private int trialNum = 0;

	// Use this for initialization
	void Start () {
        sunSlide.SetActive(false);
        directionBtns.SetActive(false);
        hint1.SetActive(false);
        hint2.SetActive(false);
        hint3.SetActive(false);
        hint1btn.SetActive(false);
        hint2btn.SetActive(false);
        hint3btn.SetActive(false);
        hintX.SetActive(false);
        giveHint.SetActive(false);
        southCam.SetActive(false);
        

        topCam.SetActive(true);
        StartCoroutine(startTutorial(waitTime));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator startTutorial(float time)
    {
        mainTxt.text = "";
        yield return new WaitForSeconds(1f);
        mainTxt.text = "Solar panels need to face the most direct sunlight.";
        yield return new WaitForSeconds(time);

        mainTxt.text = "The slider below will show you the sun's path throughout the day.";        
        yield return new WaitForSeconds(time);
        sunSlide.SetActive(true);

        mainTxt.text = "Which way should the solar panels face in order to get the most sunlight?";
        yield return new WaitForSeconds(time);
        directionBtns.SetActive(true);

    }

    public void chooseSouth()
    {
        directionBtns.SetActive(false);
        giveHint.SetActive(false);
        mainTxt.text = "Right! Most of the sunlight is from south!";
        StartCoroutine(choseSouth(waitTime));
    }

    public void chooseNotSouth()
    {
        
        trialNum++;
        StartCoroutine(choseNotSouth(waitTime));
    }

    private IEnumerator choseSouth(float time)
    {
        sunSlide.SetActive(false);
        yield return new WaitForSeconds(time);
        mainTxt.text = "";
        // hint 1 
        hint1.SetActive(true);
        yield return new WaitForSeconds(time);
        hint1.SetActive(false);
        // hint 2
        hint2.SetActive(true);
        yield return new WaitForSeconds(time);
        hint2.SetActive(false);
        // hint 3
        hint3.SetActive(true);
        mainTxt.text = "Therefore, the most direct sunlight comes from the South!";
        yield return new WaitForSeconds(time);
        hint3.SetActive(false);
        
        
        mainTxt.text = "";

        sunSlide.SetActive(false);
        topCam.SetActive(false);
        southCam.SetActive(true);
        yield return new WaitForSeconds(time);
    }

    private IEnumerator choseNotSouth(float time)
    {
        directionBtns.SetActive(false);
        // slider & txt off 
        mainTxt.text = "";
        sunSlide.SetActive(false);
        giveHint.SetActive(false);

        // show hint 1
        if (trialNum == 1)
        {

            mainTxt.text = "Mmm, not quite. Here's a hint";
            yield return new WaitForSeconds(time);
            mainTxt.text = "";

            hint1.SetActive(true);
            hint1btn.SetActive(true);
            yield return new WaitForSeconds(time);
            hint1.SetActive(false);
            hint1btn.SetActive(false);

            
            
        }
        // hint 2
        if (trialNum == 2)
        {

            mainTxt.text = "Mmm, not quite. Here's another hint";
            yield return new WaitForSeconds(time);
            mainTxt.text = "";

            hint2.SetActive(true);
            hint2btn.SetActive(true);
            yield return new WaitForSeconds(time);
            hint2.SetActive(false);
            hint2btn.SetActive(false);

           
        }
        //hint 3
        if (trialNum == 3)
        {
            mainTxt.text = "Mmm, not quite. Here's the final hint";
            yield return new WaitForSeconds(time);
            mainTxt.text = "";

            hint3.SetActive(true);
            hint3btn.SetActive(true);
            yield return new WaitForSeconds(time);
            hint3.SetActive(false);
            hint3btn.SetActive(false);

        }
        
        mainTxt.text = "Try again, which way should the solar panels face? Click the '?' to see the hint.";
        sunSlide.SetActive(true);
        giveHint.SetActive(true);
        directionBtns.SetActive(true);
    }

    public void giveHintPls()
    {
        if (trialNum == 1)
        {
            hint1.SetActive(true);
            hint1btn.SetActive(true);
            hint1btn.GetComponent<Button>().interactable = false;
            
        }
        if (trialNum == 2)
        {
            hint2.SetActive(true);
            hint1btn.SetActive(true);
            hint2btn.SetActive(true);
            hint2btn.GetComponent<Button>().interactable = false;
            hint1btn.GetComponent<Button>().interactable = true;
            
        }
        if (trialNum >= 3)
        {
            hint3.SetActive(true);
            hint1btn.SetActive(true);
            hint2btn.SetActive(true);
            hint3btn.SetActive(true);
            hint3btn.GetComponent<Button>().interactable = false;
            hint1btn.GetComponent<Button>().interactable = true;
            hint2btn.GetComponent<Button>().interactable = true;
        }
        hintX.SetActive(true);
        giveHint.SetActive(false);
    }

    public void showHint1()
    {
        hint1.SetActive(true);
        hint2.SetActive(false);
        hint3.SetActive(false);
        hint1btn.GetComponent<Button>().interactable = false;
        hint2btn.GetComponent<Button>().interactable = true;
        hint3btn.GetComponent<Button>().interactable = true;
    }

    public void showHint2()
    {
        hint2.SetActive(true);
        hint1.SetActive(false);
        hint3.SetActive(false);
        hint2btn.GetComponent<Button>().interactable = false;
        hint1btn.GetComponent<Button>().interactable = true;
        hint3btn.GetComponent<Button>().interactable = true;

    }
    public void showHint3()
    {
        hint3.SetActive(true);
        hint1.SetActive(false);
        hint2.SetActive(false);
        hint3btn.GetComponent<Button>().interactable = false;
        hint1btn.GetComponent<Button>().interactable = true;
        hint2btn.GetComponent<Button>().interactable = true;

    }
    public void closeHints()
    {
        hint1.SetActive(false);
        hint2.SetActive(false);
        hint3.SetActive(false);
        hint1btn.SetActive(false);
        hint2btn.SetActive(false);
        hint3btn.SetActive(false);
        hintX.SetActive(false);
        giveHint.SetActive(true);
    }
}
