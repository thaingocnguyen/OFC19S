using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

    public delegate void TutorialDelegate();
    public TutorialDelegate onTutorialEnd;
    public TutorialDelegate onSliderTutorialReached;

    public Text titleText;
    public Text infoText;

    private Queue<string> sentences;

    private bool sliderTutorialDone = false;

    [SerializeField]
    GameObject character;

    [SerializeField]
    Animator sliderTutorialAnimator;

    [SerializeField]
    Tutorial tutorialHolder;

    // Use this for initialization
    void Awake()
    {
        sentences = new Queue<string>();
    }

    private void Start()
    {
    }

    public void StartTutorial(Tutorial tutorial)
    {
        // Display tutorial panel
        GetComponent<Animator>().SetBool("IsOnScreen", true);
        titleText.text = tutorial.tutorialName;

        sentences.Clear();

        foreach (string sentence in tutorial.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        character.SetActive(true);
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            ProcessNextTutorial();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        infoText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            infoText.text += letter;
            yield return null;
        }
    }

    private void ProcessNextTutorial()
    {
        if(!sliderTutorialDone)
        {
            GetComponent<Animator>().SetBool("IsOnScreen", false);
            sliderTutorialAnimator.SetBool("displayInstruction", true);
            onSliderTutorialReached();
        }
        else
        {
            EndTutorial();
        }
    }

    public void SliderTutorialInstructionRead()
    {
        sliderTutorialAnimator.SetBool("displayInstruction", false);
        sliderTutorialAnimator.SetBool("instructionRead", true);
    }

    public void FinishSliderTutorial()
    {
        sliderTutorialDone = true;
        sliderTutorialAnimator.SetBool("finishSliderTutorial", true);
        LoadQuiz();
    }

    private void LoadQuiz()
    {
        GetComponent<Animator>().SetBool("IsOnScreen", true);
        titleText.text = tutorialHolder.tutorialName;

        sentences.Clear();

        foreach (string sentence in tutorialHolder.quizSentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        character.SetActive(true);
    }

    private void EndTutorial()
    {
        GetComponent<Animator>().SetBool("IsOnScreen", false);
        onTutorialEnd();
    }

}
