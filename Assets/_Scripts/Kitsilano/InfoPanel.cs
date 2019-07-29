using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace KitsilanoScene
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] GameObject background;

        [SerializeField] GameObject solarQuest;
        [SerializeField] GameObject ufQuest;

        [SerializeField] GameObject loaderScript;
        LevelLoader levelLoader;

        [SerializeField] TextMeshProUGUI solarHighScoreText;
        [SerializeField] TextMeshProUGUI ufHighScoreText;

        int selectedQuest;

        public int solarQuesTutorialPlayed = 0;

        // HIGH SCORES
        public int solarQuestHighScore = 0;
        public int ufQuestHighScore = 0;

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

        private void LoadData()
        {
            if (PlayerPrefs.HasKey("solarQuestTutorialPlayed"))
            {
                solarQuesTutorialPlayed = PlayerPrefs.GetInt("solarQuestTutorialPlayed");
            }
            else
            {
                solarQuesTutorialPlayed = 0;
            }

            if (PlayerPrefs.HasKey("solarQuestHighScore"))
            {
                solarQuestHighScore = PlayerPrefs.GetInt("solarQuestHighScore");
            }
            else
            {
                solarQuestHighScore = 0;
            }

            if (PlayerPrefs.HasKey("ufQuestHighScore"))
            {
                ufQuestHighScore = PlayerPrefs.GetInt("ufQuestHighScore");
            }
            else
            {
                ufQuestHighScore = 0;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ShowInfoPanel(int questNumber)
        {
            Debug.Log("test");
            LoadData();
            selectedQuest = questNumber;
            background.SetActive(true);
            switch (questNumber)
            {
                case 0:
                    solarQuest.SetActive(true);
                    solarHighScoreText.text = solarQuestHighScore.ToString() + "%";
                    break;
                case 1:
                    ufQuest.SetActive(true);
                    ufHighScoreText.text = ufQuestHighScore.ToString() + "%";
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
                    if (solarQuesTutorialPlayed == 0)
                    {
                        levelLoader.LoadLevel(1);
                    }
                    else
                    {
                        levelLoader.LoadLevel(2);
                    }
                    
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
