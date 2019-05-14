using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BudgetSystem : MonoBehaviour
{
    public Text budgetTxt;
    public Text subtractBudgetTxt;
    public Text ending;
    public GameObject SolarButtons;
    public GameObject YesNoButtons;

    public GameObject energyBar;
    int energyScore;

    [SerializeField]
    int maxBudget;
    int maxEnergyScore;

    #region Singleton
    public static BudgetSystem Instance;

    private void Awake()
    {
        Instance = this;
        energyScore = 0; 
    }
    #endregion Singleton

    // Start is called before the first frame update
    void Start()
    { 
        budgetTxt.text = "Budget: " + maxBudget;
        subtractBudgetTxt.text = "";
        ending.text = "";
        SolarButtons.SetActive(false);
        YesNoButtons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (maxBudget == 0)
        {
            budgetTxt.text = "Budget: 0";
            maxBudget = -1;
            StartCoroutine(NoMoney());
        }
    }

    public void incrementEnergyScore(int points)
    {
        energyScore = Mathf.Clamp(energyScore + points, 0, maxEnergyScore);
        updateEnergyBar();
    }

    private void updateEnergyBar()
    {
        energyBar.transform.localScale = new Vector3(energyScore / maxEnergyScore, 1, 1);
    }

    public IEnumerator DecrementBudget(string tag)
    {
        if (tag == "12000")
        {

            maxBudget = maxBudget - 12000;
            budgetTxt.text = "Budget: " + maxBudget;
            subtractBudgetTxt.text = " -$12000";
        }
        else if (tag == "3000")
        {

            maxBudget = maxBudget - 3000;
            budgetTxt.text = "Budget: " + maxBudget;
            subtractBudgetTxt.text = " -$3000";
        }

        else
        {

            budgetTxt.text = "Budget: " + maxBudget;
        }

        yield return new WaitForSeconds(0.7f);
        subtractBudgetTxt.text = "";
    }

    public IEnumerator IncrementBudget(string tag)
    {
        if (tag == "12000")
        {

            maxBudget = maxBudget + 12000;
            budgetTxt.text = "Budget: " + maxBudget;
            subtractBudgetTxt.text = " +$12000";
        }
        else if (tag == "3000")
        {

            maxBudget = maxBudget + 3000;
            budgetTxt.text = "Budget: " + maxBudget;
            subtractBudgetTxt.text = " +$3000";
        }

        else
        {

            budgetTxt.text = "Budget: " + maxBudget;
        }

        yield return new WaitForSeconds(0.7f);
        subtractBudgetTxt.text = "";
    }

    public bool ifBudgetNotZero(string tag)
    {
        if (tag == "12000")
        {
            if ((maxBudget - 12000) < 0)
            { return false; }
            else { return true; }
        }
        else if (tag == "3000")
        {
            if ((maxBudget - 3000) < 0)
            { return false; }
            else { return true; }
        }

        else { return false; }
    }


    public IEnumerator NoMoney()
    {
        budgetTxt.text = "";
        ending.text = "You have ran out of money";
        yield return new WaitForSeconds(5f);
        ending.text = "Your energy score is " + engScore.score;
        SolarButtons.SetActive(true);
        yield return new WaitForSeconds(1f);


    }

    public void RestartGame()
    {
        Application.Quit();
    }

    public void DonePls()
    {
        StartCoroutine(ContinueGame());
    }

    public IEnumerator ContinueGame()
    {
       
        
        SolarButtons.SetActive(false);
        ending.text = "Connecting the solar panels to the grid will give you electrical credit.";
        yield return new WaitForSeconds(5f);
        ending.text = "Would you like to connect your solar panels to the grid?";
        yield return new WaitForSeconds(3f);
        YesNoButtons.SetActive(true);
        
    }

    public IEnumerator NoThanks()
    {


        
        ending.text = "Aww.";
        yield return new WaitForSeconds(2f);
        Application.Quit();


    }

    public IEnumerator SureWhyNot()
    {



        ending.text = "Awesome!";
        yield return new WaitForSeconds(2f);
        Application.Quit();


    }


}
