/*
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
        scoreText.text = point.ToString();
        scoreTimer = scoreDelayTimer;
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
    
    public int getPoint()
    {
        return point;
    }
}
