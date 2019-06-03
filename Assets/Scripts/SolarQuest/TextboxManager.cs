using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxManager : MonoBehaviour
{

    public delegate void TutorialDelegate();
    public TutorialDelegate onTutorialEnd;

    public Text titleText;
    public Text infoText;

    private Queue<string> sentences;

    [SerializeField]
    GameObject character;

    // Use this for initialization
    void Awake()
    {
        sentences = new Queue<string>();
    }

    public void StartTutorial(Tutorial tutorial)
    {
        GetComponent<Animator>().SetBool("IsOnScreen", true);
        titleText.text = tutorial.tutorialName;

        sentences.Clear();

        foreach (string sentence in tutorial.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        character.SetActive(true);
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
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

    void EndDialogue()
    {
        GetComponent<Animator>().SetBool("IsOnScreen", false);
        onTutorialEnd();
    }

}
