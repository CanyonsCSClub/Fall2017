 /* 
 * Programmer:	Hunter Goodin 
 * Date:		11/24/2017 
 * Project: 	CompSciClubFall2017
 * Description: The Chomper Enemy's projectiles class. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperBullet : MonoBehaviour {

    public float speed;
    public int chomperDamage = 10; 

    private Rigidbody chomperBulletRigidbody; // Creating a variable to hold the Chomper rigidbody reference.
    private float lifetime = 2f; // Creating a float variable that holds the amount of seconds the object ChomperBullet exists for before self-destructing.

	void Start()
    {
        chomperBulletRigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, lifetime); // Destroys this gameObject after two seconds.
	}

    public void FixedUpdate()
    {
        //chomperBulletRigidbody.transform.Translate(-transform.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 8)
        {
            if (col.gameObject.tag == "Stinger")
            {
                GameObject.Find("Player").GetComponent<Player>().TakeDamage(chomperDamage);
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

}
