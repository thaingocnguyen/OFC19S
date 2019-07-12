using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SolarQuest
{
    public class BlockSceneIntroBox : InfoBox, IPointerDownHandler
    {
        [SerializeField] GameObject background;
        [SerializeField] GameObject character;
        [SerializeField] GameObject instructions;



        public override void HandleNoSentencesLeft()
        {
            gameObject.SetActive(false);
            character.SetActive(false);
            background.SetActive(false);
            BlockSceneManager.Instance.SetState(BlockSceneManager.GameState.SelectHouse);
        }

        private void Start()
        {

            sentences.Enqueue("Your neighbourhood has received a grant of $100,000 to retrofit <b>three</b>(3) houses with solar panels.");
            sentences.Enqueue("The Quest is to select the best <b>3</b> houses & place solar panels that will yield/generate the maximum solar energy for the whole street. Chose wisely, as you will only be able to do this once.");
            DisplayNextSentence();
            character.SetActive(true);
        }

        public override void DisplayNextSentence()
        {
            if (sentences.Count == 0)
            {
                HandleNoSentencesLeft();
                return;
            }

            string sentence = sentences.Dequeue();
            infoText.text = sentence;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            DisplayNextSentence();
        }
    }

}

