using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionBtn : MonoBehaviour {
    public GameObject sphere;
    public Material onClickMat;
    public Material normMat;
    public GameObject missionDial;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseEnter()
    {
        sphere.GetComponent<Renderer>().sharedMaterial = onClickMat;
        
    }

    private void OnMouseExit()
    {
        sphere.GetComponent<Renderer>().sharedMaterial = normMat;
    }

    private void OnMouseDown()
    {
        missionDial.SetActive(missionDial);
    }

    public void onExit()
    {
        missionDial.SetActive(false);
    }


}
