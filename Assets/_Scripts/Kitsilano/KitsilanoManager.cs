using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


namespace KitsilanoScene
{
    public class KitsilanoManager : MonoBehaviour
    {

        public GameObject logoCanvas;
        public GameObject buttonCanvas;
        public GameObject infoCanvas;
        public GameObject welcomeMessage;

		public GameObject introductionSequence;

		public PlayableDirector cutscene;
		public PlayableDirector logoTransition;

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
			logoCanvas.SetActive(false);
			buttonCanvas.SetActive(false);
			infoCanvas.SetActive(false);

            if (!GlobalControl.Instance.startCutscenePlayed)
			{
				Debug.Log("Playing Introduction");
				introductionSequence.GetComponent<IntroductionSequence>().StartIntroductionSequence();
			}
            else
			{
				StartLogoTransition();
			}
			
        }



        public void CloseWelcomeMessage()
        {
            welcomeMessage.SetActive(false);
            buttonCanvas.SetActive(true);
            infoCanvas.SetActive(true);
        }

		private void OnEnable()
		{
			cutscene.stopped += OnCutsceneEnd;
			//logoTransition.stopped += OnLogoTransitionEnd;
		}

		void OnCutsceneEnd(PlayableDirector aDirector)
		{
			if (cutscene == aDirector)
			{
				StartLogoTransition();
			}
		}


		void OnDisable()
		{
			cutscene.stopped -= OnCutsceneEnd;
			//logoTransition.stopped += OnLogoTransitionEnd;
		}

        private void StartLogoTransition()
		{
			logoCanvas.SetActive(true);
			logoTransition.Play();
		}

        public void SkipIntroduction()
		{
			GlobalControl.Instance.startCutscenePlayed = true;
			introductionSequence.SetActive(false);
			StartLogoTransition();
		}

	}

}
