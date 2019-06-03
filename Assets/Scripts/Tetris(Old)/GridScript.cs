using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour {

    public int NumberOfColumns = 10;
    public int NumberOfRows = 10;

    public float seperatorX = 0.0f;
    public float seperatorZ = 0.0f;

    private float tempSepX = 0;
    private float tempSepZ = 0;

	// Use this for initialization
	void Start () {
        createGrid();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void createGrid()
    {
        for (int i = 0; i < NumberOfColumns; i++)
        {
            for (int j = 0; j < NumberOfRows; j++)
            {
                GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Quad);
                plane.transform.position = new Vector3(i+ transform.position.x,0, j + transform.position.z);
                plane.transform.eulerAngles = new Vector3(90f, 0, 0);  //new Vector3(90f, 0, 0);
                Debug.Log(transform.rotation.x);
                tempSepZ += seperatorZ;
            }
                tempSepX += seperatorX;//change the value of seperation between columns
                tempSepZ = 0;
            }
    }

}
