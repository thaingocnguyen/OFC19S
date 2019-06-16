using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    [SerializeField] GameObject gridCubePrefab;
    [SerializeField] int row;
    [SerializeField] int col;

    Vector3 pos;
    Vector3 newPos;
    Vector3[,] posArray;
    bool[,] occupied;
    float space = 1.5f;

    private float size;
    private float gridScore;

    void Awake()
    {
        posArray = new Vector3[row, col];
        occupied = new bool[row + 2, col + 2];
        size = row * col;
        gridScore = 0f;
    }


    // Use this for initialization
    void Start() {
        MakePuzzle();
        pos = transform.position;
    }

    public float GridScore
    {
        get { return gridScore; }
    }

    void MakePuzzle()
    {
        pos = gameObject.transform.position;
        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                GameObject gridCube = Instantiate(gridCubePrefab, pos, transform.rotation);
                gridCube.transform.parent = transform;
                gridCube.transform.localPosition = new Vector3(0, 0, 0);
                gridCube.transform.localRotation = Quaternion.identity;

                pos = gridCube.transform.localPosition;
                newPos = new Vector3(pos.x + space * c, pos.y + space * r, pos.z);
                gridCube.transform.localPosition = newPos;

                posArray[r, c] = gridCube.transform.position;
                occupied[r + 1, c + 1] = false;
            }
        }
    }

    public int[] GetGridPos(Vector3 position)
    {
        float smallestDistance = 2f;
        int[] result = new int[2];
        result[0] = -1;
        result[1] = -1;

        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                float distance = Vector3.Distance(position, posArray[r, c]);
                if (distance < smallestDistance)
                {
                    result[0] = r;
                    result[1] = c;
                    smallestDistance = distance;
                }
            }
        }

        return result;
    }

    public Vector3 GetNearestPointOnGrid(int row, int col)
    {
        if (row >= 0)
        {
            return posArray[row, col];
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }

    public void UpdateOccupiedPositions(int r, int c, string panelCost)
    {
        if (r >= 0)
        {
            r++;
            c++;
            // Sets the occupied grid array to know which squares has a solar panel on it
            if (panelCost == "12000")
            {
                occupied[r - 1, c - 1] = true;
                occupied[r - 1, c] = true;
                occupied[r - 1, c + 1] = true;
                occupied[r, c - 1] = true;
                occupied[r, c] = true;
                occupied[r, c + 1] = true;
                occupied[r + 1, c - 1] = true;
                occupied[r + 1, c] = true;
                occupied[r + 1, c + 1] = true;
            }
            else if (panelCost == "3000")
            {
                occupied[r, c] = true;
            }
        }
    }

    public void ClearPanelOccupancy(int r, int c, string panelCost)
    {
        r++;
        c++;
        if (panelCost == "12000")
        {
            occupied[r - 1, c - 1] = false;
            occupied[r - 1, c] = false;
            occupied[r - 1, c + 1] = false;
            occupied[r, c - 1] = false;
            occupied[r, c] = false;
            occupied[r, c + 1] = false;
            occupied[r + 1, c - 1] = false;
            occupied[r + 1, c] = false;
            occupied[r + 1, c + 1] = false;
        }
        else if (panelCost == "3000")
        {
            occupied[r, c] = false;
        }
    }

    public void UpdateGridScore()
    {
        int count = 0;
        for (int r = 1; r < row + 1; r++)
        {
            for (int c = 1; c < col + 1; c++)
            {
                if (occupied[r,c])
                {
                    count++;
                }
            }
        }
        gridScore = count / size;
    }



}