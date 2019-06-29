using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarScoring : MonoBehaviour
{
    public float energyScore;
    public GameObject energyBar;


    #region Singleton
    public static SolarScoring Instance;

    private void Awake()
    {
        Instance = this;
        energyScore = 0f;
    }
    #endregion Singleton


    public void UpdateEnergyBar(float score)
    {
        energyScore = score;

        energyBar.transform.localScale = new Vector3(1, energyScore, 1);
    }


}
