using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace UrbanForestryQuest
{
    public class BudgetManager : MonoBehaviour
    {
        [SerializeField] int maxBudget = 1000;
        [SerializeField] TextMeshProUGUI currentBudgetText;
        [SerializeField] int treePrice = 100;

        [SerializeField] GameObject decrementText;
        [SerializeField] GameObject incrementText;

        private int currentBudget;


        #region Singleton
        private static BudgetManager instance = null;
        public static BudgetManager GetInstance()
        {
            return instance;
        }

        private void Awake()
        {
            instance = this;
        }
        #endregion

        private void Start()
        {
            decrementText.SetActive(false);
            incrementText.SetActive(false);

            currentBudget = maxBudget;
            UpdateBudgetText();
        }

        public void DecrementBudget()
        {
            if (currentBudget - treePrice < 0)
            {
                // Display out of budget message
            }
            else
            {
                currentBudget -= treePrice;
                UpdateBudgetText();
                StartCoroutine(DecrementBudgetCoroutine());
            }
        }

        public void IncrementBudget()
        {
            currentBudget += treePrice;
            UpdateBudgetText();
            StartCoroutine(IncrementBudgetCoroutine());
        }

        private void UpdateBudgetText()
        {
            currentBudgetText.text = "$" + currentBudget.ToString();
        }

        private IEnumerator DecrementBudgetCoroutine()
        {
            decrementText.SetActive(true);
            yield return new WaitForSeconds(0.7f);
            decrementText.SetActive(false);
        }

        private IEnumerator IncrementBudgetCoroutine()
        {
            incrementText.SetActive(true);
            yield return new WaitForSeconds(0.7f);
            incrementText.SetActive(false);
        }
    }
}

