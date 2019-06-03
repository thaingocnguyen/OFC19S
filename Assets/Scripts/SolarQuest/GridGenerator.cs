using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {
    [SerializeField]
    GameObject gridCubePrefab;
    [SerializeField]
    int row;
    [SerializeField]
    int col;
    Vector3 pos;
    Vector3 newPos;
    Vector3[] posArray;
    float space = 1.5f;
    int c;
    int r;
    int i = 0;
    int size = 1;
    Vector3 result;

    void Awake()
    {
        size = col * row;
        posArray = new Vector3[size];        
    }


    // Use this for initialization
    void Start () {
        MakePuzzle();
        pos = transform.position;       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void MakePuzzle()
    {
        pos = gameObject.transform.position;
        for(r = 0; r < row; r++)
        {
            for(c = 0; c < col; c++)
            {

     
                GameObject gridCube = Instantiate(gridCubePrefab, pos, transform.rotation);
                gridCube.transform.parent = transform;
                gridCube.transform.localPosition = new Vector3(0, 0, 0);
                gridCube.transform.localRotation = Quaternion.identity;

                pos = gridCube.transform.localPosition;
                newPos = new Vector3(pos.x + space * c, pos.y + space * r, pos.z);
                gridCube.transform.localPosition = newPos;

                posArray[i] = gridCube.transform.position;
                i++;

            }
                      
        }
       
        
    }

    
    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {

        float smallestDistance = 8f;
        result = new Vector3(0, 0, 0);

        for (int count = 0; count < posArray.Length - 1; count++)
        {
            float distance = Vector3.Distance(position, posArray[count]);
            if(distance < smallestDistance)
            {
                result = posArray[count];
                smallestDistance = distance;
            }
            
        }

        return result;
    }
}