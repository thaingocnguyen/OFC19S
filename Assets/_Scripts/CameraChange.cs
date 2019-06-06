using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {

    public GameObject FirstCam; //0
    public GameObject ThirdCam; //1
    private int camMode;  //first person = 0 ; third person = 1

	// Use this for initialization
	void Start () {
        camMode = 1;
        FirstCam.SetActive(false);
        ThirdCam.SetActive(true);
	}

    // Update is called once per frame
    void Update()
    {
   
    }

    private void OnMouseDown()
    {
        //if (camMode == 0)//if in FirstPerson
        //{
            camMode = 0; //put in third person
        //}
        //else
       // {
       //     camMode = 0; //put in first person
       // }

        StartCoroutine(CamChange());
    }

    public void inThirdPerson()
    {
      //  if (camMode == 0)//if in FirstPerson
       // {
       //     camMode = 1; //put in third person
       // }
       // else
        //{
        camMode = 1; //put in first person
        Debug.Log(camMode);
        StartCoroutine(CamChange());
        //}
    }



    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);

        if(camMode == 0)//first person
        {
            FirstCam.SetActive(true);
            ThirdCam.SetActive(false);
        }
        if (camMode == 1)//third person
        {
            FirstCam.SetActive(false);
            ThirdCam.SetActive(true);
        }
    }
}
