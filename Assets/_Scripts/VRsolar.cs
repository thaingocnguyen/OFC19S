using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRsolar : MonoBehaviour {

    public GameObject miniGame;
    //public GameObject solarCam;
    //public GameObject player;
    public GameObject sparkles;
    public GameObject text;
    public GameObject question;
    public GameObject clockWise;
    public GameObject counterClockWise;
    float rotSpeed = 500f;
    float yPos;
    bool wonGame = false;


    // Use this for initialization
    void Start()
    {
        miniGame.SetActive(false);
        sparkles.SetActive(false);
        text.SetActive(false);
        question.SetActive(false);
        clockWise.SetActive(false);
        counterClockWise.SetActive(false);
    }

    void Update()
    {

        yPos = this.transform.eulerAngles.y;

        if (yPos > 250 && yPos < 290 && !wonGame)
        {
            StartCoroutine(winGame());
            Debug.Log("wonGame");
            wonGame = true;
        }

    }

    //Rotate Solarpanel Clockwise
    public void RotateClockwise()
    {
        float xRot = rotSpeed * Mathf.Deg2Rad;

        this.transform.Rotate(Vector3.up, -xRot);
        Debug.Log("rotating ClockWise");
    }

    public void RotateCounterClockwise()
    {
        float xRot = rotSpeed * Mathf.Deg2Rad;

        this.transform.Rotate(Vector3.up, xRot);
        Debug.Log("rotating Counter ClockWise");
    }

    // Update is called once per frame
    /*void OnMouseDrag () {
        float xRot = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;

        this.transform.Rotate(Vector3.up, -xRot);
        Debug.Log("rotating");
		
	}*/

    public void ShowMinigame()
    {
        miniGame.SetActive(true);
        //solarCam.SetActive(false);


    }

    public void StartMinigame()
    {
        //player.SetActive(false);
        //solarCam.SetActive(true);
        question.SetActive(true);
        clockWise.SetActive(true);
        counterClockWise.SetActive(true);

    }




    private IEnumerator winGame()
    {
        sparkles.SetActive(true);
        text.SetActive(true);
        question.SetActive(false);


        yield return new WaitForSeconds(3f);

        text.SetActive(false);
        //solarCam.SetActive(false);
        //player.SetActive(true);
        clockWise.SetActive(false);
        counterClockWise.SetActive(false);
    }
}
