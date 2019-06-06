using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSelector : MonoBehaviour
{

    private int selectedHouse;
    private bool mapView = true;

    [SerializeField] Animator selectBoxAnimator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && mapView)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform && hit.transform.CompareTag("House"))
                {
                    // Center camera on house and display popup house info and select house button
                    CameraCenter(hit.transform.gameObject);
                    selectBoxAnimator.SetBool("IsOnScreen", true);
                }
            }
        }
    }

    public bool MapView
    {
        get { return mapView; }
        set { mapView = value; }
    }

    void CameraCenter(GameObject house)
    {
        switch (house.name)
        {
            case "House1":
                Camera.main.transform.position = new Vector3(-34f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                selectedHouse = 0;
                break;
            case "House2":
                Camera.main.transform.position = new Vector3(-30f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                selectedHouse = 1;
                break;
            case "House3":
                Camera.main.transform.position = new Vector3(1f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                selectedHouse = 2;
                break;
            case "House4":
                Camera.main.transform.position = new Vector3(27f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                selectedHouse = 3;
                break;
            case "House5":
                Camera.main.transform.position = new Vector3(58f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                selectedHouse = 4;
                break;
            case "House6":
                Camera.main.transform.position = new Vector3(62f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                selectedHouse = 5;
                break;
            default:
                break;
        }
    }

    public void SelectHouse()
    {
        selectBoxAnimator.SetBool("IsOnScreen", false);
        GetComponent<BlockSceneManager>().UseCamera(selectedHouse);
    }

}
