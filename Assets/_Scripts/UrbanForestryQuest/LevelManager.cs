using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor
{
    public class LevelManager : MonoBehaviour
    {
        GridBase gridBase;

        public List<GameObject> inSceneGameObjects = new List<GameObject>();
        public List<GameObject> inSceneWalls = new List<GameObject>();
        public List<GameObject> inSceneStackObjects = new List<GameObject>();

        public GameObject canopyBar;

        // SCORING
        private float canopyScore;
        [SerializeField] float maxScore;

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
            //InitLevelObjects();
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
            canopyScore = inSceneGameObjects.Count * 5;
            canopyBar.transform.localScale = new Vector3(1, canopyScore / maxScore, 1);
        }


    }
}

