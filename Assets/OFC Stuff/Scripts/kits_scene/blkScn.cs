 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class blkScn : MonoBehaviour
{

	Ray ray;
    RaycastHit hit;

    private float moveSpeed = 12.2f;

    // Go back button 
    public GameObject brdBtn;

    //[HideInInspector]
    public Transform mainTrans;
    //[HideInInspector]
	public Transform house_1;
	//[HideInInspector]
	public Transform house_2;
	//[HideInInspector]
	public Transform house_3;
	//[HideInInspector]
	public Transform house_4;
	//[HideInInspector]
	public Transform house_5;
	//[HideInInspector]
	public Transform house_6;
	//[HideInInspector]
	public Transform house_7;
	//[HideInInspector]
	public Transform house_8;

	//[HideInInspector]
	public GameObject infoBox_1;
	//[HideInInspector]
	public GameObject infoBox_2;
	//[HideInInspector]
	public GameObject infoBox_3;
	//[HideInInspector]
	public GameObject infoBox_4;
	//[HideInInspector]
	public GameObject infoBox_5;
	//[HideInInspector]
	public GameObject infoBox_6;
	//[HideInInspector]
	public GameObject infoBox_7;
	//[HideInInspector]
	public GameObject infoBox_8;

	public energyScoring h1;
	public energyScoring h2;
	public energyScoring h3;
	public energyScoring h4;
	public energyScoring h5;
	public energyScoring h6;
	public energyScoring h7;
	public energyScoring h8;

    // Whether camera is at bird eye view or house view.
    //  - True: Bird eye view 
    //  - False: House view 
	private bool isBird = true;

	public int houses = 5;
	private bool minOne = true;
	private bool minTwo = true;
	private bool minThree = true;
	private bool minFour = true;
	private bool minFive = true;
	private bool minSix = true;
	private bool minSeven = true;
	private bool minEight = true;

	public Text score;



    // Start is called before the first frame update
    void Start()
    {
        infoBox_1.SetActive(false);
        infoBox_2.SetActive(false);
        infoBox_3.SetActive(false);
        infoBox_4.SetActive(false);
        infoBox_5.SetActive(false);
        infoBox_6.SetActive(false);
        infoBox_7.SetActive(false);
        infoBox_8.SetActive(false);
        //mainTrans = Camera.main.transform;	
        brdBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Continuously checks to see if house is selected 
    	houseSelector("HOUSE1", house_1, infoBox_1);
    	houseSelector("HOUSE2", house_2, infoBox_2);
    	houseSelector("HOUSE3", house_3, infoBox_3);
    	houseSelector("HOUSE4", house_4, infoBox_4);
    	houseSelector("HOUSE5", house_5, infoBox_5);
    	houseSelector("HOUSE6", house_6, infoBox_6);
    	houseSelector("HOUSE7", house_7, infoBox_7);
    	houseSelector("HOUSE8", house_8, infoBox_8);

 		placingHouses();

 		score.text = "HOUSE COUNT: " + houses.ToString();



        
    }

    private void placingHouses () {
    	if (h1.isPlaced  && minOne) {
    		houses--;
    		minOne = false;
    	} else if (!h1.isPlaced && !minOne) {
    		houses++;
    		minOne = true;
    	}

    	if (h2.isPlaced  && minTwo) {
    		houses--;
    		minTwo = false;
    	} else if (!h2.isPlaced && !minTwo) {
    		houses++;
    		minTwo = true;
    	}

    	if (h3.isPlaced  && minThree) {
    		houses--;
    		minThree = false;
    	} else if (!h3.isPlaced && !minThree) {
    		houses++;
    		minThree = true;
    	}

    	if (h4.isPlaced  && minFour) {
    		houses--;
    		minFour = false;
    	} else if (!h4.isPlaced && !minFour) {
    		houses++;
    		minFour = true;
    	}

    	if (h5.isPlaced  && minFive) {
    		houses--;
    		minFive = false;
    	} else if (!h5.isPlaced && !minFive) {
    		houses++;
    		minFive = true;
    	}

    	if (h6.isPlaced  && minSix) {
    		houses--;
    		minSix = false;
    	} else if (!h6.isPlaced && !minSix) {
    		houses++;
    		minSix = true;
    	}

    	if (h7.isPlaced  && minSeven) {
    		houses--;
    		minSeven = false;
    	} else if (!h7.isPlaced && !minSeven) {
    		houses++;
    		minSeven = true;
    	}

    	if (h8.isPlaced  && minEight) {
    		houses--;
    		minEight = false;
    	} else if (!h8.isPlaced && !minEight) {
    		houses++;
    		minEight = true;
    	}
    }

    private void houseSelector(string name, Transform target, GameObject infoBox) {
    	if (Physics.Raycast (ray, out hit) ) {
    		//!! COMPUTER BUILD !!//
    		if (hit.collider.tag == name && Camera.main.transform.position != target.position && isBird ) {
    			infoBox.SetActive(true);
    		} else {
    			infoBox.SetActive(false);
    		}
    		//!! COMPUTER BUILD !!//

    		if (Input.GetMouseButtonDown (0) && isBird && houses > 0) {
				if (hit.collider.tag == name ) {
					Debug.Log(hit.collider.tag);
					Camera.main.transform.position = target.position;
					Camera.main.transform.rotation = target.rotation;
					isBird = false;
					brdBtn.SetActive(true);
				}
			}
    	}

    }

    public void mainView() {
    	Camera.main.transform.position = mainTrans.position;
		Camera.main.transform.rotation = mainTrans.rotation;
		isBird = true;
		brdBtn.SetActive(false);
    }

    public void infoBox1() {
    	if (!infoBox_1.activeSelf) {
    		infoBox_1.SetActive(true);
    	} else {
    		infoBox_1.SetActive(false);
    	}
    }

    public void infoBox2() {
    	if (!infoBox_2.activeSelf) {
    		infoBox_2.SetActive(true);
    	} else {
    		infoBox_2.SetActive(false);
    	}
    }

    public void infoBox3() {
    	if (!infoBox_3.activeSelf) {
    		infoBox_3.SetActive(true);
    	} else {
    		infoBox_3.SetActive(false);
    	}
    }

    public void infoBox4() {
    	if (!infoBox_4.activeSelf) {
    		infoBox_4.SetActive(true);
    	} else {
    		infoBox_4.SetActive(false);
    	}
    }

    public void infoBox5() {
    	if (!infoBox_5.activeSelf) {
    		infoBox_5.SetActive(true);
    	} else {
    		infoBox_5.SetActive(false);
    	}
    }
}
