using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolarQuest
{
    public class BlockSceneEndTextbox : SolarInfoBox
    {
        [SerializeField] GameObject tapToContinueText;
        [SerializeField] GameObject levelLoader;
        [SerializeField] GameObject endButtons;

        private void Start()
        {
            tapToContinueText.SetActive(false);
        }
        public override void HandleNoSentencesLeft()
        {
            tapToContinueText.SetActive(false);
            levelLoader.GetComponent<LevelLoader>().LoadLevel(0);
        }

        public override void LoadText()
        {
            sentences.Enqueue("Ending text here. Deepti will provide the text.");

            tapToContinueText.SetActive(true);
            endButtons.SetActive(false);

            DisplayNextSentence();
        }
    }

}
