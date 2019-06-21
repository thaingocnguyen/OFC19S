using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarQuestTutorialManager : MonoBehaviour
{
    public bool debugMode;

    #region Cameras
    [SerializeField] Camera startCam;
    [SerializeField] Camera questCam;
    [SerializeField] Camera southCam;
    #endregion

    // START
    [SerializeField] GameObject startButton;

    // INTRODUCTION
    [SerializeField] GameObject infoBox;

    // SLIDER
    [SerializeField] GameObject sliderUI;
    [SerializeField] GameObject sliderPopup;
    [SerializeField] GameObject compassPopup;
    [SerializeField] GameObject sliderDoneButton;

    // QUIZ
    [SerializeField] GameObject quizPanel;
    [SerializeField] GameObject backButton;


    [SerializeField]
    GameObject tutorialManager;
    [SerializeField]
    GameObject SolarGame;

    [SerializeField]
    GameObject character;
    [SerializeField]
    GameObject quizButtons;
    [SerializeField]
    GameObject energyBar;
    [SerializeField]
    GameObject budget;

    [SerializeField] Light mainLight;
    [SerializeField] Light sliderLight;



    #region HintPanel
    [SerializeField] GameObject hint1;
    [SerializeField] GameObject hint2;
    [SerializeField] GameObject hint3;
    [SerializeField] GameObject hint1Button;
    [SerializeField] GameObject hint2Button;
    [SerializeField] GameObject hint3Button;
    [SerializeField] GameObject closeHintButton;
    [SerializeField] GameObject giveHintButton;
    #endregion

    enum GameState
    {
        Start,
        Introduction,
        SliderTutorial,
        Quiz,
        Tutorial,
        Quest
    }

    private GameState currentState = GameState.Start;


    //private void Awake()
    //{
    //    // Start out using tutorial camera 
    //    startCam.enabled = true;
    //    questCam.enabled = false;
    //    southCam.enabled = false;

    //    character.SetActive(false);

    //    // Set all final quest ui items to be inactive
    //    SolarGame.SetActive(false);
    //    budget.SetActive(false);
    //    energyBar.SetActive(false);

    //    // Set all quiz ui items to be inactive
    //    tutorialUI.SetActive(false);
    //    quizButtons.SetActive(false);
    //    SetStatusHintPanel(false);

    //    // Set up for delegates
    //    tutorialManager.GetComponent<TutorialManager>().onSliderTutorialReached += Handle_OnSliderTutorialReached;
    //    tutorialManager.GetComponent<TutorialManager>().onTutorialEnd += Handle_OnTutorialEnd;
    //    tutorialManager.GetComponent<TutorialManager>().onQuizStart += Handle_OnQuizStart;

    //    mainLight.enabled = true;
    //    sliderLight.enabled = false; 
    //}

    private void Start()
    {
        // Start out using tutorial camera
        startCam.enabled = true;
        questCam.enabled = false;
        southCam.enabled = false;

        // Light set up
        mainLight.enabled = true;
        sliderLight.enabled = false;

        // INTRODUCTION
        infoBox.SetActive(false);

        // SLIDER TUTORIAL
        sliderUI.SetActive(false);
        sliderPopup.SetActive(false);
        compassPopup.SetActive(false);
        sliderDoneButton.SetActive(false);

        // QUIZ
        quizPanel.SetActive(false);
        backButton.SetActive(false);

        // Set start state
        SetState(GameState.Quiz);
    }

    private void Update()
    {
    }

    public void ChangeStateToIntroduction()
    {
        SetState(GameState.Introduction);
    }

    public void ChangeStateToSliderTutorial()
    {
        SetState(GameState.SliderTutorial);
    }

    public void ChangeStateToQuiz()
    {
        SetState(GameState.Quiz);
    }

    private void SetState(GameState newState)
    {
        ExitCurrentState();
        currentState = newState;
        switch(currentState)
        {
            case GameState.Start:
                StartState();
                break;
            case GameState.Introduction:
                IntroductionState();
                break;
            case GameState.SliderTutorial:
                SliderTutorial();
                break;
            case GameState.Quiz:
                QuizState();
                break;
            default:
                break;
        }
    }

    private void ExitCurrentState()
    {
        switch(currentState)
        {
            case GameState.Start:
                ExitStartState();
                break;
            case GameState.Introduction:
                ExitIntroductionState();
                break;
            case GameState.SliderTutorial:
                ExitSliderTutorialState();
                break;
            case GameState.Quiz:
                ExitQuizState();
                break;
            default:
                break;
        }
    }


    void Handle_OnTutorialEnd()
    {
        if (currentState == GameState.Tutorial)
        {
            currentState = GameState.Quest;

            // Switch cameras
            startCam.enabled = false;
            southCam.enabled = false;
            questCam.enabled = true;

            // Remove character from screen
            character.SetActive(false);
            sliderUI.SetActive(false);

            // Set solar game ui items for be active
            energyBar.SetActive(true);
            budget.SetActive(true);
            SolarGame.SetActive(true);

            mainLight.enabled = true;
            sliderLight.enabled = false;
        }
    }



    public void SkipDebug()
    {
        Handle_OnTutorialEnd();
    }

    void Handle_OnSliderTutorialReached()
    {
        startCam.enabled = false;
        southCam.enabled = true;

        sliderUI.SetActive(true);
        character.SetActive(false);

        mainLight.enabled = false;
        sliderLight.enabled = true;
    }


    void Handle_OnQuizStart()
    {
        quizButtons.SetActive(true);
        SetStatusHintPanel(false);

    }


    private void SetStatusHintPanel(bool status)
    {
        hint1.SetActive(status);
        hint2.SetActive(status);
        hint3.SetActive(status);
        hint1Button.SetActive(status);
        hint2Button.SetActive(status);
        hint3Button.SetActive(status);
        closeHintButton.SetActive(status);
        giveHintButton.SetActive(status);
    }

    // State at the start with only start button
    private void StartState()
    {
        // Set up cameras
        startCam.enabled = true;
        questCam.enabled = false;
        southCam.enabled = false;

        startButton.SetActive(true);
    }

    private void ExitStartState()
    {
        startButton.SetActive(false);
    }

    private void IntroductionState()
    {
        // Set up cameras
        startCam.enabled = true;
        questCam.enabled = false;
        southCam.enabled = false;

        infoBox.SetActive(true);
        infoBox.GetComponent<InfoBox>().LoadText();
    }

    private void ExitIntroductionState()
    {
        infoBox.SetActive(false);
    }

    private void SliderTutorial()
    {
        startCam.enabled = false;
        questCam.enabled = false;
        southCam.enabled = true;

        sliderUI.SetActive(true);

        mainLight.enabled = false;
        sliderLight.enabled = true;

        sliderPopup.SetActive(true);
    }

    public void CloseSliderPopUp()
    {
        sliderPopup.SetActive(false);
        compassPopup.SetActive(true);
    }

    public void CloseCompassPopUp()
    {
        compassPopup.SetActive(false);
        sliderDoneButton.SetActive(true);
    }

    private void ExitSliderTutorialState()
    {
        sliderUI.SetActive(false);
        sliderDoneButton.SetActive(false);

        mainLight.enabled = true;
        sliderLight.enabled = false;
    }

    private void QuizState()
    {
        startCam.enabled = false;
        questCam.enabled = false;
        southCam.enabled = true;

        quizPanel.SetActive(true);
        backButton.SetActive(true);
    }

    private void ExitQuizState()
    {
        quizPanel.SetActive(false);
        backButton.SetActive(false);
    }

}
