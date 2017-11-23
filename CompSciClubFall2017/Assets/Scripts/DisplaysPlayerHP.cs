/* 
 * Programmer:	Hunter Goodin 
 * Date:		11/21/2017 
 * Project: 	CompSciClubFall2017
 * Description: Displaying the player's HP stat in the play space. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DisplaysPlayerHP : MonoBehaviour
{

    public int playerHP;    // We will populate this with what the player's HP is. 
    public Text HPText;

    // Use this for initialization
    void Start()
    {
        HPText.text = playerHP.ToString();
    }

    // Update is called once per frame
    void Update ()
    {
       // playerHP = GameObject.Find("Player").GetComponent<Player>().setHealthandLiveText();
        HPText.text = playerHP.ToString();
    }
}
