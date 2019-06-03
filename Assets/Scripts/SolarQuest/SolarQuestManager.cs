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
    GameObject TutorialManager;

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
        SolarGame.SetActive(false);
        tutorialUI.SetActive(false);
        character.SetActive(false);

        TutorialManager.GetComponent<TextboxManager>().onTutorialEnd += Handle_OnTutorialEnd;


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
