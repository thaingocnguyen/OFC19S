using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UrbanForestryQuest
{
    public class LevelManager : MonoBehaviour
    {
        GridBase gridBase;

        public List<GameObject> inSceneGameObjects = new List<GameObject>();

        public GameObject canopyBar;

        // SCORING
        private float canopyScore;
        [SerializeField] float maxScore;
        public float CanopyScore
        {
            get { return canopyScore; }
        }

        // FUTURE VISUALIZATION
        [SerializeField] GameObject tree_large;
        private List<GameObject> futureTrees = new List<GameObject>();

        #region Singleton
        private static LevelManager instance = null;
        public static LevelManager GetInstance()
        {
            return instance;
        }

        private void Awake()
        {
            instance = this;
        }
        #endregion

        private void Start()
        {
            gridBase = GridBase.GetInstance();

            // Canopy bar starts at 0
            canopyBar.transform.localScale = new Vector3(1, 0, 1);
            InitLevelObjects();
        }

        // Used to load objects if there is save function
        void InitLevelObjects()
        {
            if (inSceneGameObjects.Count > 0)
            {
                for (int i = 0; i < inSceneGameObjects.Count; i++)
                {
                    Level_Object obj = inSceneGameObjects[i].GetComponent<Level_Object>();
                    obj.UpdateNode(gridBase.grid);
                }
            }
        }

        public void UpdateCanopyScore()
        {
            canopyScore = 0;
            for (int i = 0; i < inSceneGameObjects.Count; i++)
            {
                Level_Object lvlObj = inSceneGameObjects[i].GetComponent<Level_Object>();
                canopyScore += gridBase.grid[lvlObj.gridPosX, lvlObj.gridPosZ].multiplier;
            }
            canopyScore = Mathf.Clamp(canopyScore * 5, 0f, maxScore);
            canopyBar.transform.localScale = new Vector3(1, canopyScore / maxScore, 1);
        }

        // Last step before the quest finishes
        public void VisualizeFuture()
        {
            if (inSceneGameObjects.Count > 0)
            {
                for (int i = 0; i < inSceneGameObjects.Count; i++)
                {
                    GameObject newTree = Instantiate(tree_large, inSceneGameObjects[i].transform.position, Quaternion.identity);
                    inSceneGameObjects[i].SetActive(false);
                    futureTrees.Add(newTree);
                }
            }

            // Sets the high score for the quest
            PlayerPrefs.SetInt("ufHighScore", Mathf.RoundToInt(canopyScore));
        }


    }
}

