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

        TutorialManager.GetComponent<TextboxManager>().onTutorialEnd += Handle_OnTutorialEnd;


    }

    // Update is called once per frame
    void Update()
    {
    }

    void Handle_OnTutorialEnd()
    {
        if (currentState == GameState.Tutorial)
        {
            currentState = GameState.Quest;
            startCam.enabled = false;
            questCam.enabled = true;
        }
    }

}
