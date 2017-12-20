/*
 * 
 * Author: Spencer Wilson
 * Date Created: 11/24/2017 @ 8:28 pm
 * Date Modified: 12/19/2017 @ 5:13 pm
 * Project: CompSciClubFall2017
 * File: Striker.cs
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
    private bool attacking; // Bool that holds a true or false value whether or not the Striker is attacking or not.

    public int health = 400; // Initializes the Striker's health to be 10.
    private int speed = 40;
    private Rigidbody strikerRb; // Creating a private Rigidbody variable that houses the striker's rigidbody.
    private Vector3 initialPos; // Creating a private Vector3 variable named initialPos that will hold the Vector3 coordinates of the striker's location.
    private Vector3 finalPos; // Creating a private Vector3 variable named finalPos that will hold the Vector3 coordinates of the player's location.
    private float lerpTime = Time.time; // Creating a private float variable that represents the time it takes from start to end.
    private float currentLerpTime; // This will update the lerp time.
    private float lerpDistance; // Created a private float variable that holds a the distance.

    private void Start()
    {
        attacking = false; // Striker initially starts off by not attacking the player.
        strikerGameObject = gameObject; // Assigns strikerGameObject the reference to the gameobject that the script is attached to.
        playerGameObject = GameObject.Find("Player");
        strikerRb = GetComponent<Rigidbody>(); // Get's the Rigidbody of the current gameObject it is attached to and references it in strikerRb.
    }

    // Update is called once per frame
    private void Update()
    {
        IsAlive(); // Checks every frame to see if Striker is still alive.
    }

    private void FixedUpdate()
    {
        StrikerBehavior(); // Calls upon the StrikerBehavior() function every frame to update the Striker's behavior.
    }

    private void StrikerBehavior() // This function houses the code for the Striker's movment. The Striker moves in a sine pattern and teleports.
    {
        if(attacking == true) // While Striker is attacking.
        {
            // Basic jist
            Instantiate(projectile, transform.position, transform.rotation);
            Instantiate(projectile, transform.position, transform.rotation);
        }
        else if (attacking == false) // While Striker is not attacking.
        {

        }
    }

    private void IsAlive() // Function checks if the Striker is alive or not.
    {
        if (health < 0)
        {
            GameObject.Find("DisplayPoints").GetComponent<PointSystem>().UpdateScore(1000);
            GameObject.Destroy(gameObject); // Destorys the Striker boss when it's health goes below zero.
            Debug.Log("Striker is dead.");
        }
    }

    public void TakeDamage(int damage) // Subtracts the integer passed through damage from health everytime it is hit.
    {
        health -= damage;
    }
}
