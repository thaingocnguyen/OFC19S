using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class object_clicker : MonoBehaviour {

    Ray ray;
    RaycastHit hit;

    public GameObject houseTwoBox;
    public GameObject houseTwoSel;

    public GameObject bgHouseOne;
    public GameObject bgHouseOneSel;

    public GameObject bgHouseTwo;
    public GameObject bgHouseTwoSel;

    public GameObject bgHouseThree;
    public GameObject bgHouseThreeSel;

    public GameObject bgHouseFour;
    public GameObject bgHouseFourSel;

    public GameObject bgHouseFive;
    public GameObject bgHouseFiveSel;

    private bool loadedClick = false;
    private int selectedHouse = 0;

    public GameObject startButton;
	private float moveSpeed = 12.2f;
	private float viewSpeed = 7.2f;

	public Transform target1;
	public Transform target2;
	public Transform target3;
	public Transform target4;
	public Transform target5;
	public Transform target6;
	public Transform bTarget;
	public Transform nrmlView;

	public bool brdEye = true;
	public bool nrmlEye = true;
	public bool houseView = false;
	private bool houseSelectedb = false;

	public GameObject normalViewBtn;
	public GameObject birdViewBtn;

	private List<GameObject> selectedHouses;



    private void Start()
    {

        startButton.SetActive(false);

        houseTwoBox.SetActive(false);
        bgHouseOne.SetActive(false);
        bgHouseTwo.SetActive(false);
        bgHouseThree.SetActive(false);
        bgHouseFour.SetActive(false);
        bgHouseFive.SetActive(false);

        houseTwoSel.SetActive(false);
        bgHouseOneSel.SetActive(false);
        bgHouseTwoSel.SetActive(false);
        bgHouseThreeSel.SetActive(false);
        bgHouseFourSel.SetActive(false);
        bgHouseFiveSel.SetActive(false);
	
		//normalViewBtn.SetActive (false);
		selectedHouses = new List<GameObject>();

    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		interacterHouse("house2", houseTwoBox, houseTwoSel,target1);
		interacterHouse("bgHouseOne", bgHouseOne, bgHouseOneSel,target2);
		interacterHouse("bgHouseTwo", bgHouseTwo, bgHouseTwoSel,target4);
		interacterHouse("bgHouseThree", bgHouseThree, bgHouseThreeSel,target3);
		interacterHouse("bgHouseFour", bgHouseFour, bgHouseFourSel,target5);
		interacterHouse("bgHouseFive", bgHouseFive, bgHouseFiveSel,target6);

		if (selectedHouses.Count == 3)
        {
            startButton.SetActive(true);
        }




		//btnSwitching ();


    }


	private void interacterHouse(string name, GameObject go, GameObject sgo, Transform targ)
	{
		if (Physics.Raycast (ray, out hit) ) {
			if (hit.collider.tag == name) {
				go.SetActive (true);
			}

			if (Input.GetMouseButtonDown (0)) {


				if (hit.collider.tag == name ) {

					if (selectedHouses.Count < 3) {
						sgo.SetActive (true);
						//houseView = true;
					}
					if (!selectedHouses.Contains (sgo)) {
						selectedHouses.Add (sgo);
					}

				}
			}

		} else {
			go.SetActive (false);
		}
			

		if (sgo.activeSelf ) {
			go.SetActive (false);
			houseView = true;
			Camera.main.transform.position = Vector3.Slerp (Camera.main.transform.position, targ.position, moveSpeed * 2 * Time.deltaTime);
			Camera.main.transform.rotation = Quaternion.Slerp (Camera.main.transform.rotation, targ.rotation, moveSpeed * 2 * Time.deltaTime);

		}
		if (brdEye == false) {
			sgo.SetActive (false);
			Camera.main.transform.position = Vector3.Slerp (Camera.main.transform.position, bTarget.position, viewSpeed * 2 * Time.deltaTime);
			Camera.main.transform.rotation = Quaternion.Slerp (Camera.main.transform.rotation, bTarget.rotation, viewSpeed * 2 * Time.deltaTime);
			if (Camera.main.transform.position == bTarget.position) {
				brdEye = true;
				//houseView = false;
			}
		}

		if (nrmlEye == false) {
			sgo.SetActive (false);
			Camera.main.transform.position = Vector3.Slerp (Camera.main.transform.position, nrmlView.position, viewSpeed * 2 * Time.deltaTime);
			Camera.main.transform.rotation = Quaternion.Slerp (Camera.main.transform.rotation, nrmlView.rotation, viewSpeed * 2 * Time.deltaTime);
			if (Camera.main.transform.position == nrmlView.position) {
				nrmlEye = true;
				houseView = false;
			}
		}


	}

    public void beginButton()
    {
        SceneManager.LoadScene("TETRIS_two", LoadSceneMode.Single);
    }

	public void brdsEyeView()
	{
		
		brdEye = false;


	}

	public void normalView() {
		nrmlEye = false;
	}




   
}
