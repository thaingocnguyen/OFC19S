using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePuzzle : MonoBehaviour {
    public GameObject prefab;
    public GameObject parent;
    public int row;
    public int col;
    Vector3 pos;
    Vector3 newPos;
    Vector3 parentPos;
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
        
        //parentPos = parent.transform.position;
        MakePuzzle();
        pos = parent.transform.position;
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void MakePuzzle()
    {
        for(r = 0; r < row; r++)
        {
            for(c = 0; c < col; c++)
            {
                
               
                GameObject child = Instantiate(prefab, pos, Quaternion.identity);
                
                child.transform.parent = parent.transform;
                child.transform.localPosition = new Vector3(0, 0, 0);
                child.transform.localRotation = Quaternion.identity;

                newPos = new Vector3(child.transform.localPosition.x + space * c, child.transform.localPosition.y + space * r, child.transform.localPosition.z);
                child.transform.localPosition = newPos;

                i = i + 1;
                posArray[i-1] = child.transform.position;
                
            }
                      
        }
       
        
    }

    
    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        float smallestDistance = 2f;
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