using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BudgetSystem : MonoBehaviour
{
    public Text budgetText;
    public Text subtractBudgetText;

    [SerializeField] int maxBudget = 90000;
    int currentBudget;

    #region Singleton
    public static BudgetSystem Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion Singleton



    // Start is called before the first frame update
    void Start()
    {
        budgetText.text = "Budget: $" + maxBudget;
        currentBudget = maxBudget;
        subtractBudgetText.text = "";
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
}
