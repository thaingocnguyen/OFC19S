using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

    public GameObject solarGame;
    public GameObject solarPanel;
    public GameObject sidecam;
    public GameObject closesidecam;
    public GameObject frontcam;
    public GameObject poles;
    public GameObject equator;
    public GameObject vancouver;
    public GameObject sidelight;
    public GameObject directionBtns;
    public GameObject rotationBtns;
    public GameObject startBtn;
    public GameObject lat;
    public GameObject vanLight;

    public Text lowerText;
    public Text upperText;
    public Text degrees;

    public float waitTime = 2.0f;

    private float angle = 0;

    // Use this for initialization
    void Start () {
        //turn off things
        lowerText.text = " ";
        upperText.text = " ";
        degrees.text = " ";

        poles.SetActive(false);
        vancouver.SetActive(false);
        equator.SetActive(false);
        sidelight.SetActive(true);
        frontcam.SetActive(false);
        closesidecam.SetActive(false);
        lat.SetActive(false);
        vanLight.SetActive(false);
        solarGame.SetActive(false);

        startBtn.SetActive(false);
        directionBtns.SetActive(false);
        rotationBtns.SetActive(false);
        

        sidecam.SetActive(true);

        StartCoroutine(startTutorial(waitTime));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator startTutorial(float time)
    {
        //the earth is tilted 23.5 degrees
        lowerText.text = "Earth is tilted 23.5 degrees.";
        poles.SetActive(true);
        yield return new WaitForSeconds(time);
        
        poles.SetActive(false);

        //direct sunlight is at the equator
        lowerText.text = "The most direct sunlight is at the equator.";
        sidelight.SetActive(false);
        equator.SetActive(true);
        yield return new WaitForSeconds(time);
        

        //where should solar panels face in Vancouver?
        
        lowerText.text = "Which way should the solar panels face to get the MOST sunlight?";
        vancouver.SetActive(true);
        yield return new WaitForSeconds(2*time);
        equator.SetActive(false);
        sidecam.SetActive(false);
        frontcam.SetActive(true);

        directionBtns.SetActive(true);
      

    }

    public void rightChoice()
    {
        lowerText.text = "Right! Direct sunlight is South of Vancouver.";
        StartCoroutine(startTilt(waitTime));
    }

    public void wrongChoice()
    {
        lowerText.text = "Not quite, where is the most direct sunlight is in relation to Vancouver?";

        StartCoroutine(tryAgain());
    }

    public void rotateClockwise()
    {
        

        //if(solarPanel.transform.localEulerAngles.z <= 0 && solarPanel.transform.localEulerAngles.z > -90){
            solarPanel.transform.Rotate(Vector3.forward, -10);
        angle += 10;
        upperText.text = "Try rotating the solar panel to the optimum angle. \n" + angle.ToString() + " degrees";
            
    }

    public void rotateCounterClockwise()
    {
        //Debug.Log(solarPanel.transform.localEulerAngles.z);

        //if(solarPanel.transform.localEulerAngles.z <= 0 && solarPanel.transform.localEulerAngles.z > -90){
        solarPanel.transform.Rotate(Vector3.forward, 10);
        angle -= 10;
        upperText.text = "Try rotating the solar panel to the optimum angle. \n" + angle.ToString() + " degrees";

    }

    public void checkAngle()
    {
        if(angle >= 30 && angle <= 60)
        {
            upperText.text = "Correct! The best angle for vancouver would be between 30 and 60 degrees!";
            StartCoroutine(startQuest(waitTime));
        }
        else
        {
            upperText.text = "Not quite, think about 'why' the equator has the most direct sunlight.";
        }
    }

    private IEnumerator tryAgain()
    {
        directionBtns.SetActive(false);

        sidecam.SetActive(true);
        frontcam.SetActive(false);

        equator.SetActive(true);
        yield return new WaitForSeconds(4);
        equator.SetActive(false);

        sidecam.SetActive(false);
        frontcam.SetActive(true);

        directionBtns.SetActive(true);
       


    }

    private IEnumerator startTilt(float time)
    {
        yield return new WaitForSeconds(time);

        //off with everythingg
        lowerText.text = " ";
        directionBtns.SetActive(false);
        frontcam.SetActive(false); //turn off front cam
        vancouver.SetActive(false);

        closesidecam.SetActive(true); //turn on the close side cam
        lat.SetActive(true);
        upperText.text = "Vancouver is 49° N of the equator";
        yield return new WaitForSeconds(time);

        upperText.text = "The sun's rays are at an angle with Vancouver";
        vanLight.SetActive(true);
        yield return new WaitForSeconds(time);

        upperText.text = "Solar panels needs direct sunlight to produce power";
        yield return new WaitForSeconds(time);

        upperText.text = "What angle would produce the most power?";
        yield return new WaitForSeconds(time);

        closesidecam.SetActive(false);
        solarGame.SetActive(true);
        rotationBtns.SetActive(true);
        upperText.text = "Try rotating the solar panel to the optimum angle. \n 0 degrees" ;
        //degrees.text = "0 degrees";
    }

    private IEnumerator startQuest(float time)
    {
        rotationBtns.SetActive(false);
        yield return new WaitForSeconds(time);
        
        upperText.text = "Great Job! Now let's begin placing solar panels on roofs";
        startBtn.SetActive(true);
        yield return new WaitForSeconds(time);



    }

}
