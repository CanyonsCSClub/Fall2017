/*
 * Programmer: Hunter Goodin 
 * File Name: HighSchoreSystem.cs
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

public class HighScoreSystem : MonoBehaviour
{
    public Text showHighScore;
    public string pathTemp;
    public string pathHigh;

    private int pointTemp;
    private int pointHigh; 

    void Start () 
    {
        pathTemp = "Assets/Scripts/Point System/TempScore.txt";    
        pathHigh = "Assets/Scripts/Point System/HighScore.txt";

        StreamReader readerTemp = new StreamReader(pathTemp);
        StreamReader readerHigh = new StreamReader(pathHigh);

        pathTemp = readerTemp.ReadToEnd();
        pathHigh = readerHigh.ReadToEnd(); 

        Convert.ToInt32(pathTemp);
        Convert.ToInt32(pathHigh);

        pointTemp = Int32.Parse(pathTemp);
        pointHigh = Int32.Parse(pathHigh); 

        readerTemp.Close();
        readerHigh.Close();

        if (pointHigh < pointTemp)
        {
            var writing = File.CreateText(pathHigh);
            pointHigh = pointTemp; 
            writing.Write(pointHigh);
            writing.Close();
        }

        showHighScore.text = "" + pointHigh; 
    }
}
