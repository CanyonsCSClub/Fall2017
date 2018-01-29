/*
 * 
 * Author: Spencer Wilson
 * Date Created: 11/24/2017 @ 9:44 pm
 * Date Modified: 11/24/2017 @ 9:46 pm
 * Project: CompSciClubFall2017
 * File: StrikerProjectile.cs 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloaterProjectile : MonoBehaviour
{
    private GameObject strikerProjGameObj;
    private GameObject playerGameObj;
    private Vector3 newPos;
    private Vector3 finalPos;
    private float speed = 5f; // Private float variable named speed that holds the StrikerProjectile's speed.
    private float lifetime = 5f; // Private float variable named lifetime that holds the projectile's lifetime.
    //private Rigidbody strikerPRb;
    // Use this for initialization
    void Start()
    {
        playerGameObj = GameObject.Find("Player"); // Assigns the gameObject named Player to teh playerGameObj reference variable.
        strikerProjGameObj = gameObject;
        Destroy(gameObject, 2f); // Destorys the current gameObject after five seconds.
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        StrikerProjMovement();
    }

    private void StrikerProjMovement()
    {
        transform.position = Vector3.MoveTowards(strikerProjGameObj.transform.position, playerGameObj.transform.position, Time.deltaTime * speed);
    }
}
