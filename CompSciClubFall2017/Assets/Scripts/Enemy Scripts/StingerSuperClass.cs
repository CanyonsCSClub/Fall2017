/*
 * 
 * Author: Spencer Wilson
 * Date Created: 11/3/2017 @ 11:17 pm
 * Date Modified: 11/3/2017 @ 11:22 pm
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

    private Rigidbody stingerRigidBody; // Creating a Rigidbody variable named stingerRigidbody that holds the Rigidbody component of the Stinger enemy.
    private const int speed = 6; // This variable holds the speed for the Stinger enemy.
    private int health;
    private Vector3 velocity;

    // Use this for initialization
    void Start()
    {
        stingerRigidBody = GetComponent<Rigidbody>(); // Gets the Rigidbody component attatched to the gameobject and stores it to stingerRigidbody.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        stingerMovement();
        
    }

    public void stingerMovement()
    {
        velocity.x = 0; // transform.position.x;
        velocity.y = Mathf.Sin(Time.time * speed);
        velocity.z = 0; // transform.position.z;
        stingerRigidBody.transform.Translate(velocity.x, velocity.y, velocity.z);
    }
}
