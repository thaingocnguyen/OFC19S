using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluationManager : MonoBehaviour {

    public GameObject solarGame;
    public GameObject solarPanel;
    public GameObject sidecam;
    public GameObject closesidecam;
    public GameObject frontcam;
    public GameObject poles;
    public GameObject equator;
    public GameObject rio;
    public GameObject sidelight;
    public GameObject directionBtns;
    public GameObject rotationBtns;
    public GameObject lat;
    public GameObject rioLight;

    public Text lowerText;
    public Text upperText;
    public Text degrees;

    public float waitTime = 2.0f;

    private float angle = 0;

    // Use this for initialization
    void Start()
    {
        //turn off things
        lowerText.text = " ";
        upperText.text = " ";
        degrees.text = " ";

        poles.SetActive(false);
        rio.SetActive(false);
        equator.SetActive(false);
        sidelight.SetActive(true);
        frontcam.SetActive(false);
        closesidecam.SetActive(false);
        lat.SetActive(false);
        rioLight.SetActive(false);
        solarGame.SetActive(false);


        directionBtns.SetActive(false);
        rotationBtns.SetActive(false);


        sidecam.SetActive(true);

        StartCoroutine(startEvaluation(waitTime));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator startEvaluation(float time)
    {
        //let's review
        lowerText.text = "Good job! Let's review to see if you understand the content.";
        poles.SetActive(true);
        equator.SetActive(true);
        yield return new WaitForSeconds(time);

        //Can you see Mebourne?
        lowerText.text = "Take a look at where Rio De Janeiro is.";
        rio.SetActive(true);
        yield return new WaitForSeconds(time);


        //where should solar panels face in Melbourne?
        sidelight.SetActive(false);
        lowerText.text = "Which way should the solar panels face to get the MOST sunlight?";
        rio.SetActive(true);
        yield return new WaitForSeconds(2 * time);
        equator.SetActive(false);
        sidecam.SetActive(false);
        frontcam.SetActive(true);

        directionBtns.SetActive(true);
        }

    public void rightChoice()
    {
        lowerText.text = "Right! Direct sunlight is North of Rio De Janeiro";
        StartCoroutine(startTilt(waitTime));
    }

    public void wrongChoice()
    {
        lowerText.text = "Not quite, direct sunlight is North of Rio De Janeiro";
        StartCoroutine(tryAgain());
        
    }

    public void rotateClockwise()
    {
        solarPanel.transform.Rotate(Vector3.forward, -10);
        angle += 10;
        upperText.text = "Try rotating the solar panel to the optimum angle. \n" + angle.ToString() + " degrees";

    }

    public void rotateCounterClockwise()
    {
        
        solarPanel.transform.Rotate(Vector3.forward, 10);
        angle -= 10;
        upperText.text = "Try rotating the solar panel to the optimum angle. \n" + angle.ToString() + " degrees";

    }

    public void checkAngle()
    {
        if (angle >= 0 && angle <= 30)
        {
            upperText.text = "Correct! The best angle for Rio De Janeiro would be between 0 and 30 degrees!";
        }
        else
        {
            upperText.text = "Not quite, the best angle for Rio De Janeiro would be between 0 and 30 degrees.";
        }
    }

    private IEnumerator tryAgain()
    {
        directionBtns.SetActive(false);

        sidecam.SetActive(true);
        frontcam.SetActive(false);

        equator.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        equator.SetActive(false);
        
        StartCoroutine(startTilt(waitTime));
     }

    private IEnumerator startTilt(float time)
    {
        yield return new WaitForSeconds(time);

        //off with everythingg
        lowerText.text = " ";
        directionBtns.SetActive(false);
        frontcam.SetActive(false); //turn off front cam
        rio.SetActive(false);

        closesidecam.SetActive(true); //turn on the close side cam
        lat.SetActive(true);
        upperText.text = "Rio De Janeiro is 23° S of the equator";
        yield return new WaitForSeconds(time);
       
        rioLight.SetActive(true);        
        upperText.text = "What angle would produce the most power?";
        yield return new WaitForSeconds(time);

        closesidecam.SetActive(false);
        solarGame.SetActive(true);
        rotationBtns.SetActive(true);
        upperText.text = "Try rotating the solar panel to the optimum angle. \n 0 degrees";
        
    }
}
