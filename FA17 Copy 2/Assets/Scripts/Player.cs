/*
 * 
 * Authors: Spencer Wilson
 * Date Created: 10/8/2017 @ 5:29 pm
 * Date Modified: 10/14/2017 @ 5:04 pm
 * Project: CompSciClubFall2017
 * File: Player.cs
 * Description: File that houses all of the code for the player's health, movement, and abilities.
 * 
 */

 /*ADD YOUR NAME TO THE AUTHORS AND MAKE SURE YOU UPDATE THE DATE MODIFIED! ALSO, COMMENT YOUR CODE!!! COMMENT, COMMENT, COMMENT!*/
 /*WELCOME TO THE TEAM*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float speed; // Declared a floating point variable named speed that will house the user's speed.
    private Rigidbody player; // Creating a Rigidbody object named player.

	public void Start () // Start method initializes any variables/objects/rigidbodies that need to be used within the script.
    {
        player = GetComponent<Rigidbody>(); // Getting the Rigidbody component of the GameObject player is attached to.
        speed = 40f; // Initializing the speed variable with an value of 40.
	}
	
	// Update is called once per frame
	public void Update ()
    {
		
	}

    public void FixedUpdate() // FixedUpdate is called on a regular timeline. Use FixedUpdate for physics based functions that need to be executed.
    {
        playerMovement(); // Calls on the playerMovement() function.
    }

    private void playerMovement()
    {
        if(Input.GetKey("w")) // When w is pressed, move the player forward and display a message to the debug log.
        {
            player.transform.Translate(transform.forward * Time.deltaTime * speed);
            Debug.Log("Player is moving forward.");
        }
        if(Input.GetKey("a")) // When a is pressed, move the player to the left and display a message to the debug log.
        {
            player.transform.Translate(-transform.right * Time.deltaTime * speed);
            Debug.Log("Player is moving to the left.");
        }
        if(Input.GetKey("s")) // When s is pressed, move the player backwards and display a message to the debug log.
        {
            player.transform.Translate(-transform.forward * Time.deltaTime * speed);
            Debug.Log("Player is moving backwards.");
        }
        if(Input.GetKey("d")) // When d is pressed, move the player to the right and display a message to the debug log.
        {
            player.transform.Translate(transform.right * Time.deltaTime * speed);
            Debug.Log("Player is moving to the right.");
        }
    }
}
