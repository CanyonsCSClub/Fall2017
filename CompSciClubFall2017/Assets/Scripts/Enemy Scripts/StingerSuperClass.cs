/*
 * 
 * Author: Spencer Wilson
 * Date Created: 11/3/2017 @ 11:17 pm
 * Date Modified: 11/5/2017 @ 10:26 pm
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
    private Rigidbody playerRigidBody; // This variable holds the Player's RigidBody.
    private const int speed = 20; // This variable holds the speed for the Stinger enemy.
    private int health;
    private Vector3 stingerPos;
    private Vector3 playerPos;
    // private Vector3 velocity;

    // Use this for initialization
    void Start()
    {
        stingerRigidBody = GetComponent<Rigidbody>();
        //stingerPos = GameObject.Find("PlayerTester").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        stingerMovement();
        stingerWeapons();
        
    }

    public void stingerMovement()
    {
        stingerPos = stingerRigidBody.position;
        playerPos = GameObject.Find("PlayerTester").GetComponent<Transform>().position;
        //transform.position = new Vector(0, stingerPos.position.y, 0); MAYBE LATER?
        transform.position = Vector3.MoveTowards(stingerPos, playerPos, Time.deltaTime * speed);
    }

    private void stingerWeapons()
    {
        if(Physics.Raycast(stingerRigidBody.position, transform.right, 20))
        {
            Debug.Log("Shoot!");
        }
    }
}
