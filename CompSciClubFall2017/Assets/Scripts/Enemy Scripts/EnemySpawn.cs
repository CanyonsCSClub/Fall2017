/*
 * 
 * Author: Spencer Wilson
 * Date Created: 11/26/2017 @ 3:30 pm
 * Date Modified: 11/26/2017 @ 4:17 pm
 * Project: CompSciClubFall2017
 * File: EnemySpawn.cs
 * Description: This file contains the code that allows the enemy to spawn in the player space.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject stingerEnemy;
    public GameObject chomperEnemy;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Stinger Spawn
        if (GameObject.FindGameObjectsWithTag("Stinger").Length < 3)
        {
            Instantiate(stingerEnemy, new Vector3(13, 0, 0), Quaternion.Euler(0, 0, 0));
        }

        if (GameObject.FindGameObjectsWithTag("Chomper").Length < 2)
        {
            if (GameObject.FindGameObjectsWithTag("Chomper").Length == 0)
            {
                Instantiate(chomperEnemy, new Vector3(16, 5, 0), Quaternion.Euler(15, 5, 0));
            }
            else if (GameObject.FindGameObjectsWithTag("Chomper").Length == 1)
            {
                Instantiate(chomperEnemy, new Vector3(16, -5, 0), Quaternion.Euler(15, -5, 0));
            }
        }
	}
}
