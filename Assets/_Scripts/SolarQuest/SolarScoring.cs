using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarScoring : MonoBehaviour
{
    public float energyScore;
    public GameObject energyBar;

    [SerializeField] List<GameObject> solarGamesObjects;
    [SerializeField] float bestScore;

    private List<SolarGame> solarGames;
    private bool firstTimeSetUp = false;
    


    #region Singleton
    public static SolarScoring Instance;

    private void Awake()
    {
        Instance = this;
        energyScore = 0f;
    }
    #endregion Singleton


    private void Start()
    {
        energyBar.transform.localScale = new Vector3(1, 0, 1);
    }

    public void UpdateEnergyBar()
    {
        if (!firstTimeSetUp)
        {
            solarGames = new List<SolarGame>();
            foreach (GameObject g in solarGamesObjects)
            {
                solarGames.Add(g.GetComponent<SolarGame>());
            }
            firstTimeSetUp = true;
        }

        float score = 0;

        foreach(SolarGame sg in solarGames)
        {
            score += sg.houseScore;
        }

        energyScore = score / bestScore;

        energyBar.transform.localScale = new Vector3(1, energyScore, 1);
    }


}
