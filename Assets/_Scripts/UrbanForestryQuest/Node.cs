using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    // Node position on grid
    public int nodePosX;
    public int nodePosZ;

    // Visualiser
    public GameObject vis;

    // Object placed in node
    public LevelEditor.Level_Object placedObj;

    public MeshRenderer tileRenderer;

    public List<LevelEditor.Level_Object> stackedObjs = new List<LevelEditor.Level_Object>();
}
