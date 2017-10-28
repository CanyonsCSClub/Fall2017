/*
 * GameController.cs
 * Created By: Jack Bruce
 * Description: Controlling gameobjects of things that spawn and hurt player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard; // any enemy or asteroid
    public Vector3 spawnValues;

    void Start() {
        SpawnWaves();
    }

    void SpawnWaves () {
        Vector3 spawnPosition = new Vector3();
        Quaternion spawnRotation = new Quaternion();
        Instantiate(hazard, spawnPosition, spawnRotation); 
    }
}