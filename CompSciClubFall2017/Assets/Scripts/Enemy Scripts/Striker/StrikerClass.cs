/*
 * 
 * Author: Spencer Wilson
 * Date Created: 11/24/2017 @ 8:28 pm
 * Date Modified: 11/24/2017 @ 8:29 pm
 * Project: CompSciClubFall2017
 * File: Player.cs
 * Description: File that houses all of the code for the Striker enemy. 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikerClass : MonoBehaviour {

    private GameObject strikerGameObject; // Creating a private GameObject variable named strikerGameObject to hold the current gameobject reference.
    private GameObject playerGameObject; // Holds the reference to the player game object.

    public GameObject projectile; // Acts at the first projectile that spawns in.

    private bool attackedAlready; // Holds a true/false variable that represents whether or not the Striker attacked already before his teleportation or not.
    private float timeT = 0f;

    private int health = 400; // Initializes the Striker's health to be 10.
    private int speed = 40;
    private Rigidbody strikerRb; // Creating a private Rigidbody variable that houses the striker's rigidbody.
    private Vector3 initialPos; // Creating a private Vector3 variable named initialPos that will hold the Vector3 coordinates of the striker's location.
    private Vector3 finalPos; // Creating a private Vector3 variable named finalPos that will hold the Vector3 coordinates of the player's location.
    private float lerpTime = Time.time; // Creating a private float variable that represents the time it takes from start to end.
    private float currentLerpTime; // This will update the lerp time.
    private float lerpDistance; // Created a private float variable that holds a the distance.

    private void Start()
    {
        strikerGameObject = gameObject; // Assigns strikerGameObject the reference to the gameobject that the script is attached to.
        playerGameObject = GameObject.Find("Player");
        strikerRb = GetComponent<Rigidbody>(); // Get's the Rigidbody of the current gameObject it is attached to and references it in strikerRb.
    }

    // Update is called once per frame
    private void Update()
    {
        StrikerWeapons();
    }

    private void FixedUpdate()
    {
        StrikerMovement();
    }

    private void StrikerMovement() // This function houses the code for the Striker's movment. The Striker moves in a sine pattern and teleports.
    {
        float newPosY; // Creating a local float variable named newPosY that holds the Striker's y-position.

        if (timeT <= 1f)
        {
            timeT += Time.deltaTime;
            newPosY = Mathf.Sin(0.2f * (Time.time) * speed);
            strikerRb.velocity = new Vector3(0, newPosY, 0);
        }
        else// If timeToMove is equal to true, teleport the Striker to the player's current y position.
        {
            timeT = 0;
            transform.position = new Vector3(transform.position.x, playerGameObject.transform.position.y, transform.position.z);
        }
    }

    private void StrikerWeapons() // Function houses the striker's weapons.
    {
        Instantiate(projectile, transform.position, transform.rotation);
        Instantiate(projectile, transform.position, transform.rotation);
    }

    private void IsAlive() // Function checks if the Striker is alive or not.
    {
        if (health < 0)
        {
            GameObject.Find("DisplayPoints").GetComponent<PointSystem>().UpdateScore(1000);
            Debug.Log("Striker is dead.");
        }
    }

    public void TakeDamage(int damage) // Subtracts the integer passed through damage from health everytime it is hit.
    {
        health -= damage;
    }
}
