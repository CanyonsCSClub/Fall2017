/*
 * 
 * Author: Spencer Wilson & Hunter Goodin 
 * Date Created: 11/3/2017 @ 11:17 pm
 * Date Modified: 11/14/2017 @ 10:36 pm
 * Project: CompSciClubFall2017
 * File: StingerSuperClass.cs
 * Description: This program houses all of the code for the Stinger AI.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingerSuperClass : MonoBehaviour
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

    public int scoreValue = 100; // We will use this to incriment the points 

    public Transform shotSpawn; 
    private float fireRate = 0.5f;
    private float nextFire; 
    // private Vector3 velocity;

    // Use this for initialization
    void Start()
    {
        stingerRigidBody = GetComponent<Rigidbody>();
        // stingerPos = GameObject.Find("PlayerTester").transform; 
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

    public void takeDamage(int damage) // takeDamage is called when the bullet hits the enemy.
    {
        health -= damage;
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
        if(health < 0)
        {
            GameObject.Find("DisplayPoints").GetComponent<PointSystem>().UpdateScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
