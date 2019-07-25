using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UrbanForestryQuest
{
    public class UrbanForestryQuestManager : MonoBehaviour
    {
        [SerializeField] GameObject introCanvas;
        [SerializeField] GameObject uiCanvas;
        [SerializeField] GameObject tutorialCanvas;
        [SerializeField] GameObject endCanvas;

        [SerializeField] GameObject oops;
        [SerializeField] GameObject endCharacter;
        [SerializeField] GameObject endTextbox;

        [SerializeField] GameObject levelCreatorScript;

        private GameState currentState;

        public GameState CurrentState
        {
            get { return currentState; }
            set
            {
                ClearOldState(currentState);
                currentState = value;
                SetState(currentState);
            }
        }

        #region Singleton
        private static UrbanForestryQuestManager instance = null;
        public static UrbanForestryQuestManager GetInstance()
        {
            return instance;
        }

        private void Awake()
        {
            instance = this;
        }
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            QuestInitialSetUp();

            CurrentState = GameState.Introduction;
        }

        private void QuestInitialSetUp()
        {
            oops.SetActive(false);
            endCharacter.SetActive(false);
            endTextbox.SetActive(false);

            introCanvas.SetActive(false);
            uiCanvas.SetActive(false);
            tutorialCanvas.SetActive(false);
            endCanvas.SetActive(false);
        }

        public enum GameState
        {
            Introduction,
            Tutorial,
            End
        }

        private void SetState(GameState newState)
        {
            
            switch (newState)
            {
                case GameState.Introduction:
                    HandleIntroductionState_On();
                    break;
                case GameState.Tutorial:
                    HandleTutorialState_On();
                    break;
                case GameState.End:
                    HandleEndState_On();
                    break;
                default:
                    break;
            }
        }

        private void ClearOldState(GameState oldState)
        {
            switch (oldState)
            {
                case GameState.Introduction:
                    HandleIntroductionState_Off();
                    break;
                case GameState.Tutorial:
                    HandleTutorialState_Off();
                    break;
                case GameState.End:
                    HandleEndState_Off();
                    break;
                default:
                    break;
            }
        }

        #region IntroductionState
        private void HandleIntroductionState_On()
        {
            introCanvas.SetActive(true);
        }

        private void HandleIntroductionState_Off()
        {
            introCanvas.SetActive(false);
        }
        #endregion

        #region TutorialState
        private void HandleTutorialState_On()
        {
            uiCanvas.SetActive(true);
            tutorialCanvas.SetActive(true);
        }

        private void HandleTutorialState_Off()
        {
            uiCanvas.SetActive(false);
            tutorialCanvas.SetActive(false);
        }
        #endregion

        #region EndState
        
        [SerializeField] GameObject proceedButton;
        [SerializeField] GameObject scoreBox;
        TextMeshProUGUI scoreBoxText;

        public void SwitchToEndState()
        {
            if (Mathf.RoundToInt(LevelManager.GetInstance().CanopyScore) == 0)
            {
                oops.SetActive(true);
            }
            else
            {
                levelCreatorScript.GetComponent<LevelCreator>().CloseAllModes();
                CurrentState = GameState.End;
            }
        }

        public void CloseOops()
        {
            oops.SetActive(false);
        }

        private void HandleEndState_On()
        {
            endCanvas.SetActive(true);
            scoreBox.SetActive(true);
            proceedButton.SetActive(true);

            scoreBoxText = scoreBox.GetComponentInChildren<TextMeshProUGUI>();
            int canopyScore = Mathf.RoundToInt(LevelManager.GetInstance().CanopyScore);
            scoreBoxText.text = GetEndText(canopyScore);
            
            LevelManager.GetInstance().VisualizeFuture();
        }

        private void HandleEndState_Off()
        {

        }

        private string GetEndText(int score)
        {
            string endText = "<b>Congratulations!</b> You achieved <i>" + score + "%</i> canopy coverage for the block. ";
            if (score > 10 && score < 22)
            {
                endText += "You're just shy <i>" + (22 - score) + "%</i> of the city target for canopy coverage.";
            }
            else if (score >= 22)
            {
                endText += "You exceeded the city target for canopy coverage by <i>" + (score - 22) + "%.</i> Great job!";
            }

            return endText;
        }

        public void CloseScoreBox()
        {
            scoreBox.SetActive(false);
        }

        public void ProceedToEndText()
        {
            proceedButton.SetActive(false);
            scoreBox.SetActive(false);

            endCharacter.SetActive(true);
            endTextbox.SetActive(true);
        }
        #endregion
    }
}


