using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarQuestManager : MonoBehaviour
{
    public Camera startCam;
    public Camera questCam;


    // Start is called before the first frame update
    void Start()
    {
        startCam.enabled = true;
        questCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    { 
    }
}
