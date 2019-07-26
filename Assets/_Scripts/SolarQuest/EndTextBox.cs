using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolarQuest
{
    public class EndTextBox : SolarInfoBox
    {
        public GameObject tapToContinueText;
        [SerializeField] GameObject levelLoader;

        private void Start()
        {
            tapToContinueText.SetActive(false);
        }
        public override void LoadText()
        {
            sentences.Enqueue("In BC, you can choose to connect your solar panels to the electricity grid. Which means that if your solar panel produces more power than your household consumes, the surplus is fed back to the grid for others to use & obtain BC Grid Credits.");

            sentences.Enqueue("These credits can be used to reduce the price you pay for electricity on days where there isn't much sunlight. Doesn't that sound like a win-win situation!");

            sentences.Enqueue("So, seems like you're getting the hang of it! Let's now try retrofitting the whole street.");

            DisplayNextSentence();
        }


        public override void HandleNoSentencesLeft()
        {
            tapToContinueText.SetActive(false);
            PlayerPrefs.SetInt("solarQuestTutorialPlayed", 1);
            levelLoader.GetComponent<LevelLoader>().LoadLevel(2);
        }
    }
}

