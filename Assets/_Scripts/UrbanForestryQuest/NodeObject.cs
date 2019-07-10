﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeObject : MonoBehaviour
{
    public int posX;
    public int posZ;
    public int textureId;

    public void UpdatedNodeObject(Node curNode, NodeObjectSaveable saveable)
    {
        posX = saveable.posX;
        posZ = saveable.posZ;
        textureId = saveable.textureId;

        ChangeMaterial(curNode);
    }

    void ChangeMaterial(Node curNode)
    {
        Material getMaterial = LevelEditor.ResourceManager.GetInstance().GetMaterial(textureId);
        curNode.tileRenderer.material = getMaterial;
    }

    public NodeObjectSaveable GetSaveable()
    {
        NodeObjectSaveable saveable = new NodeObjectSaveable();
        saveable.posX = this.posX;
        saveable.posZ = this.posZ;
        saveable.textureId = this.textureId;

        return saveable;
    }

}

[System.Serializable]
public class NodeObjectSaveable
{
    public int posX;
    public int posZ;
    public int textureId;
}