using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UrbanForestryQuest
{
    public class EndBox : InfoBox
    {
        [SerializeField] GameObject buttons;
        [SerializeField] GameObject continueText;

        private void Start()
        {
            LoadText();
        }
        public override void HandleNoSentencesLeft()
        {
            continueText.SetActive(false);
            displayedText.text = "Would you like to continue or try this quest again?";

            buttons.SetActive(true);
        }
    }
}

