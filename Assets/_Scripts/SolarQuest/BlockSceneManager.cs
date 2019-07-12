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
        public static BlockSceneManager Instance;

        private void Awake()
        {
            GetComponent<HouseSelector>().oHouseSelected += DecrementHousesLeft;
            Instance = this;
        }
        #endregion Singleton



        [SerializeField] Camera mainCamera;
        [SerializeField] Camera[] houseCameras;

        // INTRODUCTION
        [SerializeField] GameObject introduction;

        // INSTRUCTIONS
        [SerializeField] GameObject instructions;
        [SerializeField] GameObject instructionIcon;

        // SOLAR GAME
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

        private GameState currentState = GameState.Introduction;


        // Start is called before the first frame update
        void Start()
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
            introduction.SetActive(false);

            // INSTRUCTIONS
            instructions.SetActive(false);
            instructionIcon.SetActive(false);

            // UI
            doneButton.SetActive(false);
            housesLeftUI.SetActive(false);

            // SOLAR GAME
            energyBar.SetActive(false);
            budget.SetActive(false);
            compass.SetActive(false);
            arrowInstructions.SetActive(false);
            firstHouse.SetActive(false);

            // END
            endButton.SetActive(false);
            endCanvas.SetActive(false);

            StateSetup();
        }

        private void StateSetup()
        {
            switch (currentState)
            {
                case GameState.Introduction:
                    introduction.SetActive(true);
                    break;
                case GameState.SelectHouse:
                    SelectHouseState();
                    break;
                case GameState.End:
                    EndState();
                    break;
                default:
                    break;
            }
        }

        private void SelectHouseState()
        {
            GetComponent<HouseSelector>().MapView = true;
            energyBar.SetActive(true);
            budget.SetActive(true);
            compass.SetActive(true);
            instructions.SetActive(true);
            instructionIcon.SetActive(true);
            housesLeftUI.SetActive(true);
            housesLeftText.text = "Houses Left: " + housesLeft;
        }

        public void SetState(GameState state)
        {
            currentState = state;
            StateSetup();
        }

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

        public void CloseArrowInstructions()
        {
            arrowInstructions.SetActive(false);
        }

        private string GetEndOutcome()
        {
            string outcome = "";
            if (SolarScoring.Instance.energyScore <= 0.2)
            {
                outcome = "Oops! You must play again. You only achieved 20% of the total solar potential.";
            }
            else if (SolarScoring.Instance.energyScore <= 0.4)
            {
                outcome = "Could do better! You achieved 40% off the total solarr potential";
            }
            else if (SolarScoring.Instance.energyScore <= 0.6)
            {
                outcome = "You’re almost there! You achieved 60% of the total solar potential.";
            }
            else if (SolarScoring.Instance.energyScore <= 0.8)
            {
                outcome = "You did great! You achieved 80% of the total solar potential.";
            }
            else
            {
                outcome = "Wow! You’re a Champion! You were able to achieve 100% of the solar potential.";
            }

            return outcome;
        }


        public void ShowInstructions()
        {
            instructions.SetActive(true);
        }

        public void HideInstructions()
        {
            instructions.SetActive(false);
        }

        private void DecrementHousesLeft()
        {
            housesLeft--;
            Mathf.Clamp(housesLeft, 0, 3);
            housesLeftText.text = "Houses Left: " + housesLeft;
        }

        public void EndGame()
        {
            SetState(BlockSceneManager.GameState.End);
        }

        private void EndState()
        {
            housesLeftUI.SetActive(false);
            instructionIcon.SetActive(false);
            endButton.SetActive(false);
            endCanvas.SetActive(true);
            endingText.text = GetEndOutcome();
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

        IEnumerator FirstHousePopUp()
        {
            firstHouse.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            firstHouse.SetActive(false);
        }
    }

}
