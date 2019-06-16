using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarScoring : MonoBehaviour
{
    public float energyScore;
    public GameObject energyBar;
    public GameObject[] gridObjects;

    private GridGenerator[] grids;


    #region Singleton
    public static SolarScoring Instance;

    private void Awake()
    {
        Instance = this;
        energyScore = 0f;
    }
    #endregion Singleton

    void Start()
    {
        grids = new GridGenerator[gridObjects.Length];
        for (int i = 0; i < grids.Length; i++)
        {
            grids[i] = gridObjects[i].GetComponent<GridGenerator>();
        }
        UpdateScore();
    }

    public void UpdateScore()
    {
        float score = 0f;
        for (int i = 0; i < grids.Length; i++)
        {
            score += grids[i].GridScore;
        }

        float calculatedScore = score / grids.Length;
        energyScore = calculatedScore;

        energyBar.transform.localScale = new Vector3(1, calculatedScore, 1);
    }


}
