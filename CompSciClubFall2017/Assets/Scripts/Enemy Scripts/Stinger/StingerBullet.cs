/*
 * 
 * Author: Spencer Wilson, Hunter Goodin
 * Date Created: 11/14/2017 @ 10:19 pm
 * Date Modified: 11/14/2017 @ 10:20 pm
 * Project: CompSciClubFall2017
 * File: StingerBullet.cs
 * Description: This houses the code for the StingerBullet prefab.
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingerBullet : MonoBehaviour {

    public float speed;
    public int stingerDamage = 5; 

    private Rigidbody stingerbulletRigidbody; // Creating a variable to hold the Stinger rigidbody reference.
    private float lifetime = 1.5f; // Creating a float variable that holds the amount of seconds the object StingerBullet exists for before self-destructing.

	void Start()
    {
        stingerbulletRigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, lifetime); // Destroys this gameObject after two seconds.
	}

    public void FixedUpdate()
    {
        stingerbulletRigidbody.transform.Translate(-transform.right * Time.deltaTime * speed);
    }

    /* Hunter Goodin was here */
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 8)
        {
            GameObject.Find("Player").GetComponent<Player>().TakeDamage(stingerDamage);
        }
        else if (col.gameObject.tag == "Bolt(Clone)")
        {
            Destroy(col.gameObject);
        }
        else if (col.gameObject.name == "StingerBullet(Clone)")
        {
            Destroy(col.gameObject);
        }
        
    }
}
