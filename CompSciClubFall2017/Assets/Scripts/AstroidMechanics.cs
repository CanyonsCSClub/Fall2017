/*
 * Asteroid.cs
 * Created by: Jack Bruce
 * Description: Asteroid movement controller
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMechanics : MonoBehaviour
{
    public float speed;
    public float tumble;
    private Vector3 astroidPos;
    private Vector3 playerPos;
    private Vector3 newPos;

    private Rigidbody astroidRB;

    void Start()
    {


        astroidRB = GetComponent<Rigidbody>();

        // up movement
        astroidPos = astroidRB.position;
        playerPos = GameObject.Find("Player").GetComponent<Transform>().position;
        newPos = new Vector3(playerPos.x, playerPos.y, 0f);
        transform.position = Vector3.MoveTowards(astroidPos, newPos, Time.deltaTime * speed);

        //random rotation
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;

    }
}
