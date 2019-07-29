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

            CurrentState = GameState.Tutorial;
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
            PlantTrees,
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
                case GameState.PlantTrees:
                    HandlePlantTreesState_On();
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
                case GameState.PlantTrees:
                    HandlePlantTreesState_Off();
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

            tutorialCanvas.GetComponentInChildren<TutorialPopup>().InitializeTutorial();
        }

        private void HandleTutorialState_Off()
        {
            uiCanvas.SetActive(false);
            tutorialCanvas.SetActive(false);
        }
        #endregion

        #region PlantTrees
        private void HandlePlantTreesState_On()
        {
            uiCanvas.SetActive(true);
        }

        private void HandlePlantTreesState_Off()
        {
            uiCanvas.SetActive(false);
        }
        #endregion

        #region EndState

        [SerializeField] GameObject proceedButton;
        [SerializeField] GameObject scoreBox;
        TextMeshProUGUI scoreBoxText;
        [SerializeField] TextMeshProUGUI oopsText;

        public void SwitchToEndState()
        {
            int score = Mathf.RoundToInt(LevelManager.GetInstance().CanopyScore);
            
            if (score <= 15)
            {
                oopsText.text = "<b>Oops! You must play again.</b> You only achieved " + score + "% canopy cover for your block, which is only " + (score - 9) + "% more than what you started.";
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
           
            string endText = "";
            if (score > 15 && score < 22)
            {
                endText = "<b>You're almost there!</b> You achieved " + score + "% canopy cover for your block. You missed the City's target by " + (22 - score) + "%";
            }
            if (score >= 22 && score < 40)
            {
                endText = "<b>You did great!</b> You achieved " + score + "% canopy cover for your block. You surpassed the City's target by " + (score - 22) + "%";
            }
            else if (score >= 40)
            {
                endText = "<b>Wow! You’re a Champion!</b> You were able to not only exceed the City canopy target of 22% but are now the Greenest Block in Vancouver with 40% canopy cover!";
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


