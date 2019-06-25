using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarQuestIntroductionBox : InfoBox
{
    [SerializeField] GameObject solarQuestTutorialManager;

    public override void HandleNoSentencesLeft()
    {
        solarQuestTutorialManager.GetComponent<SolarQuestTutorialManager>().ChangeStateToSliderTutorial();
    }
}