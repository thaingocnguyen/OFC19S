﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace KitsilanoScene
{
    public class KitsilanoManager : MonoBehaviour
    {
        public PlayableDirector director;
        public GameObject logo;
        public GameObject buttonCanvas;
        public GameObject infoCanvas;
        public GameObject welcomeMessage;

        private bool startCutscenePlayed;

        #region Singleton
        private static KitsilanoManager instance = null;
        public static KitsilanoManager GetInstance()
        {
            return instance;
        }

        private void Awake()
        {
            instance = this;
        }
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            if (!startCutscenePlayed)
            {
                logo.SetActive(false);
                buttonCanvas.SetActive(false);
                infoCanvas.SetActive(false);
                welcomeMessage.SetActive(false);

                director.Play();
                startCutscenePlayed = false;
            }

        }

        private void OnEnable()
        {
            director.stopped += OnPlayableDirectorStopped;
        }

        void OnPlayableDirectorStopped(PlayableDirector aDirector)
        {
            if (director == aDirector)
            {
                logo.SetActive(true);
                
                welcomeMessage.SetActive(true);
            }
        }

        void OnDisable()
        {
            director.stopped -= OnPlayableDirectorStopped;
        }

        public void CloseWelcomeMessage()
        {
            welcomeMessage.SetActive(false);
            buttonCanvas.SetActive(true);
            infoCanvas.SetActive(true);
        }

    }

}
