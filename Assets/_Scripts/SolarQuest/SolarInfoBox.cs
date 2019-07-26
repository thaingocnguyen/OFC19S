using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace SolarQuest
{
    public abstract class SolarInfoBox : MonoBehaviour
    {

        [SerializeField] protected TextMeshProUGUI displayedText;
        protected Queue<string> sentences;

        [SerializeField] float typeSpeed = 0.05f;

        bool displayingSentence = false;
        [SerializeField] bool debugMode;


        private void Awake()
        {
            sentences = new Queue<string>();
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

        public abstract void LoadText();
        public abstract void HandleNoSentencesLeft();
    }
}


