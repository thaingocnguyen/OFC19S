using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace KitsilanoScene
{
    public class KitsilanoManager : MonoBehaviour
    {

        public GameObject logo;
        public GameObject buttonCanvas;
        public GameObject infoCanvas;
        public GameObject welcomeMessage;

		public GameObject introductionSequence;

		public PlayableDirector cutscene;

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
            if (!GlobalControl.Instance.startCutscenePlayed)
			{
				Debug.Log("Playing Introduction");
				introductionSequence.GetComponent<IntroductionSequence>().StartIntroductionSequence();
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
		}

		void OnCutsceneEnd(PlayableDirector aDirector)
		{
			if (cutscene == aDirector)
			{
				Debug.Log("End of cutscene");
			}
		}

		void OnDisable()
		{
			cutscene.stopped -= OnCutsceneEnd;
		}

	}

}
