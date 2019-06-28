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
        instructions.SetActive(true);
    }

    private void Start()
    {
        LoadText();
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

