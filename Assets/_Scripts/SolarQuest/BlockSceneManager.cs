using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSceneManager : MonoBehaviour
{
    [SerializeField] InfoPanel infoPanel;
    // Start is called before the first frame update
    void Start()
    {
        infoPanel.ShowInfoPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
