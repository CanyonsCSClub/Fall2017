/*
 * 
 * Author: Spencer Wilson
 * Date Created: 11/3/2017 @ 10:48 pm
 * Date Modified: 11/3/2017 @ 11:32 pm
 * Project: CompSciClubFall2017
 * File: EnemyHealth.cs
 * Decription: This file houses all of the code for the enemies health. (WORK WITH ANDRES TO INTEGRATE WITH NORMAL HEALTH FOLDER?)
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void isAlive(int health)
    {
        if (health > 0)
        {
            Debug.Log("Stinger is alive");
        }
        else Destroy(gameObject);

    }

}
