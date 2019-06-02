using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarQuestManager : MonoBehaviour
{

    public Animator startQuestAnimator;


    // Start is called before the first frame update
    void Start()
    {
        startQuestAnimator.SetBool("IsOnScreen", true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
