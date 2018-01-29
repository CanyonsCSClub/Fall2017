/*
 * Programmer: Karim Dabboussi, Hunter Goodin, Spencer Wilson
 * Date Initially Modified: 12/10/2017 @ 9:28 pm
 * Date Modified: 12/10/2017 @ 9:29 pm
 * Project: CompSciClubFall2017
 * File: PointSystem.cs
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
    
    public int getPoint()
    {
        return point;
    }
}
