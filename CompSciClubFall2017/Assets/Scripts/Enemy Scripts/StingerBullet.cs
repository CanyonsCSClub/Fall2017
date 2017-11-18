/*
 * 
 * Author: Spencer Wilson
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

    private Rigidbody stingerbulletRigidbody; // Creating a variable to hold the Stinger rigidbody reference.
    private float lifetime = 2f; // Creating a float variable that holds the amount of seconds the object StingerBullet exists for before self-destructing.

	void Start()
    {
        stingerbulletRigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, lifetime); // Destroys this gameObject after two seconds.
	}

    public void FixedUpdate()
    {
        stingerbulletRigidbody.transform.Translate(-transform.right * Time.deltaTime * 100f);
    }

}
