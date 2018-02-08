/* 
 * Programmer:	Hunter Goodin 
 * Date:		1/27/2018 
 * Project: 	CompSciClubFall2017
 * Description: The Crabber Enemy class. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class CrabberClass : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody crabberRigidBody; // Creating a Rigidbody variable named CrabberRigidbody that holds the Rigidbody component of the Crabber enemy.
    private Rigidbody playerRigidBody; // This variable holds the Player's RigidBody.
    private const int speed = 5; // This variable holds the speed for the Crabber enemy.
    private bool isAlive; // Boolean variable that represents if the Crabber enemy is alive.
    public int health = 5; // Integer variable that holds the Crabber health.
    private Vector3 crabberPos;
    private Vector3 playerPos;
    private Vector3 newPos;
    private AudioSource crabAudio;

    public string path = "Assets/Scripts/Unlock System/WhatIsUnlocked.txt";
    public List<string> readList = new List<string>();
    public int ship05Prog;
    public string ship05ProgToInt;
    public int listLength;

    public Text pointPop;
    public GameObject ptVal;
    public Transform ptValLoc;
    public int scoreValue = 100; // We will use this to incriment the points 

    public Transform shotSpawn; 
    private float fireRate = 5f;
    private float nextFire; 
    // private Vector3 velocity;

    // Use this for initialization
    void Start()
    {
        crabberRigidBody = GetComponent<Rigidbody>();
        crabAudio = GetComponent<AudioSource>();
    }

    public void Update()
    {
        checkCrabberHealth();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CrabberMovement(); // Checks if there is any input from the player and adjusts the enemy Crabber's position according to the change.
        CrabberWeapons(); // Fires the Crabber's weapons if the player enters the line of sight of the Crabber.
    }

    public void CrabberMovement() // Function houses the code for the Crabber's movement.
    {
        crabberPos = crabberRigidBody.position;
        playerPos = GameObject.Find("Player").GetComponent<Transform>().position;
        newPos = new Vector3(12, playerPos.y + 4, 0f);
        transform.position = Vector3.MoveTowards(crabberPos, newPos, Time.deltaTime * speed);
    }

    private void CrabberWeapons() // Raycasts to check if the player is infront of the Crabber. If so, the Crabber lets off a burst of rounds.
    {
        Ray crabberRaycast = new Ray(crabberPos, -transform.right);
        if (Physics.Raycast(crabberRaycast) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; 
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
            Debug.Log("crabber bomb deploy");
        }
    }

    public void takeDamage(int damage) // takeDamage is called when the bullet hits the enemy.
    {
        health -= damage;

        crabAudio.Play();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Bolt(Clone)" )
        {
            Destroy(col.gameObject);
        }
    }

    private void checkCrabberHealth() // Checks to see if the Crabber is alive or not.
    {
        if (health <= 0)
        {
            UnlockedReader();

            StreamWriter writer = new StreamWriter(path);
            GameObject.Find("DisplayPoints").GetComponent<PointSystem>().UpdateScore(scoreValue);
            Destroy(gameObject);
            Instantiate(ptVal, ptValLoc.position, ptValLoc.rotation);

            /* Writing */
            ship05Prog++;

            readList[20] = "" + ship05Prog;

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

        ship05ProgToInt = readList[20];

        Convert.ToInt32(ship05ProgToInt);
        ship05Prog = Int32.Parse(ship05ProgToInt);

        reader.Close();
    }
}
