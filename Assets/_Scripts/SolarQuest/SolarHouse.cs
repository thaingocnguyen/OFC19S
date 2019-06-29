using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarHouse : MonoBehaviour
{
    [SerializeField] GameObject arrowCanvas;

    [SerializeField] GameObject northCam;
    [SerializeField] GameObject eastCam;
    [SerializeField] GameObject southCam;
    [SerializeField] GameObject westCam;

    [SerializeField] GameObject northSolar;
    [SerializeField] GameObject eastSolar;
    [SerializeField] GameObject southSolar;
    [SerializeField] GameObject westSolar;

    [SerializeField] GameObject backButton;
    [SerializeField] GameObject doneButton;

    [SerializeField] GameObject compass;

    private bool selected;

    public bool Selected
    {
        get { return selected; }
    }

    private void Start()
    {
        northCam.SetActive(false);
        eastCam.SetActive(false);
        westCam.SetActive(false);

        northSolar.SetActive(false);
        eastSolar.SetActive(false);
        southSolar.SetActive(false);
        westSolar.SetActive(false);

        backButton.SetActive(false);
        doneButton.SetActive(false);

        arrowCanvas.SetActive(false);
        selected = false;
    }

    public void SelectRoofScreen()
    {
        selected = true;
        arrowCanvas.SetActive(true);
        compass.SetActive(true);
        doneButton.SetActive(true);
        backButton.SetActive(false);

        northCam.SetActive(false);
        eastCam.SetActive(false);
        westCam.SetActive(false);
        southCam.SetActive(true);

        northSolar.SetActive(false);
        eastSolar.SetActive(false);
        southSolar.SetActive(false);
        westSolar.SetActive(false);
    }


    public void SwitchCameraToSouth()
    {
        SwitchCameraSetup();

        southSolar.SetActive(true);
    }

    public void SwitchCameraToNorth()
    {
        SwitchCameraSetup();

        northSolar.SetActive(true);


        northCam.SetActive(true);
        eastCam.SetActive(false);
        westCam.SetActive(false);
        southCam.SetActive(false);
    }

    public void SwitchCameraToEast()
    {
        SwitchCameraSetup();

        eastSolar.SetActive(true);

        northCam.SetActive(false);
        eastCam.SetActive(true);
        westCam.SetActive(false);
        southCam.SetActive(false);
    }

    public void SwitchCameraToWest()
    {
        SwitchCameraSetup();

        westSolar.SetActive(true);

        northCam.SetActive(false);
        eastCam.SetActive(false);
        westCam.SetActive(true);
        southCam.SetActive(false);
    }

    private void SwitchCameraSetup()
    {
        arrowCanvas.SetActive(false);
        backButton.SetActive(true);
        compass.SetActive(false);
        doneButton.SetActive(false);
    }

    public void HideArrowCanvas()
    {
        arrowCanvas.SetActive(false);
    }
}
