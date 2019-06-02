using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solar_selection : MonoBehaviour {

	Ray ray;
	RaycastHit hit;

	public object_clicker objClick;

	public List<GameObject> housePanels;

	// Use this for initialization
	void Start () {
		housePanels = new List<GameObject>();

		//objClick = new object_clicker ();

		foreach (Transform child in transform) {
			if (child.tag == "panels") {
				housePanels.Add (child.gameObject);
			}
		}

		foreach (GameObject go in housePanels) {
			go.SetActive (false);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		selection ();
		//Debug.Log (objClick.houseView);
		
	}

	void selection() {
		
		if (objClick.houseView) {
			foreach (GameObject go in housePanels) {
				go.SetActive (true);
			}
		} else {
			foreach (GameObject go in housePanels) {
				go.SetActive (false);
			}
		} 

		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.tag == "panels") {
				Debug.Log ("hi");
			}
		}
	}

}
