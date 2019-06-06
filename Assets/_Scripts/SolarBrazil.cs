using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolarBrazil : MonoBehaviour {

    public Text mainTxt;
    
    public GameObject directionBtns;
    public GameObject hint1;
    public GameObject hint2;
    public GameObject hint3;
    public GameObject hint1btn;
    public GameObject hint2btn;
    public GameObject hint3btn;
    public GameObject hintX;
    public GameObject giveHint;
    


    public float waitTime = 3f;

    

    // Use this for initialization
    void Start()
    {
        
        directionBtns.SetActive(false);
        hint1.SetActive(false);
        hint2.SetActive(false);
        hint3.SetActive(false);
        hint1btn.SetActive(false);
        hint2btn.SetActive(false);
        hint3btn.SetActive(false);
        hintX.SetActive(false);
        giveHint.SetActive(false);
        

        
        StartCoroutine(startBrazil(waitTime));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator startBrazil(float time)
    {
        mainTxt.text = "";
        yield return new WaitForSeconds(.5f);
        mainTxt.text = "Wow you did such a good job with these solar panels!";
        yield return new WaitForSeconds(time);
        mainTxt.text = "Could you help me out too?";
        yield return new WaitForSeconds(time);

        // Hint 1
        mainTxt.text = "I'm going to be moving to Brazil.";
        hint1.SetActive(true);
        hint1btn.SetActive(true);
        yield return new WaitForSeconds(time);

        // Hint 2
        mainTxt.text = "I know that the equator is here.";
        hint2.SetActive(true);
        hint2btn.SetActive(true);
        yield return new WaitForSeconds(time);

        // Hint 3
        mainTxt.text = "And Rio De Jenario is here.";
        hint3.SetActive(true);
        hint3btn.SetActive(true);
        yield return new WaitForSeconds(time);

        

        mainTxt.text = "Which way should I point the solar panels to get the most sunlight?";
        directionBtns.SetActive(true);
        hint1.SetActive(false);
        hint2.SetActive(false);
        hint3.SetActive(false);
        hint1btn.SetActive(false);
        hint2btn.SetActive(false);
        hint3btn.SetActive(false);
        hintX.SetActive(false);
        giveHint.SetActive(true);
        yield return new WaitForSeconds(time);
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

    public void giveHintPls()
    {
        hint1.SetActive(true);
        hint1btn.SetActive(true);
        hint2btn.SetActive(true);
        hint3btn.SetActive(true);
        hint1btn.GetComponent<Button>().interactable = false;
        hint3btn.GetComponent<Button>().interactable = true;
        hint2btn.GetComponent<Button>().interactable = true;
        
        hintX.SetActive(true);
        giveHint.SetActive(false);
    }

    private IEnumerator choseNorth(float time)
    {
        

        mainTxt.text = "Yeah! That makes sense.";
        yield return new WaitForSeconds(time);
        mainTxt.text = "Since Rio is south of the equator, I should point the solar panels North!";
        hint3.SetActive(true);
        yield return new WaitForSeconds(time);
        mainTxt.text = "Thanks so much!";
        yield return new WaitForSeconds(time);
    }

    private IEnumerator choseNotNorth(float time)
    {
        

        mainTxt.text = "Mmm, I don't think that's right";
        yield return new WaitForSeconds(time);
        mainTxt.text = "Since Rio is south of the equator, I should point the solar panels North.";
        hint3.SetActive(true);
        yield return new WaitForSeconds(time);
        mainTxt.text = "Thanks anyways!";
        yield return new WaitForSeconds(time);
    }

    public void chooseNorth()
    {
        directionBtns.SetActive(false);
        closeHints();
        giveHint.SetActive(false);
        StartCoroutine(choseNorth(waitTime));
    }

    public void chooseNotNorth()
    {
        directionBtns.SetActive(false);
        closeHints();
        giveHint.SetActive(false);
        StartCoroutine(choseNotNorth(waitTime));
    }


}
