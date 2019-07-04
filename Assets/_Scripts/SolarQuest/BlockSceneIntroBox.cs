using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockSceneIntroBox : InfoBox, IPointerDownHandler
{
    [SerializeField] GameObject background;
    [SerializeField] GameObject character;
    [SerializeField] GameObject instructions;


    
    public override void HandleNoSentencesLeft()
    {
        gameObject.SetActive(false);
        character.SetActive(false);
        background.SetActive(false);
        BlockSceneManager.Instance.SetState(BlockSceneManager.GameState.SelectHouse);
    }

    private void Start()
    {
        
        sentences.Enqueue("Your neighbourhood has received a grant to fit <b>three</b>(3) houses with solar panels.");
        sentences.Enqueue("Your job is to select the best <b><u>three</u></b> houses to place solar panels on. Choose wisely, as you will only be able to do this once.");
        DisplayNextSentence();
        character.SetActive(true);
    }

    public override void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            HandleNoSentencesLeft();
            return;
        }

        string sentence = sentences.Dequeue();
        infoText.text = sentence;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        DisplayNextSentence();
    }
}

