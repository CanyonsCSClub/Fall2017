/* 
* Programmer:	Hunter Goodin 
* Date:	    	11/5/2017 
* Project: 	    CompSciClubFall2017
* Description:  Creating the pause functionality in the game. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Transform canvasObj;     // Populated with the pause canvas in-engine 

    void Update ()
    {
        if ( Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("p") )    // If the player presses the Escape key or the P key ... 
        {
            if ( canvasObj.gameObject.activeInHierarchy == false )          // If the canvas is inactive ... 
            {
                canvasObj.gameObject.SetActive(true);                       // Make the canvas active 
                Time.timeScale = 0;                                         // Slow down time to 0 
            }
            else
            {
                canvasObj.gameObject.SetActive(false);                      // Make the canvas inactive 
                Time.timeScale = 1;                                         // Set the time back to regular pace 
            }
        }
    }
}
