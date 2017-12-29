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

    public const float speed = 5f;
    public int chomperDamage = 10; 

    private Rigidbody chomperBulletRigidbody; // Creating a variable to hold the Chomper rigidbody reference.
    private float lifetime = 0.5f; // Creating a float variable that holds the amount of seconds the object ChomperBullet exists for before self-destructing. 

    private float damRate = 0.5f;             // Spawn Rate. Pretty self explanitory 
    private float nextDam;            // Used to see when the function should spawn the next prefab 

    private GameObject player;
    private Vector3 newPos;
    private Vector3 currPos;

    void Start()
    {
        player = GameObject.Find("Player");
        chomperBulletRigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, lifetime); // Destroys this gameObject after two seconds.
	}

    public void FixedUpdate() // Serves to track the Chomper's lazer beam's movement.
    {
        currPos = transform.position;
        newPos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 8 && Time.time > nextDam)
        {
            nextDam = Time.time + damRate;
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
