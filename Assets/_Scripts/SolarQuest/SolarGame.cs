using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarGame : MonoBehaviour
{

	public GameObject[] gridObjects;

	private GridManager[] gridManagers;
    private List<GridGenerator> grids;

	private float bestScore = 100f;

    private float testScore;


	void Start()
	{
		gridManagers = new GridManager[gridObjects.Length];

		for (int i = 0; i < gridManagers.Length; i++)
		{
			gridManagers[i] = gridObjects[i].GetComponent<GridManager>();
		}

        grids = new List<GridGenerator>();
        foreach (GridManager gm in gridManagers)
        {
            foreach (GridGenerator gg in gm.gridGenerators)
            {
                grids.Add(gg);
            }
        }
        UpdateScore();
	}

	public void UpdateScore()
	{
		float score = 0f;

        foreach (GridGenerator g in grids)
        {
            score += g.GridScore;
        }

        testScore = score;

		float calculatedScore = score / bestScore;

		SolarScoring.Instance.UpdateEnergyBar(calculatedScore);
	}

}
