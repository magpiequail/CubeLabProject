﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    public int buildIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetInt("" + buildIndex + "stars");
        Debug.Log(PlayerPrefs.GetInt("" + buildIndex + "stars"));
    }
}
