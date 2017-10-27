/*
 * 
 * Authors: Keaton Maki
 * Date Created: 10/25/2017 @ 5:29 pm
 * Date Modified: 10/25/2017 @ 5:04 pm
 * Project: CompSciClubFall2017
 * File: Enemy.cs
 * Description: Parent class for all enemy child classes.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Enemy: MonoBehaviour{
    //values that can be applied to any enemy child. 
    //private float damage; 
    private float health;
    private float speed;

    //private WeaponType weapon;

    //damage = default;
    //health = default;
    //speed = default;

    //Setters
    /*
    public void setDamage(float newDamage){
        damage = newDamage;
    }
    */

    public void setHealth(float newHealth){
        health = newHealth;
    }
    public void setSpeed(float newSpeed){
        speed = newSpeed;
    }

    //Getters
    /*public float getDamage(){
        return damage;
    }
    */
    public float getHealth(){
        return health;
    }
    public float getSpeed(){
        return speed;
    }

}
