/* 
* Programmer:	Hunter Goodin 
* Date:		11/24/2017 
* Project: 	CompSciClubFall2017
* Description: The Crabber Enemy's projectiles class. 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrabberBullet : MonoBehaviour
{
    private GameObject crabberBombGameObj;
    private GameObject playerGameObj;
    public Transform expLoc;
    public GameObject explosion;

    public Text pointPop;
    public GameObject ptVal;
    public Transform ptValLoc;
    public int scoreValue = 10; // We will use this to incriment the points 

    public float speedFollow = 10;
    public float speedLeft = 5;
    private bool isTracking; 

    private Rigidbody crabberBulletRigidbody; // Creating a variable to hold the Crabber rigidbody reference.
    private float lifetime = 10f; // Creating a float variable that holds the amount of seconds the object CrabberBullet exists for before self-destructing. 

    private float damRate = 0.5f;             // Spawn Rate. Pretty self explanitory 
    private float nextDam;            // Used to see when the function should spawn the next prefab 

    void Start()
    {
        crabberBulletRigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, lifetime); // Destroys this gameObject after two seconds.

        playerGameObj = GameObject.Find("Player"); // Assigns the gameObject named Player to teh playerGameObj reference variable.
        crabberBombGameObj = gameObject;
    }

    public void FixedUpdate()
    {
        if (isTracking == false)
        {
            MovPatLeft(); 
        }
        else if (isTracking == true)
        {
            MovPatFollow(); 
        }

    }

    private void OnTriggerEnter(Collider trig)
    {
        if (trig.tag == "Player")
        {
            isTracking = true; 
        }
    }

    void OnTriggerExit(Collider trig)
    {
        if (trig.tag == "Player")
        {
            isTracking = false;  
        }
    }

    private void MovPatFollow()
    {
        transform.position = Vector3.MoveTowards(crabberBombGameObj.transform.position, playerGameObj.transform.position, Time.deltaTime * speedFollow);
    }
    private void MovPatLeft()
    {
        crabberBulletRigidbody.transform.Translate(-transform.right * Time.deltaTime * speedLeft);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject); 
            Instantiate(explosion, expLoc.position, expLoc.rotation);
        }
        else if (col.gameObject.name == "Bolt(Clone)")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(explosion, expLoc.position, expLoc.rotation);

            GameObject.Find("DisplayPoints").GetComponent<PointSystem>().UpdateScore(scoreValue);
            Instantiate(ptVal, ptValLoc.position, ptValLoc.rotation);
        }
        else if (col.gameObject.name == "StingerBullet(Clone)")
        {
            Destroy(gameObject);
            Instantiate(explosion, expLoc.position, expLoc.rotation);
        }
        else if (col.gameObject.name == "CrabberExplosion(Clone)")
        {
            Destroy(gameObject);
            Instantiate(explosion, expLoc.position, expLoc.rotation);
        }
        else if (col.gameObject.name == "AsteroidUp(Clone)")
        {
            Destroy(gameObject);
            Instantiate(explosion, expLoc.position, expLoc.rotation);
        }
        else if (col.gameObject.name == "AsteroidDown(Clone)")
        {
            Destroy(gameObject);
            Instantiate(explosion, expLoc.position, expLoc.rotation);
        }
        else if (col.gameObject.name == "Stinger(Clone)")
        {
            Destroy(gameObject);
            Instantiate(explosion, expLoc.position, expLoc.rotation);
        }
        else if (col.gameObject.name == "Crabber(Clone)")
        {
            Destroy(gameObject);
            Instantiate(explosion, expLoc.position, expLoc.rotation);
        }
        else if (col.gameObject.name == "Chomper(Clone)")
        {
            Destroy(gameObject);
            Instantiate(explosion, expLoc.position, expLoc.rotation);
        }
        else if (col.gameObject.name == "ChomperLazer(Clone)")
        {
            Destroy(gameObject);
            Instantiate(explosion, expLoc.position, expLoc.rotation);
        }
    }
}
