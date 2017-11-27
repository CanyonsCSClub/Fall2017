/* 
 * Programmer:	Hunter Goodin 
 * Date:		11/24/2017 
 * Project: 	CompSciClubFall2017
 * Description: The Chomper Enemy class. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int scoreValue = 100; // We will use this to incriment the points 

    public Transform shotSpawn; 
    private float fireRate = 10f;
    private float nextFire; 
    // private Vector3 velocity;

    // Use this for initialization
    void Start()
    {
        chomperRigidBody = GetComponent<Rigidbody>();
        // chomperPos = GameObject.Find("PlayerTester").transform; 
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
        newPos = new Vector3(18, playerPos.y, 0f);
        transform.position = Vector3.MoveTowards(chomperPos, newPos, Time.deltaTime * speed);
    }

    private void chomperWeapons() // Raycasts to check if the player is infront of the Chomper. If so, the Chomper lets off a burst of rounds.
    {
        Ray chomperRaycast = new Ray(chomperPos, -transform.right);
        if (Physics.Raycast(chomperRaycast) && Time.time > nextFire)
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
        if (col.gameObject.name == "ChomperBullet(Clone)")
        {
            Destroy(col.gameObject);
        }
    }

    private void checkChomperHealth() // Checks to see if the Chomper is alive or not.
    {
        if(health < 0)
        {
            GameObject.Find("DisplayPoints").GetComponent<PointSystem>().UpdateScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
