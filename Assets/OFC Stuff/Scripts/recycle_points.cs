using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recycle_points : MonoBehaviour {

    public GameObject blue_bin;
    public Text scoreSystem;
    public string type;
    public GameObject stopper;
    private int score;
    public GameObject bluePile;
    private bool hasStopped = false;
    public bool isHit = false;
    public bool isGarbage = false;

	// Use this for initialization
	void Start () {
        score = 0;
        bluePile.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (isHit)
        {
            blue_bin.gameObject.transform.position = transform.position;
        }
        if (hasStopped == true && isGarbage == false )
        {
            // Debug.Log("GARBAGE ALERT");
            bluePile.SetActive(true);
            blue_bin.gameObject.transform.position = bluePile.gameObject.transform.position;

        }
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == stopper)
        {
            Debug.Log("STOP");
            isHit = false;
            hasStopped = true;
        }

        if (other.gameObject == blue_bin && type == "recycle")
        {
            score++;
            Debug.Log("HIT!");
            isHit = true;
            isGarbage = true;
            scoreSystem.text = "Score: " + score;
            blue_bin.gameObject.transform.position = transform.position;
        }
    }
}
