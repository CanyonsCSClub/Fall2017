/* 
 * Programmer:	Hunter Goodin 
 * Date:		1/28/2018 
 * Project: 	CompSciClubFall2017
 * Description: Creating the explosion that the Crabber's Bomb till instantiate.  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabberExplosion : MonoBehaviour
{

    public float speed;
    public int crabberDamage = 10;
    public int crabberDamToEnem = 2;
    private float incriment = 0.1f;

    private Rigidbody crabberExplosionRigidbody; // Creating a variable to hold the Stinger rigidbody reference.
    private float lifetime = 1.5f; // Creating a float variable that holds the amount of seconds the object StingerBullet exists for before self-destructing.

    void Start()
    {
        crabberExplosionRigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, lifetime); // Destroys this gameObject after two seconds.
    }

    public void FixedUpdate()
    {
        gameObject.transform.localScale += new Vector3(incriment, incriment, incriment);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 8)
        {
            GameObject.Find("Player").GetComponent<Player>().TakeDamage(crabberDamage);
        }
        if (col.gameObject.tag == "Stinger")
        {
            col.gameObject.GetComponent<StingerClass>().TakeDamage(crabberDamToEnem);
        }
        // Chomper 
        else if (col.gameObject.tag == "Chomper")
        {
            col.gameObject.GetComponent<ChomperClass>().takeDamage(crabberDamToEnem);
        }
        // Crabber 
        else if (col.gameObject.tag == "Crabber")
        {
            col.gameObject.GetComponent<CrabberClass>().takeDamage(crabberDamToEnem);
        }
        // Striker 
        else if (col.gameObject.tag == "Striker")
        {
            col.gameObject.GetComponent<StrikerClass>().TakeDamage(crabberDamToEnem);
        }
        else if (col.gameObject.name == "Bolt(Clone)")
        {
            Destroy(col.gameObject); 
        }
        else if (col.gameObject.name == "StingerBullet(Clone)")
        {
            Destroy(col.gameObject);
        }
    }
}
