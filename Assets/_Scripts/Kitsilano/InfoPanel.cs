using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsilanoScene
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] GameObject background;

        [SerializeField] GameObject solarQuest;
        [SerializeField] GameObject ufQuest;

        [SerializeField] GameObject loaderScript;
        LevelLoader levelLoader;

        int selectedQuest;

        // Start is called before the first frame update
        void Start()
        {
            if (loaderScript)
            {
                levelLoader = loaderScript.GetComponent<LevelLoader>();
            }

            background.SetActive(false);
            solarQuest.SetActive(false);
            ufQuest.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ShowInfoPanel(int questNumber)
        {
            selectedQuest = questNumber;
            background.SetActive(true);
            switch (questNumber)
            {
                case 0:
                    solarQuest.SetActive(true);
                    break;
                case 1:
                    ufQuest.SetActive(true);
                    break;
                default:
                    Debug.Log("Invalid quest number!");
                    break;
            }
        }

        public void HideInfoPanel()
        {
            background.SetActive(false);
            switch (selectedQuest)
            {
                case 0:
                    solarQuest.SetActive(false);
                    break;
                case 1:
                    ufQuest.SetActive(false);
                    break;
                default:
                    Debug.Log("Invalid quest number!");
                    break;
            }
        }

        public void StartQuest()
        {
            switch (selectedQuest)
            {
                case 0:
                    levelLoader.LoadLevel(1);
                    break;
                case 1:
                    levelLoader.LoadLevel(3);
                    break;
                default:
                    Debug.Log("Invalid quest number!");
                    break;
            }
        }
    }

}
