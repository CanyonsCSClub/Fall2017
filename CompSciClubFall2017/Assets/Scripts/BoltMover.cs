﻿/* 
 * Programmer:	Hunter Goodin 
 * Date:		11/5/2017 
 * Project: 	CompSciClubFall2017
 * Description: Creating the Bolt object the player will shoot. 
 */

using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class BoltMover : MonoBehaviour
{
    public float speed;             // The speed at which the Bolt moves. This float can be accessed in-engine when inspecting the Bolt prefab. 
    public int damage = 1;

    private Rigidbody rb;           // Creating the Rigidbody for this script named 'rb'. 
    private float lifetime = 1.5f;    // We will use this to destory our bolts after 2 second. 

    void Start()			// The following code will occur the frame a Bolt is created. 
    {
        rb = GetComponent<Rigidbody>(); 			 // rb is set to Bolt's Rigidbody established in-engine. 
        rb.velocity = transform.right * speed;       // The Rigidbody will move right based on the speed float. 
        Destroy(gameObject, lifetime);               // Destroys this object based on our lifetime float we created earlier. 
    }

    private void OnCollisionEnter(Collision col)
    {
        // Stinger 
        if(col.gameObject.tag == "Stinger")
        {
            col.gameObject.GetComponent<StingerSuperClass>().takeDamage(damage);
        }
        // Chomper 
        else if (col.gameObject.tag == "Chomper")
        {
            col.gameObject.GetComponent<ChomperClass>().takeDamage(damage);
        }
        else if (col.gameObject.name == "StingerBullet(Clone)")
        {
            Destroy(col.gameObject);
        }
    }
}
