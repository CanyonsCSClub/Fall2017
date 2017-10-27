using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public float tumble;
    //public float xpos = Random.Range(-5, 5);
    //public Vector3 spawnLocation = new Vector3(0f, 0.5f, 0f);

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


