using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarGame : MonoBehaviour
{

	public GameObject[] gridObjects;

	private GridGenerator[] grids;

	private float bestScore = 100f;


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
            if (grids[i])
			{
				score += grids[i].GridScore;
			}
		}

		float calculatedScore = score / bestScore;

		SolarScoring.Instance.UpdateEnergyBar(calculatedScore);
	}

}
