/*
 * 
 * Authors: Andrew Ramirez
 * Date Created: 10/28/2017 @ 5:29 pm
 * Date Modified: 10/29/2017 @ 3:35 pm
 * Project: CompSciClubFall2017
 * File: Health.cs
 * Description: This is the health class used for the player and enemy objects
 * 
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class handles hitpoints and damage
public class Health : MonoBehaviour {

    public int hp = 1;
    public bool isEnemy = true;

    public void Damage(int damageCount, bool isEnemy)
    {
        this.hp -= damageCount; // decrements objects hp by damageCount

        if (isEnemy && hp <= 0) // For enemy objects
        {
            // todo explosion animation and sound effect
            // Dead! rip in pieces
            Destroy(gameObject);
        }
        else if (hp <= 0) { // For the player object
           // Dead! rip in pieces
           // todo death animation
           // todo respawn player
        }
    }
}
