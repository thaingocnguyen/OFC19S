using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRQuestions : MonoBehaviour {

    public GameObject question;
    public GameObject answers;
    public Text reply;

	// Use this for initialization
	void Start () {
        question.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnQuestion()
    {
        question.SetActive(true);
    }

    public void ShowReply()
    {
        answers.SetActive(false);
        reply.text = "Thanks! The solar panels are on the roof.";
    }
}
