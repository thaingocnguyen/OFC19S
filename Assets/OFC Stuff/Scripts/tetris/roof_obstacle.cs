using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roof_obstacle : MonoBehaviour {

    public bool hitOnObstacle = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "tetrisObj")
        {
            //Debug.Log("hit");
            hitOnObstacle = true;
        }
    }

    

   
}
