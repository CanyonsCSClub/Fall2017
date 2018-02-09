/*
 * Asteroid.cs
 * Created by: Jack Bruce
 * Description: Asteroid movement controller
 */


using UnityEngine;
using System.Collections;

public class AsteroidUp   : MonoBehaviour
{
    public float speed;
    public float tumble;
    public int asteroidDamage = 15;

    void Start()
    {

        //straight forward movement
        GetComponent<Rigidbody>().velocity = transform.up * speed;

        //random rotation
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 8)
        {
            GameObject.Find("Player").GetComponent<Player>().TakeDamage(asteroidDamage);
        }
        else if (col.gameObject.tag == "Bolt(Clone)")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        else if (col.gameObject.name == "StingerBullet(Clone)")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        else if (col.gameObject.name == "Stinger(Clone)")
        {
            col.gameObject.GetComponent<ChomperClass>().takeDamage(1);
        }
        else if (col.gameObject.name == "Chomper(Clone)")
        {
            col.gameObject.GetComponent<ChomperClass>().takeDamage(1);
        }
        else if (col.gameObject.name == "Crabber(Clone)")
        {
            col.gameObject.GetComponent<ChomperClass>().takeDamage(1);
        }
        else if (col.gameObject.name == "Striker(Clone)")
        {
            col.gameObject.GetComponent<ChomperClass>().takeDamage(1);
        }
    }
}


