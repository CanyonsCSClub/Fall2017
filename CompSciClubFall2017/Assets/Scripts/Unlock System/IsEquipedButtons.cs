using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System; 

public class IsEquipedButtons : MonoBehaviour
{
    public bool isShip01;
    public bool isShip02;
    public bool isShip03;
    public bool isShip04;
    public bool isShip05;

    public string path;         // This will hold address where the .txt file is 

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");     // Finding the player object 
        path = "Assets/Scripts/Unlock System/ShipCurrentlyEquipped.txt";    // Setting path to the address where the .txt file is 
    }

    void OnMouseUp()
    {
        if (isShip01)
        {
            var writing = File.CreateText(path); 
            writing.Write("0");
            writing.Close();
        }
        if (isShip02)
        {
            var writing = File.CreateText(path);
            writing.Write("1");
            writing.Close();
        }
        if (isShip03)
        {
            var writing = File.CreateText(path);
            writing.Write("2");
            writing.Close();
        }
        if (isShip04)
        {
            var writing = File.CreateText(path);
            writing.Write("3");
            writing.Close();
        }
        if (isShip05)
        {
            var writing = File.CreateText(path);
            writing.Write("4");
            writing.Close();
        }
    }
}
