using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace UrbanForestryQuest
{
    public abstract class InfoBox : MonoBehaviour
    {

        [SerializeField] List<string> infoText;
        [SerializeField] protected TextMeshProUGUI displayedText;
        private Queue<string> sentences;


        private void Awake()
        {
            sentences = new Queue<string>();
        }

        private void Start()
        {
            LoadText();
        }

        private void LoadText()
        {
            sentences.Clear();

            foreach (string sentence in infoText)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            if (sentences.Count == 0)
            {
				HandleNoSentencesLeft();
                return;
            }

            displayedText.text = sentences.Dequeue();
        }

		public abstract void HandleNoSentencesLeft();
    }

}
