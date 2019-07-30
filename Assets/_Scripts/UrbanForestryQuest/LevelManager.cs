using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UrbanForestryQuest
{
    public class LevelManager : MonoBehaviour
    {
        GridBase gridBase;

        public List<GameObject> inSceneGameObjects = new List<GameObject>();
        private List<Level_Object> internalSceneObjects = new List<Level_Object>();

        public GameObject canopyBar;

        // SCORING
        private float canopyScore;
        [SerializeField] float startScore;
        [SerializeField] float maxScore;

        [SerializeField] float totalArea = 720;
        [SerializeField] float areaPerTree = 16;

        public float CanopyScore
        {
            get { return ((canopyScore * areaPerTree) / 720) * 100; }
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
            canopyScore = startScore;
            canopyBar.transform.localScale = new Vector3(1, startScore / maxScore, 1);
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
            internalSceneObjects.Clear();
            canopyScore = startScore;
            for (int i = 0; i < inSceneGameObjects.Count; i++)
            {
                Level_Object lvlObj = inSceneGameObjects[i].GetComponent<Level_Object>();
                internalSceneObjects.Add(lvlObj);
                canopyScore += gridBase.grid[lvlObj.gridPosX, lvlObj.gridPosZ].multiplier;
            }
            canopyScore = Mathf.Clamp(canopyScore, 0f, maxScore);
            canopyBar.transform.localScale = new Vector3(1, canopyScore / maxScore, 1);
        }


        // Last step before the quest finishes
        public void VisualizeFuture()
        {
            if (inSceneGameObjects.Count > 0)
            {
                for (int i = 0; i < inSceneGameObjects.Count; i++)
                {
                    Level_Object lvlObj = internalSceneObjects[i];

                    // Only if a tree is placed in the right spot does it get added to list of future trees 
                    if (gridBase.grid[lvlObj.gridPosX, lvlObj.gridPosZ].multiplier != 0)
                    {
                        GameObject newTree = Instantiate(tree_large, inSceneGameObjects[i].transform.position, Quaternion.identity);
                        inSceneGameObjects[i].SetActive(false);
                        futureTrees.Add(newTree);
                    }
                    else
                    {
                        inSceneGameObjects[i].SetActive(false);
                    }
                }
            }

            // Sets the high score for the quest
            PlayerPrefs.SetInt("ufHighScore", Mathf.RoundToInt(canopyScore));
        }


    }
}

