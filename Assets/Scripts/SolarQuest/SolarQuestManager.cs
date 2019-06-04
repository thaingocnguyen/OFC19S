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

        tutorialManager.GetComponent<TutorialManager>().onSliderTutorialReached += Handle_OnSliderTutorialReached;
        tutorialManager.GetComponent<TutorialManager>().onTutorialEnd += Handle_OnTutorialEnd;
    }

    void Handle_OnSliderTutorialReached()
    {
        startCam.enabled = false;
        southCam.enabled = true;

        tutorialUI.SetActive(true);
        character.SetActive(false);

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

}
