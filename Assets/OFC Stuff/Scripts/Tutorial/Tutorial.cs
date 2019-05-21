using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public int Order;

    public string Explanation;

    void Awake()
    {
        // Add all the tutorials within the scene to the tutorial manager
        TutorialManager.Instance.Tutorials.Add(this);
    }

    public virtual void CheckIfHappening() { }
}
