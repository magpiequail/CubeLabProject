﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    public int buildIndex;
    public Sprite oneStar;
    public Sprite twoStars;
    public Sprite threeStars;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetInt("" + buildIndex + "stars");
        
    }
}
