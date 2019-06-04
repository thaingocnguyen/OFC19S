using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BudgetSystem : MonoBehaviour
{
    public Text budgetText;
    public Text subtractBudgetText;
    public Text ending;

    [SerializeField]
    GameObject energyBar;

    [SerializeField]
    int maxBudget;

    int currentBudget;
    float maxEnergyScore = 100;
    float currentEnergyScore;

    #region Singleton
    public static BudgetSystem Instance;

    private void Awake()
    {
        Instance = this;
        currentEnergyScore = 0;
        updateEnergyBar();
    }
    #endregion Singleton

    // Start is called before the first frame update
    void Start()
    {
        budgetText.text = "Budget: $" + maxBudget;
        currentBudget = maxBudget;
        subtractBudgetText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBudget == 0)
        {
            budgetText.text = "Budget: $0";
            currentBudget = -1;
            StartCoroutine(NoMoney());
        }
    }

    public float EnergyScore
    {
        get { return currentEnergyScore; }
        set { currentEnergyScore = value; }
    }
    public void incrementEnergyScore(int points)
    {
        currentEnergyScore = Mathf.Clamp(currentEnergyScore + points, 0, maxEnergyScore);
        updateEnergyBar();
    }

    public void decrementEnergyScore(int points)
    {
        currentEnergyScore = Mathf.Clamp(currentEnergyScore - points, 0, maxEnergyScore);
        updateEnergyBar();
    }

    private void updateEnergyBar()
    {
        energyBar.transform.localScale = new Vector3(1, currentEnergyScore / maxEnergyScore, 1);
    }

    public IEnumerator DecrementBudget(string tag)
    {
        if (tag == "12000")
        {

            currentBudget = currentBudget - 12000;
            budgetText.text = "Budget: $" + currentBudget;
            subtractBudgetText.text = " -$12000";
        }
        else if (tag == "3000")
        {

            currentBudget = currentBudget - 3000;
            budgetText.text = "Budget: $" + currentBudget;
            subtractBudgetText.text = " -$3000";
        }

        else
        {

            budgetText.text = "Budget: $" + currentBudget;
        }

        yield return new WaitForSeconds(0.7f);
        subtractBudgetText.text = "";
    }

    public IEnumerator IncrementBudget(string tag)
    {
        if (tag == "12000")
        {

            currentBudget = currentBudget + 12000;
            budgetText.text = "Budget: $" + currentBudget;
            subtractBudgetText.text = " +$12000";
        }
        else if (tag == "3000")
        {

            currentBudget = currentBudget + 3000;
            budgetText.text = "Budget: $" + currentBudget;
            subtractBudgetText.text = " +$3000";
        }

        else
        {

            budgetText.text = "Budget: $" + currentBudget;
        }

        yield return new WaitForSeconds(0.7f);
        subtractBudgetText.text = "";
    }

    public bool ifBudgetNotZero(string tag)
    {
        if (tag == "12000")
        {
            if ((currentBudget - 12000) < 0)
            { return false; }
            else { return true; }
        }
        else if (tag == "3000")
        {
            if ((currentBudget - 3000) < 0)
            { return false; }
            else { return true; }
        }

        else { return false; }
    }


    public IEnumerator NoMoney()
    {
        budgetText.text = "";
        ending.text = "You have ran out of money";
        yield return new WaitForSeconds(5f);
        ending.text = "Your energy score is " + currentEnergyScore;
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
        ending.text = "Connecting the solar panels to the grid will give you electrical credit.";
        yield return new WaitForSeconds(5f);
        ending.text = "Would you like to connect your solar panels to the grid?";
        yield return new WaitForSeconds(3f);
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
