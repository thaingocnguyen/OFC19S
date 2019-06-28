using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SolarQuestTutorialManager : MonoBehaviour
{

    #region Cameras
    [SerializeField] Camera startCam;
    [SerializeField] Camera questCam;
    [SerializeField] Camera southCam;
	#endregion

	public float score;
    [SerializeField] GameObject character;

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
    [SerializeField] GameObject quizDoneButton;

    // SOLAR GAME
    [SerializeField] GameObject solarGame;
	[SerializeField] GameObject solarGameDoneButton;
    [SerializeField] GameObject budget;
    [SerializeField] GameObject energyBar;
    [SerializeField] GameObject introBox;
    [SerializeField] GameObject solarPanelsPopup;

	// END
	[SerializeField] GameObject endTextBox;
	[SerializeField] TextMeshProUGUI endText;
	[SerializeField] GameObject choiceButtons;

	// Lights
	[SerializeField] Light mainLight;
    [SerializeField] Light sliderLight;



    public enum GameState
    {
        Start,
        Introduction,
        SliderTutorial,
        Quiz,
        SolarGame,
        End
    }

    private GameState currentState;

    private void Start()
    {
        character.SetActive(false);

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

        // SOLAR GAME
        solarGame.SetActive(false);
        budget.SetActive(false);
        energyBar.SetActive(false);
        introBox.SetActive(false);
        solarPanelsPopup.SetActive(false);
		solarGameDoneButton.SetActive(false);

		// END
		endTextBox.SetActive(false);
		choiceButtons.SetActive(false);

        // Set start state
        SetState(GameState.Start);
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

    public void ChangeStateToSolarGame()
    {
        SetState(GameState.SolarGame);
    }

    public void ChangeStateToEnd()
	{
        SetState(GameState.End);
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
            case GameState.SolarGame:
                SolarGameState();
                break;
			case GameState.End:
				EndState();
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
            case GameState.SolarGame:
                ExitSolarGameState();
                break;
			case GameState.End:
				ExitEndState();
				break;
            default:
                break;
        }
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

        character.SetActive(true);

        infoBox.SetActive(true);
        infoBox.GetComponent<InfoBox>().LoadText();
    }

    private void ExitIntroductionState()
    {
        character.SetActive(false);
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

        character.SetActive(true);
    }

    private void ExitQuizState()
    {
        quizPanel.SetActive(false);
        backButton.SetActive(false);

        character.SetActive(false);
    }

    private void SolarGameState()
    {
        startCam.enabled = false;
        questCam.enabled = true;
        southCam.enabled = false;

        energyBar.SetActive(true);
        budget.SetActive(true);
        introBox.SetActive(true);
        solarGame.SetActive(true);
		solarGameDoneButton.SetActive(true);
    }

    public void CloseIntroBox()
    {
        introBox.SetActive(false);
        solarPanelsPopup.SetActive(true);
    }

    public void CloseSolarPanelsPopup()
    {
        solarPanelsPopup.SetActive(false);
    }

    private void ExitSolarGameState()
    {
        if (SolarScoring.Instance)
		{
			score = SolarScoring.Instance.energyScore;
		}
		introBox.SetActive(false);
		energyBar.SetActive(false);
		budget.SetActive(false);
		solarGame.SetActive(false);
		solarGameDoneButton.SetActive(false);
		solarPanelsPopup.SetActive(false);
        if (SolarGamePopupManager.Instance)
		{
			SolarGamePopupManager.Instance.CloseAllPopups();
		}
	}

    private void EndState()
	{
		startCam.enabled = false;
		questCam.enabled = true;
		southCam.enabled = false;

        character.SetActive(true);
		endTextBox.SetActive(true);

		choiceButtons.SetActive(true);
		endText.text = "Congratulations! Your score was " + (score * 100) + "%. Would you like to try again or continue?";
	}

    private void ExitEndState()
	{
		choiceButtons.SetActive(false);
		endTextBox.SetActive(false);
        character.SetActive(false);
	}

    public void LoadEndText()
	{
		choiceButtons.SetActive(false);
		endTextBox.GetComponent<InfoBox>().LoadText();
	}


}
