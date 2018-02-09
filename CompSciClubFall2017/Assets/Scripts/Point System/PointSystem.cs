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
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class PointSystem : MonoBehaviour
{
    public Text scoreText;
    public float scoreTimer;
    public float scoreDelayTimer = 0.5f;
    const int ENEMY1 = 100; //possible values for later
    const int ENEMY2 = 100; //possible values for later
    const int BOSS1 = 1000; //possible values for later
    const int BOSS2 = 2000; //possible values for later 

    public string pathTemp;
    public int pointTemp;
    public string pathHigh;
    private int pointHigh;

    private string pointHighToInt;

    public string writingThis; 

    // Use this for initialization
    void Start ()
    {
        pointTemp = 0;

        ShowOnScreen();
        scoreTimer = scoreDelayTimer;

        pathTemp = "Assets/Scripts/Point System/TempScore.txt";   
        pathHigh = "Assets/Scripts/Point System/HighScore.txt";
    }

    private void ShowOnScreen()
    {
        scoreText.text = pointTemp.ToString();
    }

    // Update is called once per frame
    void Update ()
    {
        writingThis = "" + pointTemp;

        StreamReader readerHigh = new StreamReader(pathHigh);
        pointHighToInt = readerHigh.ReadToEnd();
        Convert.ToInt32(pointHighToInt);
        pointHigh = Int32.Parse(pointHighToInt);
        readerHigh.Close();

        var writing = File.CreateText(pathTemp);   
        writing.Write(writingThis);
        writing.Close();

        if (pointHigh < pointTemp)
        {
            var writing2 = File.CreateText(pathHigh);
            pointHigh = pointTemp;
            writing2.Write(pointHigh);
            writing2.Close();
        }
    }

    public void UpdateScore(int ptInc)
    {
        pointTemp = pointTemp + ptInc;
        scoreText.text = pointTemp.ToString();
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
