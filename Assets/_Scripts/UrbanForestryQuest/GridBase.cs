using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBase : MonoBehaviour
{
    public GameObject nodePrefab;

    public int sizeX;
    public int sizeZ;
    public int offset = 1;

    public Node[,] grid;

    // Singleton
    private static GridBase instance = null;
    public static GridBase GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
        CreateGrid();
        CreateMouseCollision();
    }

    void CreateGrid()
    {
        // Create a new grid, 2d array of nodes 
        grid = new Node[sizeX, sizeZ];

        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                // World position to place visualisation for node
                float posX = x * offset;
                float posZ = z * offset;
         

                // Instantitate node prefab
                GameObject go = Instantiate(nodePrefab, new Vector3(posX, 1, posZ), Quaternion.identity) as GameObject;
                go.transform.parent = transform.GetChild(1).transform;


                //// For serialization purposes
                //NodeObject nodeObj = go.GetComponent<NodeObject>();
                //nodeObj.posX = x;
                //nodeObj.posZ = z;

                Node node = new Node();
                node.vis = go;
                node.tileRenderer = node.vis.GetComponentInChildren<MeshRenderer>();
                node.nodePosX = x;
                node.nodePosZ = z;
                grid[x, z] = node;
            }
        }
    }

    void CreateMouseCollision()
    {
        GameObject go = new GameObject();
        go.AddComponent<BoxCollider>();
        // Collider with actual size of whole grid
        go.GetComponent<BoxCollider>().size = new Vector3(sizeX * offset, 0.1f, sizeZ * offset);
        // Change 1 to appropriate number
        go.transform.position = new Vector3((sizeX * offset) / 2 - 1, 0, (sizeZ * offset) / 2 - 1);
    }

    public Node NodeFromWorldPosition(Vector3 worldPosition)
    {
        float worldX = worldPosition.x;
        float worldZ = worldPosition.z;

        worldX /= offset;
        worldZ /= offset;

        int x = Mathf.RoundToInt(worldX);
        int z = Mathf.RoundToInt(worldZ);

        if (x > sizeX)
        {
            x = sizeX;
        }
        if (z > sizeZ)
        {
            z = sizeZ;
        }
        if (x < 0)
        {
            x = 0;
        }
        if (z < 0)
        {
            z = 0;
        }

        return grid[x, z];
    }
}
