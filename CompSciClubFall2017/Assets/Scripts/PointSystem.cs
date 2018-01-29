﻿/*
 * Programmer: Karim Dabboussi & Hunter Goodin 
 * File Name: PointSystem.cs
 * Description: This file has the code for the point system
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour {
    public Text scoreText;
    public float scoreTimer;
    public float scoreDelayTimer = 0.5f;
    public int point = 0;
    const int ENEMY1 = 100; //possible values for later
    const int ENEMY2 = 100; //possible values for later
    const int BOSS1 = 1000; //possible values for later
    const int BOSS2 = 2000; //possible values for later
    // Use this for initialization
    void Start ()
    {
        NewMethod();
        scoreTimer = scoreDelayTimer;
    }

    private void NewMethod()
    {
        scoreText.text = point.ToString();
    }

    // Update is called once per frame
    void Update ()
    {
        /* This will incriment the score by 100 every other second 
        scoreTimer -= Time.deltaTime;
        //will delete later
        if (scoreTimer < 0) 
        {
            point = point + 100;
            scoreTimer = scoreDelayTimer;
            scoreText.text = point.ToString();  
        }
        checkEvent(point);
        */
    }

    public void UpdateScore(int ptInc)
    {
        point = point + ptInc;
        scoreText.text = point.ToString();
    }

    public void checkEvent(int point) {
        if (point >= 10000 && point <= 10500) //optimization needed so boss does not appear multiple times
        {
            Debug.Log("The First Boss Appears"); // work in progress, plan to have boss events, and text that appears
        }

        else if (point >= 20000 && point <= 20500)
        {
            Debug.Log("The Second Boss Appears"); // work in progress, plan to have boss events, and text that appears
        }
        else if (point >= 30000 && point <= 30500)
        {
            Debug.Log("The Third Boss Appears"); // work in progress, plan to have boss events, and text that appears
        }
        else if (point >= 40000 && point <= 40500)
        {
            Debug.Log("The Fourth Boss Appears"); // work in progress, plan to have boss events, and text that appears
        }
        else if (point >= 50000 && point <= 50500)
        {
            Debug.Log("The Fifth Boss Appears"); // work in progress, plan to have boss events, and text that appears
        }

    }
}
