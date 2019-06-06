using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSceneManager : MonoBehaviour
{
    [SerializeField] InfoPanel infoPanel;
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera[] houseCameras;

    // UI ELEMENTS
    [SerializeField] GameObject backButton;

    // Start is called before the first frame update
    void Start()
    {
        // SET UP OF CAMERAS
        foreach (Camera c in houseCameras) { c.gameObject.SetActive(false); }
        mainCamera.enabled = true;

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
                houseCameras[i].gameObject.SetActive(true);
            }
            else
            {
                houseCameras[i].gameObject.SetActive(false);
            }
        }

        mainCamera.gameObject.SetActive(false);
        backButton.SetActive(true);
    }

    public void ShowMap()
    {
        GetComponent<HouseSelector>().MapView = true;
        mainCamera.gameObject.SetActive(true);
        backButton.SetActive(false);
        foreach (Camera c in houseCameras) { c.gameObject.SetActive(false); }
    }

}
