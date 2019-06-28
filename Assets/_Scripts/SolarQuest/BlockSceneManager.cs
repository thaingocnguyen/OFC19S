using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlockSceneManager : MonoBehaviour
{
    #region Singleton
    public static BlockSceneManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion Singleton

    [SerializeField] Camera mainCamera;
    [SerializeField] Camera[] houseCameras;

    // UI ELEMENTS
    [SerializeField] GameObject backButton;

    // INTRODUCTION
    [SerializeField] GameObject introduction;

    // INSTRUCTIONS
    [SerializeField] GameObject instructions;
    [SerializeField] GameObject instructionIcon;

    // SOLAR GAME
    [SerializeField] GameObject energyBar;
    [SerializeField] GameObject budget;
    [SerializeField] GameObject compass;


    public enum GameState
    {
        Introduction,
        SelectHouse,
        End
    }

    private GameState currentState = GameState.SelectHouse;

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
        backButton.SetActive(false);

        // SOLAR GAME
        energyBar.SetActive(false);
        budget.SetActive(false);
        compass.SetActive(false);

        StateSetup();
    }

    private void StateSetup()
    {
        switch(currentState)
        {
            case GameState.Introduction:
                introduction.SetActive(true);
                break;
            case GameState.SelectHouse:
                energyBar.SetActive(true);
                budget.SetActive(true);
                compass.SetActive(true);
                instructions.SetActive(true);
                instructionIcon.SetActive(true);
                break;
            default:
                break;
        }
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

        GetComponent<HouseSelector>().MapView = false;
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

        backButton.SetActive(true);
    }

    public void ShowMap()
    {
        GetComponent<HouseSelector>().SwitchToMapView();
        mainCamera.enabled = true;
        mainCamera.gameObject.SetActive(true);
        backButton.SetActive(false);

        foreach (Camera c in houseCameras)
        {
            c.gameObject.SetActive(false);
            c.enabled = false;
        }
    }

    private string GetEndOutcome()
    {
        string outcome = "";
        if (SolarScoring.Instance.energyScore <= 0.2)
        {
            outcome = "Oops! You must play again. You only achieved 20% of the total (solar/urban forestry) potential.";
        }
        else if (SolarScoring.Instance.energyScore <= 0.4)
        {
            outcome = "Could do better! You achieved 40% off the total xyz potential";
        }
        else if (SolarScoring.Instance.energyScore <= 0.6)
        {
            outcome = "You’re almost there! You achieved 60% of the xyz potential.";
        }
        else if (SolarScoring.Instance.energyScore <= 0.8)
        {
            outcome = "You did great! You achieved 80% of the xyz potential.";
        }
        else
        {
            outcome = "Wow! You’re a Champion! You were able to achieve 100% of the xyz potential.";
        }

        return outcome;
    }

    public void ShowMainKitsilanoScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowInstructions()
    {
        instructions.SetActive(true);
    }

    public void HideInstructions()
    {
        instructions.SetActive(false);
    }

}
