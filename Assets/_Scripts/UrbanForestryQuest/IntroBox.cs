using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UrbanForestryQuest
{
    public class IntroBox : InfoBox
    {

        private void Start()
        {
            sentences.Enqueue("Hello there! My name is Teresa. They call me 'Tree-hugger Teresa' because I believe trees are the most important natural asset that make the biggest impact with climate change adaptation & mitigation.");
            sentences.Enqueue("As such, trees in urban areas have an even more important role to play to support: storm water management, refuge from heat through shading and cooling, filter air & carbon sequestration, while enhancing health and well-being, biodiversity, property values and local aesthetics.");
            sentences.Enqueue("Urban Forest includes a variety of vegetation and landscape types such as parks, streetscapes, natural areas, and private yards, which together form a complex system of urban greenery (Citizen's Coolkit, 2018); and a healthy urban forest will be vital in a hotter, drier and unpredictable future.");
            sentences.Enqueue("Sadly, we are also losing healthy trees every day due to climate change - storms, droughts, diseases, etc.");
            sentences.Enqueue("Do you know about Vancouver's Urban Forest Strategy where the city has set an ambitious target of increasing its tree canopy to <b><i>22%</i></b> by 2050? How do we get there? By planting 150,000 new trees! And all of us can do a lot to support this transition through better management, replanting, and stewardship of trees in public and private land.");
            sentences.Enqueue("This Quest is focussed on urban forestry, where you get to plant trees on your street and see how that impacts the tree canopy on your block in 2050.");
            sentences.Enqueue("You have just received City of Vancouver's Neighbourhood Matching Fund of $1,800 for a greening project on your block.");
            sentences.Enqueue("Let's get started! Remember to plant the trees on grassy (aka pervious) areas like the front and back yards and not on concrete (aka impervious) areas like driveways, roads, etc. The more trees you are able to plant, the more canopy cover will be created.");

            DisplayNextSentence();
        }

        public override void HandleNoSentencesLeft()
        {
            UrbanForestryQuestManager.GetInstance().CurrentState = UrbanForestryQuestManager.GameState.Tutorial;
        }
    }

}


