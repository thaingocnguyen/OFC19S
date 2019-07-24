using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UrbanForestryQuest
{
    public class IntroBox : InfoBox
    {
        public override void HandleNoSentencesLeft()
        {
            UrbanForestryQuestManager.GetInstance().CurrentState = UrbanForestryQuestManager.GameState.Tutorial;
        }
    }

}
