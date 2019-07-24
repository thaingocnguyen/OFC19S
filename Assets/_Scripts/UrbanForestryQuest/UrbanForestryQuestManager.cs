using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrbanForestryQuestManager : MonoBehaviour
{
    [SerializeField] GameObject introCanvas;
    [SerializeField] GameObject uiCanvas;

    private GameState currentState;

    public GameState CurrentState
    {
        get { return currentState; }
        set
        {
            ClearOldState(currentState);
            currentState = value;
            SetState(currentState);
        }
    }

    #region Singleton
    private static UrbanForestryQuestManager instance = null;
    public static UrbanForestryQuestManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        QuestInitialSetUp();

        CurrentState = GameState.Introduction;
    }

    private void QuestInitialSetUp()
    {
        introCanvas.SetActive(false);
        uiCanvas.SetActive(false);
    }

    public enum GameState
    {
        Introduction,
        Tutorial
    }

    private void SetState(GameState newState)
    {
        switch(newState)
        {
            case GameState.Introduction:
                HandleIntroductionState_On();
                break;
            case GameState.Tutorial:
                HandleTutorialState_On();
                break;
            default:
                break;
        }
    }

    private void ClearOldState(GameState oldState)
    {
        switch(oldState)
        {
            case GameState.Introduction:
                HandleIntroductionState_Off();
                break;
            default:
                break;
        }
    }

    #region IntroductionState
    private void HandleIntroductionState_On()
    {
        introCanvas.SetActive(true);
    }

    private void HandleIntroductionState_Off()
    {
        introCanvas.SetActive(false);
    }
    #endregion

    #region TutorialState
    private void HandleTutorialState_On()
    {
        uiCanvas.SetActive(true);
    }

    private void HandleTutorialState_Off()
    {

    }
    #endregion



}
