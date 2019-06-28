using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlockSceneManager : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera[] houseCameras;

    // UI ELEMENTS
    [SerializeField] GameObject instructions;
    [SerializeField] GameObject instructionIcon;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject doneButton;

    // END QUEST
    [SerializeField] GameObject endQuestPanel;
    [SerializeField] Text endQuestText;

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

        instructions.SetActive(false);
        instructionIcon.SetActive(false);
        backButton.SetActive(false);
        doneButton.SetActive(false);
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

        doneButton.SetActive(false);
        backButton.SetActive(true);
    }

    public void ShowMap()
    {
        GetComponent<HouseSelector>().SwitchToMapView();
        mainCamera.enabled = true;
        mainCamera.gameObject.SetActive(true);
        backButton.SetActive(false);
        doneButton.SetActive(true);
        foreach (Camera c in houseCameras)
        {
            c.gameObject.SetActive(false);
            c.enabled = false;
        }
    }

    public void EndQuest()
    {
        doneButton.SetActive(false);
        endQuestPanel.SetActive(true);
        endQuestPanel.GetComponent<Animator>().SetBool("IsOnScreen", true);
        endQuestText.text = GetEndOutcome();
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
        instructionIcon.SetActive(true);
    }

}
