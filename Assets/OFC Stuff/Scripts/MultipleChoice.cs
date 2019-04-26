using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleChoice : MonoBehaviour {

    public GameObject Question;

	// Use this for initialization
	void Start () {
        Question.SetActive(false);
	}

    void OnMouseDown()
    {
        Question.SetActive(true);
    }

}
