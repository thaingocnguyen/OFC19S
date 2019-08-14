using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UrbanForestryQuest
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

            frontCam.SetActive(true);
            backCam.SetActive(false);

            frontButton.SetActive(false);
            backButton.SetActive(true);

            MovementEnabled = true;
        }

        #region Singleton
        private static CameraController instance = null;
        public static CameraController GetInstance()
        {
            return instance;
        }

        private void Awake()
        {
            instance = this;
        }
        #endregion

        public bool MovementEnabled { get; set; }

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

