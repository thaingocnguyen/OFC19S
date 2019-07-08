using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarQuestIntroductionBox : InfoBox
{
    [SerializeField] GameObject solarQuestTutorialManager;

    public override void LoadText()
    {
        sentences.Clear();

        sentences.Enqueue("Hello there! My name is Reneé.");
        sentences.Enqueue("They call me ‘Renewable Reneé’ because I believe we can get the biggest impact on adapting to & mitigating climate change by altering where we get our energy from – which means more renewable energy and no reliance on fossil fuels.");
        sentences.Enqueue("Globally, the use of energy, by far, represents the largest source of greenhouse gas (GHG) emissions from human activities.");
        sentences.Enqueue("About 2/3rds of global GHG emissions are linked to burning fossil fuels for energy – used for heating, electricity, transport and industry.");
        sentences.Enqueue("Do you know about Vancouver’s Renewable City Strategy where the city has set an ambitious emission reduction target – 80% reduction in GHG emissions and a shift to derive 100% of its energy from renewable sources by the year 2050.");
        sentences.Enqueue("As a part of these targets, the city is encouraging energy efficiency retrofits and fuel switching to electricity-based sources.");
        sentences.Enqueue("The 1st Quest is focused on solar energy, which has 3 components: (1) Atmosphere, (2) Solar Position, and (3) Urban Form.");
        sentences.Enqueue("The direction/orientation of roofs and the placement of trees can impact a building’s solar potential and position of solar panels on the roofs.");

        DisplayNextSentence();
    }

    public override void HandleNoSentencesLeft()
    {
        solarQuestTutorialManager.GetComponent<SolarQuestTutorialManager>().ChangeStateToSliderTutorial();
    }
}