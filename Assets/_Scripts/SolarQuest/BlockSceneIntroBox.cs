using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SolarQuest
{
    public class BlockSceneIntroBox : SolarInfoBox
    {
        [SerializeField] GameObject background;
        [SerializeField] GameObject character;

        public override void LoadText()
        {
            sentences.Enqueue("Your neighbourhood has received a grant of $100,000 to retrofit three(3) houses with solar panels.");
            sentences.Enqueue("The Quest is to select the best 3 houses & place solar panels that will yield/generate the maximum solar energy for the whole street. Choose wisely, as you will only be able to do this once.");
            DisplayNextSentence();
            character.SetActive(true);
        }

        public override void HandleNoSentencesLeft()
        {
            gameObject.SetActive(false);
            character.SetActive(false);
            background.SetActive(false);
            BlockSceneManager.GetInstance().CurrentState = BlockSceneManager.GameState.SelectHouse;
        }
    }

}

 