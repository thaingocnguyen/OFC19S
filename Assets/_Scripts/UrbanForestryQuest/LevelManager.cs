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
        [SerializeField] float mortalityRate = 0.14f;

        // Used as a parent to instantiate increments in 
        [SerializeField] GameObject canopyBarBorder;
        [SerializeField] float canopyBarFillHeight;
        [SerializeField] GameObject incrementPrefab;
        private float scoreDiff;
        private float newScore;
        private GameObject increment;

        public float CanopyScore
        {
            get
            {
                canopyScore = newScore;
                return ((canopyScore * areaPerTree) / 720) * 100;
            }
        }

        // FUTURE VISUALIZATION
        #region Future Visualization
        [SerializeField] GameObject tree_large;
        [SerializeField] GameObject tree_dead;
        private List<GameObject> futureTrees = new List<GameObject>();
        [SerializeField] GameObject existingTrees;
        [SerializeField] GameObject agedExistingTrees;
        #endregion

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
            increment = Instantiate(incrementPrefab, canopyBar.transform.position, Quaternion.identity) as GameObject;
            increment.transform.SetParent(canopyBarBorder.transform);
            increment.transform.localScale = new Vector3(1, 0, 1);
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
            newScore = startScore;
            for (int i = 0; i < inSceneGameObjects.Count; i++)
            {
                Level_Object lvlObj = inSceneGameObjects[i].GetComponent<Level_Object>();
                internalSceneObjects.Add(lvlObj);
                newScore += gridBase.grid[lvlObj.gridPosX, lvlObj.gridPosZ].multiplier;
            }
            newScore = Mathf.Clamp(newScore, 0f, maxScore);
            scoreDiff = newScore - canopyScore;

            increment.transform.position = canopyBar.transform.position + new Vector3(0, canopyBarFillHeight * (canopyScore / maxScore), 0);
            if (scoreDiff >= 0)
            {
                increment.transform.localScale = new Vector3(1, scoreDiff / maxScore, 1);
            }
            else
            {
                increment.transform.localScale = new Vector3(1, 0, 1);
            }

            canopyScore = newScore;
            canopyBar.transform.localScale = new Vector3(1, canopyScore / maxScore, 1);
        }


        // Last step before the quest finishes
        public void VisualizeFuture()
        {
            int numberOfInSceneGameObjects = inSceneGameObjects.Count;
            if (numberOfInSceneGameObjects > 0)
            {
                for (int i = 0; i < numberOfInSceneGameObjects; i++)
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

                // Replace dead trees with dead tree visualization
                int numberOfFutureTrees = futureTrees.Count;
                int numberOfDeadTrees = Mathf.RoundToInt(mortalityRate * numberOfFutureTrees);

                while (numberOfDeadTrees > 0)
                {
                    int randomNumber = Mathf.RoundToInt(Random.Range(0, numberOfFutureTrees - 1));
                    if (futureTrees[randomNumber].activeSelf)
                    {
                        Instantiate(tree_dead, futureTrees[randomNumber].transform.position, Quaternion.identity);
                        futureTrees[randomNumber].SetActive(false);
                        numberOfDeadTrees--;
                    }
                }
                

                existingTrees.SetActive(false);
                agedExistingTrees.SetActive(true);
            }

            // Sets the high score for the quest
            GlobalControl.Instance.ufQuestHighScore = Mathf.RoundToInt(canopyScore);
        }


    }
}

