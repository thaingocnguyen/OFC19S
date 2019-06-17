using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarQuestManager : MonoBehaviour
{
    public bool debugMode;
    [SerializeField]
    Camera startCam;
    [SerializeField]
    Camera questCam;
    [SerializeField]
    Camera southCam;

    [SerializeField]
    GameObject tutorialManager;
    [SerializeField]
    GameObject SolarGame;
    [SerializeField]
    GameObject tutorialUI;
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
        Tutorial,
        Quest
    }

    GameState currentState = GameState.Tutorial;

    private void Awake()
    {
        // Start out using tutorial camera 
        startCam.enabled = true;
        questCam.enabled = false;
        southCam.enabled = false;

        character.SetActive(false);

        // Set all final quest ui items to be inactive
        SolarGame.SetActive(false);
        budget.SetActive(false);
        energyBar.SetActive(false);

        // Set all quiz ui items to be inactive
        tutorialUI.SetActive(false);
        quizButtons.SetActive(false);
        SetStatusHintPanel(false);

        // Set up for delegates
        tutorialManager.GetComponent<TutorialManager>().onSliderTutorialReached += Handle_OnSliderTutorialReached;
        tutorialManager.GetComponent<TutorialManager>().onTutorialEnd += Handle_OnTutorialEnd;
        tutorialManager.GetComponent<TutorialManager>().onQuizStart += Handle_OnQuizStart;

        mainLight.enabled = true;
        sliderLight.enabled = false; 
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
            tutorialUI.SetActive(false);

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

        tutorialUI.SetActive(true);
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
}
