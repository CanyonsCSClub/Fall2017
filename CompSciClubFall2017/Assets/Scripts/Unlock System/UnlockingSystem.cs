using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class UnlockingSystem : MonoBehaviour
{
    public string highScorePath = "Assets/Scripts/Point System/HighScore.txt";
    public string allUnlockedPath = "Assets/Scripts/Unlock System/WhatIsUnlocked.txt";

    public GameObject ship01ScriptObj;
    public GameObject ship02ScriptObj;
    public GameObject ship03ScriptObj;
    public GameObject ship04ScriptObj;
    public GameObject ship05ScriptObj;

    public GameObject ship02HoverObj;
    public GameObject ship03HoverObj;
    public GameObject ship04HoverObj;
    public GameObject ship05HoverObj; 

    public GameObject ship02Name;
    public GameObject ship03Name;
    public GameObject ship04Name;
    public GameObject ship05Name;

    public GameObject ship02Q;
    public GameObject ship03Q;
    public GameObject ship04Q;
    public GameObject ship05Q;

    public GameObject ship02Model;
    public GameObject ship03Model;
    public GameObject ship04Model;
    public GameObject ship05Model;

    public Text disShip03Prog;
    public Text disShip04Prog;
    public Text disShip05Prog;

    public int ship02Prog;                  // How many points to get Space Shuttle 
    private string ship02ProgToInt;         // String holding this^ number 
    private int ship03Prog;                 // How many Stingers killed 
    private string ship03ProgToInt;         // String holding this^ number 
    private int ship04Prog;                 // How many Chompers killed 
    private string ship04ProgToInt;         // String holding this^ number 
    private int ship05Prog;                 // How many Crabbers killed 
    private string ship05ProgToInt;         // String holding this^ number 

    private int ship02Req = 5000;           // How many points needed to unlock Ship02          ( Space Shuttle )
    private int ship03Req = 50;             // How many Stinger kills needed to unlock Ship03   ( Sting Class Ship ) 
    private int ship04Req = 50;             // How many Chomper kills needed to unlock Ship04   ( Chomp Class Ship )
    private int ship05Req = 50;             // How many Crabber kills needed to unlock Ship05   ( Crabb Class Ship ) 

    private string isShip01Unlocked;        // Y means it is unlocked, N means it isn't 
    private string isShip02Unlocked;        // Y means it is unlocked, N means it isn't 
    private string isShip03Unlocked;        // Y means it is unlocked, N means it isn't 
    private string isShip04Unlocked;        // Y means it is unlocked, N means it isn't 
    private string isShip05Unlocked;        // Y means it is unlocked, N means it isn't 

    public bool overrideWriter; 

    public List<string> readList  = new List<string>();

    void Start()
    {
        UnlockedReader();

        HighScoreReader(); 

        if(overrideWriter)
        {

        }
        else
        {
            UnlockedWriter(); 
        }
        UnlockedReader();

        Unlocker();

        disShip03Prog.text = ship03Prog + "/50 Stingers destroyed to unlock";
        disShip04Prog.text = ship04Prog + "/50 Chompers destroyed to unlock";
        disShip05Prog.text = ship05Prog + "/50 Crabbers destroyed to unlock";
    }

    public void UnlockedReader()
    {
        StreamReader reader = new StreamReader(allUnlockedPath);

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            readList.Add(line);
        }

        isShip01Unlocked = readList[3];
        isShip02Unlocked = readList[5];
        isShip03Unlocked = readList[7];
        isShip04Unlocked = readList[9];
        isShip05Unlocked = readList[11];

        ship02ProgToInt = readList[14];
        ship03ProgToInt = readList[16];
        ship04ProgToInt = readList[18];
        ship05ProgToInt = readList[20];

        Convert.ToInt32(ship02ProgToInt);
        ship02Prog = Int32.Parse(ship02ProgToInt);
        Convert.ToInt32(ship03ProgToInt);
        ship03Prog = Int32.Parse(ship03ProgToInt);
        Convert.ToInt32(ship04ProgToInt);
        ship04Prog = Int32.Parse(ship04ProgToInt);
        Convert.ToInt32(ship05ProgToInt);
        ship05Prog = Int32.Parse(ship05ProgToInt);

        reader.Close();
    }

    public void HighScoreReader()
    {
        StreamReader reader = new StreamReader(highScorePath); 		// Creating an object that can read .txt files

        ship02ProgToInt = reader.ReadToEnd();							// Set highScoreSt to the string thhat is the entire .txt doc 
        Convert.ToInt32(ship02ProgToInt);								// Convert highScoreSt to be used as an int 
        ship02Prog = Int32.Parse(ship02ProgToInt);					// Setting highScoreInt to the int value of highScoreSt 
        reader.Close(); 											// Close the reader
    }

    public void UnlockedWriter()
    {
        StreamWriter writer = new StreamWriter(allUnlockedPath);

        readList[14] = "" + ship02Prog;

        if (ship02Prog >= ship02Req) 
        {
            readList[5] = "Y";
        }
        if (ship03Prog >= ship03Req) 
        {
            readList[7] = "Y";
        }
        if (ship04Prog >= ship04Req)
        {
            readList[9] = "Y";
        }
        if (ship05Prog >= ship05Req)
        {
            readList[11] = "Y";
        }

        for (int r = 0; r < readList.Count; r++)
        {
            writer.WriteLine(readList[r]);
        }
        writer.Close(); 
    }

    private void Unlocker()
    {

        if (readList[5] == "Y")
        {
            //ship02ButtonObj.gameObject.SetActive(true);
            ship02ScriptObj.gameObject.SetActive(true);
            ship02Name.gameObject.SetActive(true);
            ship02Q.gameObject.SetActive(false);
            ship02Model.gameObject.SetActive(true);
            ship02HoverObj.gameObject.SetActive(false); 
        }
        if (readList[7] == "Y")
        {
            //ship03ButtonObj.gameObject.SetActive(true);
            ship03ScriptObj.gameObject.SetActive(true);
            ship03Name.gameObject.SetActive(true);
            ship03Q.gameObject.SetActive(false);
            ship03Model.gameObject.SetActive(true);
            ship03HoverObj.gameObject.SetActive(false);

        }
        if (readList[9] == "Y")
        {
            //ship04ButtonObj.gameObject.SetActive(true);
            ship04ScriptObj.gameObject.SetActive(true);
            ship04Name.gameObject.SetActive(true);
            ship04Q.gameObject.SetActive(false);
            ship04Model.gameObject.SetActive(true);
            ship04HoverObj.gameObject.SetActive(false);

        }
        if (readList[11] == "Y")
        {
            //ship05ButtonObj.gameObject.SetActive(true);
            ship05ScriptObj.gameObject.SetActive(true);
            ship05Name.gameObject.SetActive(true);
            ship05Q.gameObject.SetActive(false);
            ship05Model.gameObject.SetActive(true);
            ship05HoverObj.gameObject.SetActive(false);

        }
    }
}
