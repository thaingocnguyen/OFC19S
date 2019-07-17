using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor
{
    public class CameraController : MonoBehaviour
    {

        public List<GameObject> cameras = new List<GameObject>();

        private GameObject frontCam;
        private GameObject backCam;

        [SerializeField] GameObject frontButton;
        [SerializeField] GameObject backButton;

        private void Start()
        {
            frontCam = cameras[0];
            backCam = cameras[1];
            frontButton.SetActive(false);
            backButton.SetActive(true);
        }
        public void SwitchCameraToFront()
        {
            frontCam.SetActive(true);
            backCam.SetActive(false);
            frontButton.SetActive(false);
            backButton.SetActive(true);
        }

        public void SwitchCameraToBack()
        {
            frontCam.SetActive(false);
            backCam.SetActive(true);
            frontButton.SetActive(true);
            backButton.SetActive(false);
        }
    }
}

