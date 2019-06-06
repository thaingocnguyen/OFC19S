using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SolarQuestQuiz : MonoBehaviour
{

    public Text mainText;
    public GameObject quizButtons;
    public GameObject hint1;
    public GameObject hint2;
    public GameObject hint3;
    public GameObject hint1btn;
    public GameObject hint2btn;
    public GameObject hint3btn;
    public GameObject hintX;
    public GameObject giveHint;

    public GameObject continueButton;


    public float waitTime = 3f;

    private int trialNum = 0;


    public void InitializeSolarQuest()
    {
        quizButtons.SetActive(true);
    }

  

    public void chooseSouth()
    {
        quizButtons.SetActive(false);
        giveHint.SetActive(false);
        mainText.text = "Right! Most of the sunlight is from south!";
        StartCoroutine(choseSouth(waitTime));
    }

    private IEnumerator choseSouth(float time)
    {
        yield return new WaitForSeconds(time);
        mainText.text = "";
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
        mainText.text = "Therefore, the most direct sunlight comes from the South!";
        yield return new WaitForSeconds(time);
        hint3.SetActive(false);
        mainText.text = "Now, let's start placing solar panels!";

        // Reenable continue button again
        continueButton.SetActive(true);
        GameObject.Find("TutorialManager").GetComponent<TutorialManager>().QuizPlaying = false;
        yield return new WaitForSeconds(time);
    }

    public void chooseNotSouth()
    {

        trialNum++;
        StartCoroutine(choseNotSouth(waitTime));
    }

   

    private IEnumerator choseNotSouth(float time)
    {
        quizButtons.SetActive(false);
        // slider & txt off 
        mainText.text = "";
        giveHint.SetActive(false);

        // show hint 1
        if (trialNum == 1)
        {

            mainText.text = "Mmm, not quite. Here's a hint";
            yield return new WaitForSeconds(time);
            mainText.text = "";

            hint1.SetActive(true);
            hint1btn.SetActive(true);
            yield return new WaitForSeconds(time);
            hint1.SetActive(false);
            hint1btn.SetActive(false);



        }
        // hint 2
        if (trialNum == 2)
        {

            mainText.text = "Mmm, not quite. Here's another hint";
            yield return new WaitForSeconds(time);
            mainText.text = "";

            hint2.SetActive(true);
            hint2btn.SetActive(true);
            yield return new WaitForSeconds(time);
            hint2.SetActive(false);
            hint2btn.SetActive(false);


        }
        //hint 3
        if (trialNum == 3)
        {
            mainText.text = "Mmm, not quite. Here's the final hint";
            yield return new WaitForSeconds(time);
            mainText.text = "";

            hint3.SetActive(true);
            hint3btn.SetActive(true);
            yield return new WaitForSeconds(time);
            hint3.SetActive(false);
            hint3btn.SetActive(false);

        }

        mainText.text = "Try again, which way should the solar panels face? Click the '?' to see the hint.";
        giveHint.SetActive(true);
        quizButtons.SetActive(true);
    }

    public void RequestHint()
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
