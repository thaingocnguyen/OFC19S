using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SolarQuestQuiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI quizText;
    [SerializeField] GameObject compassButtons;
    [SerializeField] GameObject continueButton;
    [SerializeField] int maxAttempts = 3;

    private int currentAttempts;


    private void Start()
    {
        currentAttempts = 0;
        continueButton.SetActive(false);
    }
    private void Update()
    {
        if(currentAttempts == maxAttempts)
        {
            NoAttemptsLeft();
        }
    }

    public void SelectedSouth()
    {
        compassButtons.SetActive(false);
        quizText.text = "Right! Solar panels should be placed on south-facing roofs.";
        EndQuiz();

    }

    public void SelectedWrongAnswer()
    {
        currentAttempts++;
        if (currentAttempts == 1)
        {
            quizText.text = "Not quite... Try again.";
        }
        else if (currentAttempts == 2)
        {
            quizText.text = "Remember that you can go back. You have 1 last attempt.";
        }
        
    }

    private void NoAttemptsLeft()
    {
        compassButtons.SetActive(false);
        quizText.text = "Solar panels should be placed on south-facing roofs";
        EndQuiz();
    }

    private void EndQuiz()
    {
        continueButton.SetActive(true);
    }
}
