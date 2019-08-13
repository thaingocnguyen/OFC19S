using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class IntroductionCutscene : MonoBehaviour
{
    public bool debugMode;
    public float typeSpeed = 0.05f;

    public GameObject textboxRenee;
    public TextMeshProUGUI displayedTextRenee;
    public GameObject textboxTheresa;
    public TextMeshProUGUI displayedTextTheresa;

    private TextMeshProUGUI displayedText;

    public Queue<Dialogue> conversation;

    private bool displayingSentence;

    private void Awake()
    {
        conversation = new Queue<Dialogue>();
        conversation.Enqueue(new Dialogue("r", "Renee dialogue here"));
        conversation.Enqueue(new Dialogue("t", "Theresa dialogue here"));
        conversation.Enqueue(new Dialogue("r", "Renee dialogue here"));
        conversation.Enqueue(new Dialogue("t", "Theresa dialogue here"));
    }

    private void Start()
    {
        StartCutscene();
    }
    public void StartCutscene()
    {
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (!displayingSentence || debugMode)
        {
            if (conversation.Count == 0)
            {
                //HandleNoSentencesLeft();
                return;
            }

            Dialogue dialogue = conversation.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(dialogue.character, dialogue.text));
        }
    }

    IEnumerator TypeSentence(string character, string sentence)
    {
        displayingSentence = true;

        if (character.Equals("r"))
        {
            textboxRenee.SetActive(true);
            textboxTheresa.SetActive(false);
            displayedText = displayedTextRenee;
        }
        else
        {
            textboxRenee.SetActive(false);
            textboxTheresa.SetActive(true);
            displayedText = displayedTextTheresa;
        }

        displayedText.text = "";
        foreach (char letter in sentence)
        {
            displayedText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
        displayingSentence = false;
    }
}
