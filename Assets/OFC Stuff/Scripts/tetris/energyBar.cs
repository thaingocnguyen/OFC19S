using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyBar : MonoBehaviour

{
    private Transform bar;

    // Start is called before the first frame update
    private void Start()
    {
        bar = transform.Find("Bar");
       //bar.localScale = new Vector3(-0.4f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSize(float sizeNorm)
    {
        bar.localScale = new Vector3(-1f * sizeNorm, 1f, 1f);
    }
}
