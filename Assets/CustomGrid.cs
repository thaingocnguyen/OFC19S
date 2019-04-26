using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGrid : MonoBehaviour {

    
    public GameObject prefab;
    public int row;
    public int col;
    private Vector3 pos;
    private Vector3 newPos;

	// Use this for initialization
	void Start () {
        makeGrid();
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void makeGrid()
    {
        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                Instantiate(prefab, new Vector3(pos.x, pos.y, pos.z + 0.5f), Quaternion.identity);
            }
            Instantiate(prefab, new Vector3(pos.x, pos.y + 0.5f, pos.z), Quaternion.identity);
        }
    }

    
}
