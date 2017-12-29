/*
 * 
 * Programmer: Karim Dabboussi & Spencer Wilson
 * Date Initially Modified: 12/10/2017 @ 8:39 pm
 * Date Last Modified: 12/10/2017 @ 8:39 pm
 * Project: CompSciClubFall2017
 * File Name: EventSystem.cs
 * Description: This file has the code for the event system
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour {

    public GameObject boss1;
    public int point;
    private int count;

    // Use this for initialization
    void Start () {
        point = GameObject.Find("CanvasPoints").GetComponentInChildren<PointSystem>().getPoint();
        count = 0;
    }
	
	// Update is called once per frame
	void Update () {
        checkEvent(GameObject.Find("CanvasPoints").GetComponentInChildren<PointSystem>().getPoint());
	}

    public void checkEvent(int point)
    {
        if (point < 300 && count == 0) //optimization needed so boss does not appear multiple times
        {
            gameObject.AddComponent<EnemySpawn>();
            count++;
        }
        else if (point >= 300 && point < 500 && count == 1)
        {
            Destroy(gameObject.GetComponent<EnemySpawn>());
        }
        else if ((point >= 500) && (point < 1800) && (count == 1) && (GameObject.FindGameObjectsWithTag("Stinger").Length <= 0) && (GameObject.FindGameObjectsWithTag("Stinger").Length <= 0))
        {
            //Destroy(gameObject.GetComponent<EnemySpawn>());
            Instantiate(boss1);
            count++;
            Debug.Log("Striker boss appears");
        }
        //else if (point >= 20000 && point < 20500)
        //{
        //    Debug.Log("The Second Boss Appears"); // work in progress, plan to have boss events, and text that appears
        //}
        //else if (point >= 30000 && point <= 30500)
        //{
        //    Debug.Log("The Third Boss Appears"); // work in progress, plan to have boss events, and text that appears
        //}
        //else if (point >= 40000 && point <= 40500)
        //{
        //    Debug.Log("The Fourth Boss Appears"); // work in progress, plan to have boss events, and text that appears
        //}
        //else if (point >= 50000 && point <= 50500)
        //{
        //    Debug.Log("The Fifth Boss Appears"); // work in progress, plan to have boss events, and text that appears
        //}

    }
}
