<<<<<<< HEAD
<<<<<<< Updated upstream
﻿using UnityEngine;
=======
﻿/*
 * Asteroid.cs
 * Created by: Jack Bruce
 * Description: Asteroid movement controller
 */


using UnityEngine;
>>>>>>> Stashed changes
using System.Collections;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public float tumble;
<<<<<<< Updated upstream
    //public float xpos = Random.Range(-5, 5);
    //public Vector3 spawnLocation = new Vector3(0f, 0.5f, 0f);

    void Start()
    {

=======
    //static public float xpos = Random.Range(-5f, 5f);
    //public Vector3 spawnLocation = new Vector3(xpos, 0.5f, 0f);


    void Start()
    {
        
>>>>>>> Stashed changes
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


=======
﻿/*
 * 
 * Authors: Andrew Ramirez
 * Date Created: 10/28/2017 @ 5:29 pm
 * Date Modified: 10/29/2017 @ 3:35 pm
 * Project: CompSciClubFall2017
 * File: Asteroid.cs
 * Description: This is the asteroid class used to test collision for the player object
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    
    // Destroy this object on collision
    public void OnCollisionEnter(Collision collision)
    {
       //todo asteroid collision animation
         
       // Destroy(gameObject); Disabled in order to test if lives and health is working 
    }
}
>>>>>>> master
