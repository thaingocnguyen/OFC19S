using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public abstract class InfoBox : MonoBehaviour
{

    [SerializeField] protected TextMeshProUGUI displayedText;
    protected Queue<string> sentences;

    [SerializeField] float typeSpeed = 0.05f;

    bool displayingSentence;
    [SerializeField] bool debugMode;


    private void Awake()
    {
        sentences = new Queue<string>();
    }

    protected void LoadText()
    {
        sentences.Clear();

        foreach (string sentence in sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (!displayingSentence || debugMode)
        {
            if (sentences.Count == 0)
            {
                HandleNoSentencesLeft();
                return;
            }

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        displayingSentence = true;
        displayedText.text = "";
        foreach (char letter in sentence)
        {
            displayedText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
        displayingSentence = false;
    }

    public abstract void HandleNoSentencesLeft();
}

