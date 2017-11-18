/*
 * 
 * Authors: Brenden Karuna Plong
 * Date Created: 10/27/2017 @ 11:51 pm
 * Date Modified: 10/28/2017 @ 2:04 pm
 * Project: CompSciClubFall2017
 * File: Boundary.cs
 * Description: File that houses all of the code for the boundaries of game objects.
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Boundary : MonoBehaviour {
    public float xMin, xMax, zMin, zMax;
    private Rigidbody rb;

    private void FixedUpdate()
    {
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax),0.0f,Mathf.Clamp(rb.position.z, zMin, zMax));
    }
}
