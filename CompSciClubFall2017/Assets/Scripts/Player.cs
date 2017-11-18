/*
 * 
 * Authors: Spencer Wilson, Andrew Ramirez
 * Date Created: 10/8/2017 @ 5:29 pm
 * Date Modified: 11/14/2017 @ 10:36 pm
 * Project: CompSciClubFall2017
 * File: Player.cs
 * Description: File that houses all of the code for the player's health, lives, movement, and abilities.
 * 
 */

 /*ADD YOUR NAME TO THE AUTHORS AND MAKE SURE YOU UPDATE THE DATE MODIFIED! ALSO, COMMENT YOUR CODE!!! COMMENT, COMMENT, COMMENT!*/
 /*WELCOME TO THE TEAM*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private float speed; // Declared a floating point variable named speed that will house the user's speed.
    private Rigidbody player; // Creating a Rigidbody object named player.
    private bool isEnemy;
    private int currentLives;
    private const int maxLives = 5; // Max amount of lives that the player can have
    private const int maxHealth = 100; // Max amount of player health

    public Text healthText; // Reference to health text
    public Text liveText; // Reference to live text
    public Text gameOverText; // Reference to GameOver text

    public void Start () // Start method initializes any variables/objects/rigidbodies that need to be used within the script.
    {
        player = GetComponent<Rigidbody>(); // Getting the Rigidbody component of the GameObject player is attached to.
        speed = 40f; // Initializing the speed variable with an value of 40.
        isEnemy = false; // Sets the player as not an enemy
        currentLives = 2; // Set initial player live count
        Health playerHealth = this.GetComponent<Health>();
        playerHealth.hp = 100; // Set initial player health
        setHealthandLiveText(); // Update the health and live count text component

        Debug.Log("Current Lives: " + currentLives);
        Debug.Log("Current Health " + playerHealth.hp);
    }
	
	// Update is called once per frame
	public void Update ()
    {
        playerWeapons();
	}

    // Display Health and Lives
    void setHealthandLiveText()
    {
        Health playerHealth = this.GetComponent<Health>();
        healthText.text = "Ship Health: " + playerHealth.hp.ToString() + "%";
        liveText.text = "Lives: " + currentLives;
    }

    public void FixedUpdate() // FixedUpdate is called on a regular timeline. Use FixedUpdate for physics based functions that need to be executed.
    {
        playerMovement(); // Calls on the playerMovement() function.
    }

    void OnDestroy()
    {
        // Check that the player is dead
        Health playerHealth = this.GetComponent<Health>();
        if (playerHealth != null && playerHealth.hp <= 0)
        {
            // Game Over.
            gameOverText.text = "Game Over"; // Show game over text
            // todo: allow the player to restart? or go back to the game menu
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        bool damagePlayer = false;

        StingerBullet enemy = collision.gameObject.GetComponent<StingerBullet>(); // Enemy object, in this case an asteroid for testing purposes

        // If enemy exists
        if (enemy != null)
        {
            damagePlayer = true;
        }

        // Damage the player
        if (damagePlayer)
        {
            Health playerHealth = this.GetComponent<Health>();
       
            // Damage the player if their health is not 0
            if (playerHealth.hp != 0) {
                playerHealth.Damage(10, this.isEnemy); // Damage the player by x amount

                Debug.Log("Current Health: " + playerHealth.hp);
                setHealthandLiveText();

                if (playerHealth.hp <= 0)
                {
                    this.currentLives--; // decrement player live count
                    Debug.Log("Current Lives: " + this.currentLives);
                    setHealthandLiveText(); // update player lives

                    // Run this if player live count is less than 0 
                    if (this.currentLives <= 0)
                    {
                        Debug.Log("Game Over"); // Rip in pieces  
                        Destroy(gameObject);
                    }
                    else
                    {
                        playerHealth.hp = maxHealth;
                        Debug.Log("Current Health: " + playerHealth.hp);
                        setHealthandLiveText(); // update health
                    }
                }

            }
        }
    }

    private void playerMovement()
    {
        if(Input.GetKey("w")) // When w is pressed, move the player up.
        {
            player.transform.Translate(transform.up * Time.deltaTime * speed);
            //Debug.Log("Player is moving up.");
        }
        if (Input.GetKey("a")) // When a is pressed, move the player to the left.
        {
            player.transform.Translate(-transform.right * Time.deltaTime * speed);
            //Debug.Log("Player is moving right.");
        }
        if (Input.GetKey("s")) // When s is pressed, move the player down.
        {
            player.transform.Translate(-transform.up * Time.deltaTime * speed);
            //Debug.Log("Player is moving down.");
        }
        if(Input.GetKey("d")) // When d is pressed, move the player to the right.
        {
            player.transform.Translate(transform.right * Time.deltaTime * speed);
            //Debug.Log("Player is moving to the left.");
        }
    }

    private void playerWeapons()
    {
        if(Input.GetKey("space"))
        {
            Debug.Log("BAM!");
        }
    }
}
