using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Define Cams
    public Camera startCamera;
    public Camera topDownCamera;
    public Camera southRoofCamera;


    //Define List of Cameras
    private List<Camera> cameras;

    private void Awake()
    {
        InitializeCameras();
    }
    private void Start()
    {

    }

    private void InitializeCameras()
    {
        cameras.Add(startCamera);
        cameras.Add(topDownCamera);
        cameras.Add(southRoofCamera);
    }

    public void SwapCamera(Camera cam)
    {
        // performance tradeoff
        foreach (Camera c in cameras)
        {
            c.enabled = false;
        }
        cam.enabled = true;
    }
}
