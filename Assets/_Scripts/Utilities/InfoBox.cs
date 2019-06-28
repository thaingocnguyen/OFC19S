using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class InfoBox : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI infoText;
    [SerializeField] protected InfoContainer infoContainer;

    

    protected Queue<string> sentences;


    private void Awake()
    {
        sentences = new Queue<string>();
    }

    public virtual void LoadText()
    {
        sentences.Clear();

        foreach (string sentence in infoContainer.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public virtual void DisplayNextSentence()
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

    IEnumerator TypeSentence(string sentence)
    {
        infoText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            infoText.text += letter;
            yield return null;
        }
    }

   public abstract void HandleNoSentencesLeft();
}
