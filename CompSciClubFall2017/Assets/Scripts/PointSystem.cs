/*
 * Programmer: Karim Dabboussi
 * File Name: PointSystem.cs
 * Description: This file has the code for the point system
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointSystem : MonoBehaviour {
    public int point = 0;
    int score = 0;
    const int ENEMY1 = 100;
    const int ENEMY2 = 100;
    const int BOSS1 = 1000;
    const int BOSS2 = 2000;
    // Use this for initialization
    void Start () {
       
    }

    // Update is called once per frame
    void Update () {
        point = point + 100; // will delete later
        checkEvent(point);
        
    }
    public void checkEvent(int point) {
        if (point >= 10000 && point <= 10500)
        {
            Debug.Log("The First Boss Appears"); // work in progress
        }

        else if (point >= 20000 && point <= 20500)
        {
            Debug.Log("The Second Boss Appears"); // work in progress
        }
        else if (point >= 30000 && point <= 30500)
        {
            Debug.Log("The Third Boss Appears"); // work in progress
        }
        else if (point >= 40000 && point <= 40500)
        {
            Debug.Log("The Fourth Boss Appears"); // work in progress
        }
        else if (point >= 50000 && point <= 50500)
        {
            Debug.Log("The Fifth Boss Appears"); // work in progress
        }

    }
}
