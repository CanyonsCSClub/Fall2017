/*
 * Asteroid.cs
 * Created by: Jack Bruce
 * Description: Asteroid movement controller
 */


using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public float tumble;
    //static public float xpos = Random.Range(-5f, 5f);
    //public Vector3 spawnLocation = new Vector3(xpos, 0.5f, 0f);


    void Start()
    {
        
        //random position
        //GetComponent<Rigidbody>().position = spawnLocation;

        //straight forward movement
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

        //random rotation
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;

    }


}

    // called once per frame
    //void Update() {
        //if off the plane, asteroid is gonna die

    //}


