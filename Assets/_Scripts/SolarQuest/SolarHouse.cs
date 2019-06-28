using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarHouse : MonoBehaviour
{
    [SerializeField] GameObject solarGame;

    private bool selected;

    public bool Selected
    {
        get { return selected; }
    }

    private void Start()
    {
        solarGame.SetActive(false);
        selected = false;
    }

    public void ActivateSolarGame()
    {
        selected = true;
        solarGame.SetActive(true);
    }

    public void DeactivateSolarGame()
    {
        solarGame.SetActive(false);
    }
}
