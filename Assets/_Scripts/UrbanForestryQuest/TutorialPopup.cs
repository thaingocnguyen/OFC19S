using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UrbanForestryQuest
{
    public class TutorialPopup : MonoBehaviour
    {
        // BUTTONS
        [SerializeField] GameObject plantTreeButton;
        [SerializeField] GameObject deleteTreeButton;
        [SerializeField] GameObject budgetText;
        [SerializeField] GameObject canopyCoverBar;
        [SerializeField] GameObject switchCameraButton;
        [SerializeField] GameObject doneButton;

        // POPUPS
        [SerializeField] GameObject controlPopup;
        [SerializeField] GameObject budgetPopup;
        [SerializeField] GameObject canopyCoverPopup;
        [SerializeField] GameObject plantTreePopup;
        [SerializeField] GameObject firstTreePlantedPopup;
        [SerializeField] GameObject budgetReminderPopup;
        [SerializeField] GameObject canopyCoverReminderPopup;
        [SerializeField] GameObject deleteTreePopup;
        [SerializeField] GameObject switchCameraPopup;
        [SerializeField] GameObject donePopup;

        private bool firstTreePlanted;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!firstTreePlanted && LevelManager.GetInstance().inSceneGameObjects.Count > 0)
            {
                StartCoroutine(FirstTreePlantedPopup());
                firstTreePlanted = true;
            }
        }

        public void InitializeTutorial()
        {
            plantTreeButton.SetActive(false);
            deleteTreeButton.SetActive(false);
            budgetText.SetActive(false);
            canopyCoverBar.SetActive(false);
            switchCameraButton.SetActive(false);
            doneButton.SetActive(false);

            controlPopup.SetActive(false);
            budgetPopup.SetActive(false);
            canopyCoverPopup.SetActive(false);
            plantTreePopup.SetActive(false);
            firstTreePlantedPopup.SetActive(false);
            budgetReminderPopup.SetActive(false);
            canopyCoverReminderPopup.SetActive(false);
            deleteTreePopup.SetActive(false);
            switchCameraPopup.SetActive(false);
            donePopup.SetActive(false);

            ShowControlPopup();
        }

        public void ShowControlPopup()
        {
            controlPopup.SetActive(true);
        }

        public void ShowBudgetPopup()
        {
            switchCameraPopup.SetActive(false);

            budgetText.SetActive(true);
            budgetPopup.SetActive(true);
        }

        public void ShowCanopyCoverPopup()
        {
            budgetPopup.SetActive(false);

            canopyCoverBar.SetActive(true);
            canopyCoverPopup.SetActive(true);
        }

        public void ShowPlantTreePopup()
        {
            canopyCoverPopup.SetActive(false);

            plantTreeButton.SetActive(true);
            plantTreePopup.SetActive(true);
        }

        public void ClosePlantTreePopup()
        {
            plantTreePopup.SetActive(false);
        }

        private IEnumerator FirstTreePlantedPopup()
        {
            firstTreePlantedPopup.SetActive(true);
            yield return new WaitForSeconds(2f);
            firstTreePlantedPopup.SetActive(false);
            yield return new WaitForSeconds(0.5f);

            budgetReminderPopup.SetActive(true);
        }

        public void ShowCanopyCoverReminderPopup()
        {
            budgetReminderPopup.SetActive(false);
            canopyCoverReminderPopup.SetActive(true);
        }

        public void ShowDeleteTreePopup()
        {
            canopyCoverReminderPopup.SetActive(false);

            deleteTreeButton.SetActive(true);
            deleteTreePopup.SetActive(true);
        }

        public void ShowSwitchCameraPopup()
        {
            controlPopup.SetActive(false);

            switchCameraButton.SetActive(true);
            switchCameraPopup.SetActive(true);
        }

        public void ShowDonePopup()
        {
            deleteTreePopup.SetActive(false);

            donePopup.SetActive(true);
            doneButton.SetActive(true);
        }

        public void CloseDonePopup()
        {
            donePopup.SetActive(false);

            //plantTreeButton.SetActive(false);
            //deleteTreeButton.SetActive(false);
            //budgetText.SetActive(false);
            //canopyCoverBar.SetActive(false);
            //switchCameraButton.SetActive(false);
            //doneButton.SetActive(false);
        }
    }
}

