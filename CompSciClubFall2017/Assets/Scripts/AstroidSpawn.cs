/* 
 * Programmer:	Hunter Goodin 
 * Date:		12/8/2017 
 * Project: 	CompSciClubFall2017
 * Description: Spawning the astroids 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawn : MonoBehaviour
{
    public GameObject upstroid;
    public GameObject downstroid;

    private float nextSpawn;                 // Used to see when the function should spawn the next prefab 
    private int randSpawnRate;                // used to generate a random number 
    private int randLocNum;
    private int randTypeNum;
    public int astroidDamage = 15; 

    private Vector3 playerPos;

    // Use this for initialization
    void Update()
    {
        randSpawnRate = Random.Range(8, 12);
        randLocNum = Random.Range(-15, 15);
        randTypeNum = Random.Range(0, 2);

        if (randTypeNum == 1 && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + randSpawnRate;                                              // Sets nextSpawn to = a spawnRate worth of seconds later 
            
            Instantiate(downstroid, new Vector3(randLocNum, 12, 0), Quaternion.Euler(0, 0, 0));          // Spawns an upstroid 
        }
        else if (randTypeNum == 0 && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + randSpawnRate;                                              // Sets nextSpawn to = a spawnRate worth of seconds later 
            Instantiate(upstroid, new Vector3(randLocNum, -12, 0), Quaternion.Euler(0, 0, 0));          // Spawns a downstroid 
        }
    }
}
