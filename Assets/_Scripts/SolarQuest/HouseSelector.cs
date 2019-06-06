using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform && hit.transform.CompareTag("House"))
                {
                    // Center camera on house and display popup house info and select house button
                    CameraCenter(hit.transform.gameObject);
                }
            }
        }
    }

    void CameraCenter(GameObject house)
    {

        switch (house.name)
        {
            case "House1":
                Camera.main.transform.position = new Vector3(-34f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                break;
            case "House2":
                Camera.main.transform.position = new Vector3(-30f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                break;
            case "House3":
                Camera.main.transform.position = new Vector3(1f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                break;
            case "House4":
                Camera.main.transform.position = new Vector3(27f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                break;
            case "House5":
                Camera.main.transform.position = new Vector3(58f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                break;
            case "House6":
                Camera.main.transform.position = new Vector3(62f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                break;
            default:
                break;
        }
    }

}
