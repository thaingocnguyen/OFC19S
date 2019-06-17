using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{

    public delegate void TutorialDelegate();
    public TutorialDelegate onTutorialEnd;
    public TutorialDelegate onSliderTutorialReached;
    public TutorialDelegate onQuizStart;
    public TutorialDelegate onQuizEnd;

    public Text titleText;
    public Text infoText;

    public LevelLoader levelLoader;

    private Queue<string> sentences;

    private bool sliderTutorialDone = false;

    [SerializeField] GameObject character;
    [SerializeField] Animator sliderTutorialAnimator;
    [SerializeField] Animator solarGameHelpTextAnimator;
    [SerializeField] Tutorial tutorialHolder;
    [SerializeField] GameObject continueButton;


    private bool displayingSentence = false;
    private bool quizPlaying = false;
    private bool questEnd = false;

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

    private void Start()
    {
        levelLoader = GetComponent<LevelLoader>();
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

    public void EndQuest()
    {
        GetComponent<Animator>().SetBool("IsOnScreen", true);

        titleText.text = tutorialHolder.tutorialName;

        sentences.Clear();

        string[] endingSentences = {
        "Congratulations! Your energy score is: " + SolarScoring.Instance.energyScore,
        "In BC, you can choose to connect your solar panels to the electricity grid. If your solar panel produces more power than your household consumes, the surplus is fed into the grid for others to use. In BC, you can obtain BC Grid Credits by doing so. You can use BC Grid Credits to reduce the price you pay for electricity  on the days where there is not as much sunlight. Sounds like a win-win situation!",
        "Now, let's try retrofitting an entire block with solar panels! Remember what you've learnt about roof direction and be mindful of the budget vs. energy tradeoffs."
        };

        foreach (string sentence in endingSentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        character.SetActive(true);
    }

    private void ProcessNextTutorial()
    {
        if(!sliderTutorialDone)
        {
            GetComponent<Animator>().SetBool("IsOnScreen", false);
            sliderTutorialAnimator.SetBool("displayInstruction", true);
            onSliderTutorialReached();
        }
        else if(!questEnd)
        {
            EndTutorial();
        }
        else
        {
            levelLoader.LoadLevel(2);
        }
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

    public void SolarQuestInstructionsRead()
    {
        solarGameHelpTextAnimator.SetBool("instructionsRead", true);
        solarGameHelpTextAnimator.SetBool("instructionsOnScreen", false);

    }

    public void SolarQuestDone()
    {
        solarGameHelpTextAnimator.SetBool("instructionsRead", false);
        solarGameHelpTextAnimator.SetBool("solarQuestDone", true);
        questEnd = true;
        EndQuest();
    }


    // Close tutorial pane
    private void EndTutorial()
    {
        GetComponent<Animator>().SetBool("IsOnScreen", false);
        solarGameHelpTextAnimator.SetBool("instructionsOnScreen", true);
        onTutorialEnd();
    }

}
