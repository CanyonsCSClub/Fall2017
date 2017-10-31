/*
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
