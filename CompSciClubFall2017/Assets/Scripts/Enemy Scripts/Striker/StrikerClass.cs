/*
 * 
 * Author: Spencer Wilson
 * Date Created: 11/24/2017 @ 8:28 pm
 * Date Modified: 12/21/2017 @ 5:17 pm
 * Project: CompSciClubFall2017
 * File: Striker.cs
 * Description: File that houses all of the code for the Striker enemy. 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrikerClass : MonoBehaviour
{
    public GameObject projectile; // Acts at the first projectile that spawns in.
    private GameObject strikerGameObject; // Creating a private GameObject variable named strikerGameObject to hold the current gameobject reference.
    private GameObject playerGameObject; // Holds the reference to the player game object.
    private GameObject shotSpawn; // Holds the location of where the Striker's projectiles spawn.

    private float timeElapsedBehavior; // Holds the time that has elapsed since the last behavior change.
    private float timeElapsedTeleport; // Holds the time that has elapsed since the Striker last teleported.
    private float timeElapsedShot; // Holds the time that has elapsed since the Striker last shot.

    private float timeElapsedBehavior; // Holds the time that has elapsed since the last behavior change.
    private float timeElapsedTeleport; // Holds the time that has elapsed since the Striker last teleported.
    private float timeElapsedShot; // Holds the time that has elapsed since the Striker last shot.

    private bool attackedAlready; // Holds a true/false variable that represents whether or not the Striker attacked already before his teleportation or not.
    private bool attacking; // Bool that holds a true or false value whether or not the Striker is attacking or not.

    public Text pointPop;
    public GameObject ptVal;
    public Transform ptValLoc;
    public int scoreValue = 1000; // We will use this to incriment the points 

    public int health = 20; // Initializes the Striker's health to be 50.
    private int speed = 40;
    private Rigidbody strikerRb; // Creating a private Rigidbody variable that houses the striker's rigidbody.
    private Vector3 initialPos; // Creating a private Vector3 variable named initialPos that will hold the Vector3 coordinates of the striker's location.
    private Vector3 finalPos; // Creating a private Vector3 variable named finalPos that will hold the Vector3 coordinates of the player's location.
    private float lerpTime = Time.time; // Creating a private float variable that represents the time it takes from start to end.
    private float currentLerpTime; // This will update the lerp time.
    private float lerpDistance; // Created a private float variable that holds a the distance.

    private void Start()
    {
        health = 20; // Initializing the Striker's health to be 10;
        attacking = false; // Striker initially starts off by not attacking the player.
        strikerGameObject = gameObject; // Assigns strikerGameObject the reference to the game object that the script is attached to.
        playerGameObject = GameObject.Find("Player"); // Assigns the Player game object to the reference playerGameObject.
        shotSpawn = strikerGameObject.transform.GetChild(1).gameObject; // Assigns shotSpawn the reference of the shotSpawn child of the game object Striker.
        strikerRb = GetComponent<Rigidbody>(); // Get's the Rigidbody of the current game object it is attached to and references it in strikerRb.
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
        if (health <= 20 && health > 0)
        {
            if (attacking == true) // While Striker is attacking.
            {
                if (timeElapsedBehavior <= 3) // While the time that has elapsed (variable timeElapsedBehavior) since the Striker's last mood swing is less than 5 seconds.
                {
                    timeElapsedBehavior += Time.unscaledDeltaTime; // Increment timeElapsedBehavior by the number of seconds that have passed since the last frame to the current one.
                    if (timeElapsedShot >= 0.2) // When the time that has elapsed since the Striker last shot is greater than or equal to one.
                    {
                        transform.position = new Vector3(10f, playerGameObject.transform.position.y, 0f); // Teleports to the player's current y-axis coordinate. This is a sort of teleport and following of the player.
                        Instantiate(projectile, shotSpawn.transform.position, transform.rotation); // Instantiating Striker projectile.
                        timeElapsedShot = 0f; // Reset the timer for timeElapsedShot back to zero seconds.
                    }
                    else
                    { 
                        timeElapsedShot += Time.unscaledDeltaTime; 
                    } 
                }
                else
                {
                    timeElapsedBehavior = 0f; // Resets the timeElapsedBehavior back to zero as the Striker switches from offensive to defensive.
                    attacking = false; // Striker's attack run is now over. Striker is on the defensive.
                }
            }
            else if (attacking == false) // While Striker is not attacking.
            {
                if (timeElapsedBehavior <= 10f) // While the time (timeElapsedBehavior) that has elapsed since the Striker's last behavior change is less than 10 seconds.
                {
                    timeElapsedBehavior += Time.unscaledDeltaTime; // Increment timeElapsedBehavior by the number of seconds that have passed since the last frame to the current one.
                    if(timeElapsedTeleport >= 0.5f) // If the time elapsed since the Striker last teleported is greater than 0.5 seconds.
                    {
                        transform.position = new Vector3(10f, Random.Range(-11, 8f), 0f);
                        timeElapsedTeleport = 0f; // Resets the time elapsed since the Striker last teleported to zero.
                    }
                    else
                    {
                        timeElapsedTeleport += Time.unscaledDeltaTime; // Increments the timeElapsedTeleport by the number number of seconds that has passed since the last frame and the current one.
                    }

                }
                else
                {
                    timeElapsedBehavior = 0f; // Resets the timeElapsedBehavior to zero as the Striker switches from defensive to offensive.
                    attacking = true; // Changes attacking to true, Striker is now on the offensive.
                }
            }
        }
    }

    private void IsAlive() // Function checks if the Striker is alive or not.
    {
        if (health <= 0)
        {
            Instantiate(ptVal, ptValLoc.position, ptValLoc.rotation);
            GameObject.Find("DisplayPoints").GetComponent<PointSystem>().UpdateScore(scoreValue);
            GameObject.Destroy(gameObject); // Destroys the Striker boss when it's health goes below zero.
            Debug.Log("Striker is dead.");
        }
    }

    private void OnCollisionEnter(Collision collision) // Checks for collisions.
    {
        if(collision.gameObject.name == "Bolt(Clone)") // If the incoming game object that collides with the Striker has the name of Bolt(Clone).
        {
            Destroy(collision.gameObject); // Destroy the bolt.
        }
    }

    private void OnCollisionEnter(Collision collision) // Checks for collisions.
    {
        if(collision.gameObject.name == "Bolt(Clone)") // If the incoming game object that collides with the Striker has the name of Bolt(Clone).
        {
            Destroy(collision.gameObject); // Destroy the bolt.
        }
    }

    public void TakeDamage(int damage) // Subtracts the integer passed through damage from health everytime it is hit.
    {
        health -= damage;
    }
}
