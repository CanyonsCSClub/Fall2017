/* 
 * Programmer:	Hunter Goodin 
 * Date:		11/5/2017 
 * Project: 	SpaceShooterTutorial 
 * Description: This is me testing how to create the player projectile for CompSci Club's
 * 				Fall 2017 game. I will use this as a basis to show Dylan how to create 
 *				the player's projectile's in game. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbThingMover : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * speed; 
    }
}
