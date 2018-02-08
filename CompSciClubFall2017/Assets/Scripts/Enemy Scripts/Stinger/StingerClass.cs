/*
 * Author: Spencer Wilson & Hunter Goodin 
 * Date Created: 11/3/2017 @ 11:17 pm
 * Date Modified: 11/14/2017 @ 10:36 pm
 * Project: CompSciClubFall2017
 * File: StingerSuperClass.cs
 * Description: This program houses all of the code for the Stinger AI.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class StingerClass : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody stingerRigidBody; // Creating a Rigidbody variable named stingerRigidbody that holds the Rigidbody component of the Stinger enemy.
    private Rigidbody playerRigidBody; // This variable holds the Player's RigidBody.
    private const int speed = 20; // This variable holds the speed for the Stinger enemy.
    private bool isAlive; // Boolean variable that represents if the Stinger enemy is alive.
    public int health = 5; // Integer variable that holds the Stinger health.
    private Vector3 stingerPos;
    private Vector3 playerPos;
    private Vector3 newPos;
    private AudioSource stingAudio;

    public string path = "Assets/Scripts/Unlock System/WhatIsUnlocked.txt";
    public List<string> readList = new List<string>();
    public int ship03Prog;
    public string ship03ProgToInt;
    public int listLength; 

    public Text pointPop;
    public GameObject ptVal;
    public Transform ptValLoc;
    public int scoreValue = 100; // We will use this to incriment the points 

    public Transform shotSpawn; 
    private float fireRate = 0.5f;
    private float nextFire; 

    // Use this for initialization
    void Start()
    {
        stingerRigidBody = GetComponent<Rigidbody>();
        stingAudio = GetComponent<AudioSource>();
    }

    public void Update()
    {
        checkStingerHealth();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        stingerMovement(); // Checks if there is any input from the player and adjusts the enemy Stinger's position according to the change.
        stingerWeapons(); // Fires the Stinger's weapons if the player enters the line of sight of the Stinger.
    }

    public void stingerMovement() // Function houses the code for the Stinger's movement.
    {
        stingerPos = stingerRigidBody.position;
        playerPos = GameObject.Find("Player").GetComponent<Transform>().position;
        newPos = new Vector3(playerPos.x + 10f, playerPos.y, 0f);
        transform.position = Vector3.MoveTowards(stingerPos, newPos, Time.deltaTime * speed);
    }

    private void stingerWeapons() // Raycasts to check if the player is infront of the Stinger. If so, the Stinger lets off a burst of rounds.
    {
        Ray stingerRaycast = new Ray(stingerPos, -transform.right);
        if (Physics.Raycast(stingerRaycast) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; 
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
            Debug.Log("Pew! Pew!"); 
        }
    }

    public void TakeDamage(int pDamage) // takeDamage is called when the bullet hits the enemy.
    {
        health -= pDamage;
        stingAudio.Play();
    }

    /* Hunter Goodin was here */ 
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Bolt(Clone)" )
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.name == "StingerBullet(Clone)")
        {
            Destroy(col.gameObject);
        }
    }

    private void checkStingerHealth() // Checks to see if the Stinger is alive or not.
    {
        if (health <= 0)
        {
            UnlockedReader();

            StreamWriter writer = new StreamWriter(path);
            GameObject.Find("DisplayPoints").GetComponent<PointSystem>().UpdateScore(scoreValue);
            Destroy(gameObject);
            Instantiate(ptVal, ptValLoc.position, ptValLoc.rotation);

            /* Writing */ 
            ship03Prog++;

            readList[16] = "" + ship03Prog;

            for (int r = 0; r < readList.Count; r++)
            {
                writer.WriteLine(readList[r]);
            }

            writer.Close();
        }
    }

    private void UnlockedReader()
    {
        /* Reading */
        StreamReader reader = new StreamReader(path);

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            readList.Add(line);
        }

        ship03ProgToInt = readList[16];

        Convert.ToInt32(ship03ProgToInt);
        ship03Prog = Int32.Parse(ship03ProgToInt);

        reader.Close(); 
    }
}
