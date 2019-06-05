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
    public TutorialDelegate onQuizStart;
    public TutorialDelegate onQuizEnd;

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

    [SerializeField]
    GameObject continueButton;

    private bool displayingSentence = false;
    private bool quizPlaying = false;

    public bool QuizPlaying
    {
        get { return quizPlaying; }
        set { quizPlaying = value; }
    }

    // Use this for initialization
    void Awake()
    {
        sentences = new Queue<string>();
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
        if (!displayingSentence)
        {
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        displayingSentence = true;
        continueButton.SetActive(false);
        infoText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            infoText.text += letter;
            yield return null;
        }
        if (quizPlaying)
        {
            continueButton.SetActive(false);
        }
        else
        {
            continueButton.SetActive(true);
        }        
        displayingSentence = false;
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

    // Triggered when player has finished reading instruction for slider tutorial
    public void SliderTutorialInstructionRead()
    {
        sliderTutorialAnimator.SetBool("displayInstruction", false);
        sliderTutorialAnimator.SetBool("instructionRead", true);
    }

    // Close slider tutorial and load the quiz 
    public void FinishSliderTutorial()
    {
        sliderTutorialDone = true;
        sliderTutorialAnimator.SetBool("finishSliderTutorial", true);
        LoadQuiz();
    }

    // Load quiz checking student's understanding on direction of the sun 
    private void LoadQuiz()
    {
        // Display tutorial pane on the screen
        quizPlaying = true;
        GetComponent<Animator>().SetBool("IsOnScreen", true);
        titleText.text = tutorialHolder.tutorialName;

        sentences.Clear();

        // Load in tutorial sentences
        foreach (string sentence in tutorialHolder.quizSentences)
        {
            sentences.Enqueue(sentence);
        }

        // Display the sentence
        DisplayNextSentence();
        character.SetActive(true);
        onQuizStart();
    }

    // Close tutorial pane
    private void EndTutorial()
    {
        GetComponent<Animator>().SetBool("IsOnScreen", false);
        onTutorialEnd();
    }

}
