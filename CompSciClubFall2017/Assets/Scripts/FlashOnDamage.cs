/*
 * 
 * Author: Spencer Wilson
 * Date Created: 1/29/2018 @ 9:02 pm
 * Date Modified: 2/4/2018 @ 6:04 pm
 * Project: CompSciClubFall2017
 * File: EnemyFlashOnDamage.cs
 * Description: This file contains the code for the enemy's flash upon being hit by the player's weaponry.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOnDamage : MonoBehaviour {

    public MeshRenderer meshRend; // Creating a public MeshRenderer variable named meshRend.
    public Renderer renderer; 
    private Color originalColor; // Creating a private Color variable named originalColor that stores the original color of the attached game object.
    public Color newColor; // Creating a public Color variable named newColor that holds the new color that the object flashes too.
    private Color currentColor;
    public float flashSpeed; // Creating a public float variable named flashSpeed.

    private void Start()
    {

    }

    public IEnumerator Flash()
    {
        float timeFlashing = 0f;
        var currentColor = newColor;
        while(timeFlashing < 1)
        {
            Debug.Log("Flashing!");
            timeFlashing += Time.deltaTime;
            yield return new WaitForSeconds(flashSpeed);
            timeFlashing += flashSpeed;
            if(currentColor == newColor)
            {
                Debug.Log("Flashing white.");
            }
            else
            {
                Debug.Log("Flashing red.");
            }
        }
    }
}
