using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using LevelEditor;
using System;
using UnityEngine;

public class Level_SaveLoad : MonoBehaviour
{
    private List<SaveableLevelObject> saveLevelObjects_List = new List<SaveableLevelObject>();
    private List<SaveableLevelObject> saveStackableLevelObjects_List = new List<SaveableLevelObject>();
    private List<NodeObjectSaveable> saveNodeObjectsList = new List<NodeObjectSaveable>();

    public static string saveFolderName = "LevelObjects";

    public void SaveLevelButton()
    {
        //SaveLevel("testLevel");
    }

    public void LoadLevelButton()
    {
        //LoadLevel("testLevel");
    }
}
