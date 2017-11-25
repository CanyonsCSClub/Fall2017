/*
 * Programmer: Karim Dabboussi
 * File Name: Greeting.cs
 * Description: This file has the code for a sytem that pops up text randomly on the main menu.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Greeting : MonoBehaviour
{
    public Text greetingText;
    public string greetingString;
    string[] greetings = new string[10];

    // Use this for initialization
    void Start()
    {
        Random random = new Random();
        int randomNumber = Random.Range(0, 10);
        Debug.Log(randomNumber);

        greetings[0] = "    In Space no one can hear you space";
        greetings[1] = "    Are you the hero or are you the enemy?";
        greetings[2] = "    Look at me mom, I am flying!";
        greetings[3] = "    Powered by I M A G I N A T I O N?";
        greetings[4] = "    Space is the real enemy";
        greetings[5] = "    Ramming is always a good trick, sometimes...";
        greetings[6] = "    Victory at all costs, unless it is to expensive";
        greetings[7] = "    A trip back to the 80s, without time travel";
        greetings[8] = "    Space Shooter 9000, because 8999 was not big enough";
        greetings[9] = "    There is only one certainty in space and that is...";

        greetingString = greetings[randomNumber];
        greetingText.text = greetingString.ToString();



    }
}
