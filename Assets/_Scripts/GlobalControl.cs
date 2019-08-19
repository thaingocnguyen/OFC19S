﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

	public bool startCutscenePlayed;

    public bool solarQuestTutorialPlayed;

    // High scores
    public int solarQuestHighScore;
    public int ufQuestHighScore;

    
}
