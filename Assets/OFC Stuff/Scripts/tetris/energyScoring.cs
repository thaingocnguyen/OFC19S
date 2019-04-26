using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyScoring : MonoBehaviour
{
	public int count = 0;
	public bool isPlaced = false;
    public float score = 0f;
    public energyBar engBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (count == 6) {
    		isPlaced = true;
    	} else if (count < 6) {
    		isPlaced = false;
    	}

        engBar.SetSize(score *0.0182f);


    }
}
