/*
 * 
 * Author: Spencer Wilson & Hunter Goodin
 * Date Created: 11/26/2017 @ 3:30 pm
 * Date Modified: 11/26/2017 @ 11:36 pm by Hunter Goodin 
 * Project: CompSciClubFall2017
 * File: EnemySpawn.cs
 * Description: This file contains the code that allows the enemy to spawn in the player space.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject stingerEnemy;     // Populated with the Stinger prefab in-engine 
    public GameObject chomperEnemy;     // Populated with the Chomper prefab in-engine 
    public GameObject crabberEnemy;     // Populated with the Squider prefab in-engine 
    public float spawnRate;             // Spawn Rate. Pretty self explanitory 
    private float nextSpawn;            // Used to see when the function should spawn the next prefab 
    private int randNum;                // used to generate a random number 
    private int countOfStinger;         // Used to know how many Stingers there are on the map 
    private int countOfChomper;         // Used to know how many Chompers there are on the map 
    private int countOfCrabber;       // Used to know how many Squidward there are on the map 

    public int spawnFrom = 0; 

    private int countOfAllEnem;         // Used to know how many enemies in total there are on the map 
   
	
	// Update is called once per frame
	void Update ()
    {
        countOfStinger = GameObject.FindGameObjectsWithTag("Stinger").Length;       // Making countOfStinger = the ammount of objects there are that use the "Stinger" tag 
        countOfChomper = GameObject.FindGameObjectsWithTag("Chomper").Length;       // Making countOfChomper = the ammount of objects there are that use the "Chomper" tag 
        countOfCrabber = GameObject.FindGameObjectsWithTag("Crabber").Length;       // Making countOfSquider = the ammount of objects there are that use the "Squider" tag 
        countOfAllEnem = countOfStinger + countOfChomper + countOfCrabber;          // Making countOfAllEnem = countOfStinger plus countOfChomper
        randNum = Random.Range(spawnFrom, 3);                                               // Making randNum = a random number between 0 and 2 

        if      (randNum == 0 && Time.time > nextSpawn && countOfAllEnem < 5) 
        {
            nextSpawn = Time.time + spawnRate;                                                // Sets nextSpawn to = a spawnRate worth of seconds later 
            Instantiate(stingerEnemy, new Vector3(10, 0, 0), Quaternion.Euler(0, 0, 0));      // Spawns a Stinger
        }
        else if (randNum == 1 && Time.time > nextSpawn && countOfChomper < 2)
        {
            nextSpawn = Time.time + spawnRate;                                                // Sets nextSpawn to = a spawnRate worth of seconds later 
            Instantiate(chomperEnemy, new Vector3(16, 5, 0), Quaternion.Euler(0, 0, 0));      // Spawns an Chomper
        }
        else if (randNum == 2 && Time.time > nextSpawn && countOfCrabber < 2)
        {
            nextSpawn = Time.time + spawnRate;                                                // Sets nextSpawn to = a spawnRate worth of seconds later 
            Instantiate(crabberEnemy, new Vector3(12, -5, 0), Quaternion.Euler(0, 0, 0));     // Spawns an Squidward
        }
    }
}
