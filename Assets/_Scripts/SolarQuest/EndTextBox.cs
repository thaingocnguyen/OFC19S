using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolarQuest
{
    public class EndTextBox : InfoBox
    {
        [SerializeField] GameObject endContinueArrrow;
        [SerializeField] GameObject levelLoader;

        public override void LoadText()
        {
            endContinueArrrow.SetActive(true);
            base.LoadText();
        }

        public override void HandleNoSentencesLeft()
        {
            endContinueArrrow.SetActive(false);
            PlayerPrefs.SetInt("solarQuestTutorialPlayed", 1);
            levelLoader.GetComponent<LevelLoader>().LoadLevel(2);
        }
    }
}

