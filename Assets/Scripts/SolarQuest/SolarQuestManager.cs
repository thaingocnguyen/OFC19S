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

    void Start()
    {
        // Start out using tutorial camera 
        startCam.enabled = true;
        questCam.enabled = false;
        southCam.enabled = false;
        SolarGame.SetActive(false);
        tutorialUI.SetActive(false);
        character.SetActive(false);
        quizButtons.SetActive(false);
        SetStatusHintPanel(false);

        tutorialManager.GetComponent<TutorialManager>().onSliderTutorialReached += Handle_OnSliderTutorialReached;
        tutorialManager.GetComponent<TutorialManager>().onTutorialEnd += Handle_OnTutorialEnd;
        tutorialManager.GetComponent<TutorialManager>().onQuizStart += Handle_OnQuizStart;;
    }

    void Handle_OnTutorialEnd()
    {
        if (currentState == GameState.Tutorial)
        {
            currentState = GameState.Quest;
            startCam.enabled = false;
            questCam.enabled = true;

            SolarGame.SetActive(true);
        }
    }

    void Handle_OnSliderTutorialReached()
    {
        startCam.enabled = false;
        southCam.enabled = true;

        tutorialUI.SetActive(true);
        character.SetActive(false);
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
