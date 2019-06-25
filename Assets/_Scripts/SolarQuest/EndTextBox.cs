using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTextBox : InfoBox
{
    [SerializeField] GameObject endContinueArrrow;
    [SerializeField] GameObject levelLoader;

    public override void LoadText()
    {
        endContinueArrrow.SetActive(true);
        base.LoadText();
    }

    public override void HandleNoSentencesLeft()
    {
        endContinueArrrow.SetActive(false);
        levelLoader.GetComponent<LevelLoader>().LoadLevel(2);
    }
}
