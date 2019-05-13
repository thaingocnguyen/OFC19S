using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : MonoBehaviour
{
    // Whether panel has been placed on the grid or is still in pile 
    bool isPanelPlaced;
    // Whether this house is shaded by a shadow or not 
    // Temporary solution for house8 where we want the energy not to be incremented as the roof is shaded
    public bool isShaded;
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
