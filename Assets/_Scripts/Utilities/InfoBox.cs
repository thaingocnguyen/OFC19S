using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] InfoContainer infoContainer;

    private Queue<string> sentences;


    private void Awake()
    {
        sentences = new Queue<string>();
    }

    public void LoadText()
    {
        sentences.Clear();

        foreach (string sentence in infoContainer.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
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
}
