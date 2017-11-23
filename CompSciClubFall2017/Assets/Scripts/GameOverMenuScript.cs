/*
 * 
 * Programmer: Hunter Goodin
 * Date Created: 10/20/2017
 * Project: CompSciClubFall2017
 * File: GameOverMenu.cs
 * Description: This is almost a carbon copy of Evan's MainMenu.cs script. 
 *              This will be used for the game's "Game Over" screen. 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGameOverMenuScript : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;

    void OnMouseUp()
    {
        if (isStart)
        {
            Application.LoadLevel(1);   // This loads the scene set as the first level 
        }
        if (isQuit)
        {
            Application.Quit();         // This exits the game 
        }
    }
}
