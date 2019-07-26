using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

namespace SolarQuest
{
    public class BlockSceneManager : MonoBehaviour
    {

        #region Singleton
        private static BlockSceneManager instance = null;
        public static BlockSceneManager GetInstance()
        {
            return instance;
        }

        private void Awake()
        {
            GetComponent<HouseSelector>().oHouseSelected += DecrementHousesLeft;
            instance = this;
        }
        #endregion

        [SerializeField] Camera mainCamera;
        [SerializeField] Camera[] houseCameras;

        // INTRODUCTION
        [SerializeField] GameObject introductionCanvas;
        [SerializeField] GameObject introductionTextbox;

        // INSTRUCTIONS
        [SerializeField] GameObject instructionCanvas;
        [SerializeField] GameObject instructionIcon;

        // SOLAR GAME
        [SerializeField] GameObject mainCanvas;
        [SerializeField] GameObject solarGameCanvas;
        [SerializeField] GameObject energyBar;
        [SerializeField] GameObject budget;
        [SerializeField] GameObject compass;
        [SerializeField] GameObject doneButton;
        [SerializeField] GameObject arrowInstructions;

        [SerializeField] GameObject firstHouse;
        private bool firstHousePopUpShown = false;

        // HOUSES 
        public int housesLeft = 3;
        [SerializeField] GameObject housesLeftUI;
        [SerializeField] TextMeshProUGUI housesLeftText;

        // ENDING
        [SerializeField] GameObject endButton;
        [SerializeField] GameObject endCanvas;
        [SerializeField] TextMeshProUGUI endingText;
        [SerializeField] GameObject levelLoader;

        public enum GameState
        {
            Introduction,
            SelectHouse,
            End
        }

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


        // Start is called before the first frame update
        void Start()
        {
            QuestInitialSetUp();

            CurrentState = GameState.SelectHouse;
        }

        private void QuestInitialSetUp()
        {
            // SET UP OF CAMERAS
            foreach (Camera c in houseCameras)
            {
                c.enabled = false;
                c.gameObject.SetActive(false);
            }
            mainCamera.enabled = true;
            mainCamera.gameObject.SetActive(true);

            // INTRODUCTION
            introductionCanvas.SetActive(false);

            // INSTRUCTIONS
            instructionCanvas.SetActive(false);
            instructionIcon.SetActive(false);

            // UI
            doneButton.SetActive(false);
            housesLeftUI.SetActive(false);

            // SOLAR GAME
            mainCanvas.SetActive(false);
            solarGameCanvas.SetActive(false);
            arrowInstructions.SetActive(false);
            firstHouse.SetActive(false);

            // END
            endButton.SetActive(false);
            endCanvas.SetActive(false);
        }

        private void SetState(GameState newState)
        {

            switch (newState)
            {
                case GameState.Introduction:
                    HandleIntroductionState_On();
                    break;
                case GameState.SelectHouse:
                    HandleSelectHouseState_On();
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
                case GameState.SelectHouse:
                    HandleSelectHouseState_Off();
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
            introductionCanvas.SetActive(true);
            introductionTextbox.GetComponent<BlockSceneIntroBox>().LoadText();
        }
        private void HandleIntroductionState_Off()
        {
            introductionCanvas.SetActive(false);
        }
        #endregion

        #region SelectHouseState
        private void HandleSelectHouseState_On()
        {
            mainCanvas.SetActive(true);
            solarGameCanvas.SetActive(true);

            // Set map view so that houses can be selected
            GetComponent<HouseSelector>().MapView = true;

            // Display initial instruction screen
            instructionCanvas.SetActive(true);
            instructionIcon.SetActive(true);

            // Set up houses left ui
            housesLeftUI.SetActive(true);
            housesLeftText.text = "Houses Left: " + housesLeft;
        }

        private void HandleSelectHouseState_Off()
        {

        }

        // Show and hide instruction screen
        public void ShowInstructions()
        {
            instructionCanvas.SetActive(true);
        }

        public void HideInstructions()
        {
            instructionCanvas.SetActive(false);
        }

        public void CloseArrowInstructions()
        {
            arrowInstructions.SetActive(false);
        }

        private void DecrementHousesLeft()
        {
            housesLeft--;
            Mathf.Clamp(housesLeft, 0, 3);
            housesLeftText.text = "Houses Left: " + housesLeft;
        }

        IEnumerator FirstHousePopUp()
        {
            firstHouse.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            firstHouse.SetActive(false);
        }
        #endregion

        #region EndState
        private void HandleEndState_On()
        {
            housesLeftUI.SetActive(false);
            instructionIcon.SetActive(false);
            endButton.SetActive(false);
            endCanvas.SetActive(true);
            endingText.text = GetEndOutcome();
        }

        private void HandleEndState_Off()
        {

        }

        public void EndGame()
        {
            SetState(BlockSceneManager.GameState.End);
        }

        public void TryAgain()
        {
            // Load current scene again
            SceneManager.LoadScene(2);
        }

        public void Continue()
        {
            if (SolarScoring.Instance.energyScore > 0.2)
            {
                // Load Kitsilano scene
                levelLoader.GetComponent<LevelLoader>().LoadLevel(0);
            }
        }

        private string GetEndOutcome()
        {
            string outcome = "";
            if (SolarScoring.Instance.energyScore <= 0.2)
            {
                outcome = "Oops! You must play again. You only achieved 20% of the total solar potential for the street.";
            }
            else if (SolarScoring.Instance.energyScore <= 0.4)
            {
                outcome = "Could do better! You achieved 40% of the total solar potential for the street.";
            }
            else if (SolarScoring.Instance.energyScore <= 0.6)
            {
                outcome = "You’re almost there! You achieved 60% of the total solar potential for the street.";
            }
            else if (SolarScoring.Instance.energyScore <= 0.8)
            {
                outcome = "You did great! You achieved 80% of the total solar potential for the street.";
            }
            else
            {
                outcome = "Wow! You’re a Champion! You were able to achieve 100% of the solar potential for the street.";
            }

            PlayerPrefs.SetInt("solarQuestHighScore", Mathf.RoundToInt(SolarScoring.Instance.energyScore * 100));

            return outcome;
        }
        #endregion


        public void UseCamera(int cameraIndex)
        {
            if (cameraIndex >= houseCameras.Length)
            {
                Debug.Log("No such camera");
                return;
            }

            for (int i = 0; i < houseCameras.Length; i++)
            {
                if (i == cameraIndex)
                {
                    houseCameras[i].enabled = true;
                    houseCameras[i].gameObject.SetActive(true);
                }
                else
                {
                    houseCameras[i].enabled = false;
                    houseCameras[i].gameObject.SetActive(false);
                }
            }

            mainCamera.enabled = false;
            mainCamera.gameObject.SetActive(false);

            instructionIcon.SetActive(false);
            arrowInstructions.SetActive(true);
            endButton.SetActive(false);

            GetComponent<HouseSelector>().MapView = false;
        }

        public void ShowMap()
        {
            // Encouragement for finishing one house
            if (housesLeft == 2 && !firstHousePopUpShown)
            {
                StartCoroutine("FirstHousePopUp");
                firstHousePopUpShown = true;
            }
            arrowInstructions.SetActive(false);
            GetComponent<HouseSelector>().SwitchToMapView();
            mainCamera.enabled = true;
            mainCamera.gameObject.SetActive(true);
            instructionIcon.SetActive(true);
            doneButton.SetActive(false);

            foreach (Camera c in houseCameras)
            {
                c.gameObject.SetActive(false);
                c.enabled = false;
            }

            if (housesLeft <= 0)
            {
                endButton.SetActive(true);
            }
        }













    }

}
