using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tutorial : MonoBehaviour
{
    public string tutorialName;
    public static float energyScore = 0;

    public string[] sentences =
        {
        "Hi there! I'm Renewable Rene뮠I believe that the bigger impact will come from using renewable energy resources and no reliance on fossil fuels. Food waste is just a drop in the bucket.",
        "In this quest, we will learn more about solar panels.",
        "In order to be the most efficient, solar panels needs as much sunlight as possible. The position of solar panels on roofs of houses are thus very important. We will learn a bit more about how to determine this.",
        "Vancouver is North of the equator. The most direct sunlight is at the equator. With this information, can you determine the direction from which Vancouver receives the most sunlight?",
        "Let's try out a quick activity to answer this question!"
        };

    public string[] quizSentences =
    {
        "Applying what you've learnt, which direction should solar panels face in order to receive the most sunlight?"
    };

    public string[] endingSentences =
    {
        "Congratulations! Your energy score is: " + energyScore,
        "In BC, you can choose to connect your solar panels to the electricity grid. If your solar panel produces more power than your household consumes, the surplus is fed into the grid for others to use. In BC, you can obtain BC Grid Credits by doing so. You can use BC Grdi Credits to reduce the price you pay for electricity  on the days where there is not as much sunlight. Sounds like a win-win situation!",
        "Now, let's try retrofitting an entire block with solar panels! Remember what you've learnt about roof direction and be mindful of the budget vs. energy tradeoffs."
    };


}
