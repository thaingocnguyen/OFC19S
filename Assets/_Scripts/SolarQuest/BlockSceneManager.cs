using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlockSceneManager : MonoBehaviour
{
    [SerializeField] InfoPanel infoPanel;
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera[] houseCameras;

    // UI ELEMENTS
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

        // SET UP OF SCENE 
        backButton.SetActive(false);

        infoPanel.ShowInfoPanel();
    }

    // Update is called once per frame
    void Update()
    {

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
        GetComponent<HouseSelector>().MapView = true;
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
        endQuestText.text = "Congratulations! Your energy score is " + SolarScoring.Instance.energyScore;
    }

    public void ShowMainKitsilanoScene()
    {
        SceneManager.LoadScene(0);
    }

}
