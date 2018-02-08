/* 
 * Programmer:	Hunter Goodin 
 * Date:		11/24/2017 
 * Project: 	CompSciClubFall2017
 * Description: The Chomper Enemy class. 
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class ChomperClass : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody chomperRigidBody; // Creating a Rigidbody variable named chomperRigidbody that holds the Rigidbody component of the Chomper enemy.
    private Rigidbody playerRigidBody; // This variable holds the Player's RigidBody.
    private const int speed = 5; // This variable holds the speed for the Chomper enemy.
    private bool isAlive; // Boolean variable that represents if the Chomper enemy is alive.
    public int health = 5; // Integer variable that holds the Chomper health.
    private Vector3 chomperPos;
    private Vector3 playerPos;
    private Vector3 newPos;
    private AudioSource chompAudio;

    public string path = "Assets/Scripts/Unlock System/WhatIsUnlocked.txt";
    public List<string> readList = new List<string>();
    public int ship04Prog;
    public string ship04ProgToInt;
    public int listLength;

    public Text pointPop;
    public GameObject ptVal;
    public Transform ptValLoc;
    public int scoreValue = 100; // We will use this to incriment the points 

    public Transform shotSpawn; 
    private float fireRate = 5f;
    private float nextFire; 

    // Use this for initialization
    void Start()
    {
        chomperRigidBody = GetComponent<Rigidbody>();
        chompAudio = GetComponent<AudioSource>();
    }

    public void Update()
    {
        checkChomperHealth();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        chomperMovement(); // Checks if there is any input from the player and adjusts the enemy Chomper's position according to the change.
        chomperWeapons(); // Fires the Chomper's weapons if the player enters the line of sight of the Chomper.
    }

    public void chomperMovement() // Function houses the code for the Chomper's movement.
    {
        chomperPos = chomperRigidBody.position;
        playerPos = GameObject.Find("Player").GetComponent<Transform>().position;
        newPos = new Vector3(16, playerPos.y, 0f);
        transform.position = Vector3.MoveTowards(chomperPos, newPos, Time.deltaTime * speed);
    }

    private void chomperWeapons() // Raycasts to check if the player is infront of the Chomper. If so, the Chomper lets off a burst of rounds.
    {
        Ray chomperRaycast = new Ray(chomperPos, -transform.right);
        if (Physics.Raycast(chomperRaycast) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; 
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
            Debug.Log("Chomper Lazer");
        }
    }

    public void takeDamage(int damage) // takeDamage is called when the bullet hits the enemy.
    {
        health -= damage;

        chompAudio.Play();
    }

    /* Hunter Goodin was here */ 
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Bolt(Clone)" )
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.name == "ChomperBullet(Clone)")
        {
            Destroy(col.gameObject);
        }
    }

    private void checkChomperHealth() // Checks to see if the Chomper is alive or not.
    {
        if (health <= 0)
        {
            UnlockedReader();

            StreamWriter writer = new StreamWriter(path);
            GameObject.Find("DisplayPoints").GetComponent<PointSystem>().UpdateScore(scoreValue);
            Destroy(gameObject);
            Instantiate(ptVal, ptValLoc.position, ptValLoc.rotation);

            /* Writing */
            ship04Prog++;

            readList[18] = "" + ship04Prog;

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

        ship04ProgToInt = readList[18];

        Convert.ToInt32(ship04ProgToInt);
        ship04Prog = Int32.Parse(ship04ProgToInt);

        reader.Close();
    }
}
