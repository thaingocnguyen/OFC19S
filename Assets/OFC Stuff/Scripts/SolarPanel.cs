using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : MonoBehaviour
{
    bool isPanelPlaced;
    // Start is called before the first frame update
    void Start()
    {
        isPanelPlaced = false;
    }

    public bool PanelPlaced
    {
        get { return isPanelPlaced; }
        set { isPanelPlaced = value; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
