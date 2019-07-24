using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UrbanForestryQuest
{
    public class EndBox : InfoBox
    {
        [SerializeField] GameObject buttons;
        [SerializeField] GameObject continueText;

        public override void HandleNoSentencesLeft()
        {
            continueText.SetActive(false);
            displayedText.text = "Would you like to continue or try this quest again?";

            buttons.SetActive(true);
        }
    }
}

