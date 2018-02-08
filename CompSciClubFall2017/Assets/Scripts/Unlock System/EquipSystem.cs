using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System; 

public class EquipSystem : MonoBehaviour
{
    public int choiceNum;
    public string readNum;
    public string path; 

    public GameObject ship01;
    public GameObject ship02;
    public GameObject ship03;
    public GameObject ship04; 
    public GameObject ship05; 

    public void Start()
    {
        choiceNum = 0;
        path = "Assets/Scripts/Unlock System/ShipCurrentlyEquipped.txt"; 
    }

    public void ReadString()
    {
        StreamReader reader = new StreamReader(path);
        readNum = reader.ReadToEnd();
        Convert.ToInt32(readNum);
        choiceNum = Int32.Parse(readNum);                       // stores the value of the readNum string into our choiceNum int 
        reader.Close();
    }

    void Update()
    {
        ReadString();

        if (choiceNum == 0)
        {
            UnEquipAllShips(); 
            ship01.gameObject.SetActive(true);
        }
        if (choiceNum == 1)
        {
            UnEquipAllShips();
            ship02.gameObject.SetActive(true);
        }
        if (choiceNum == 2)
        {
            UnEquipAllShips();
            ship03.gameObject.SetActive(true);
        }
        if (choiceNum == 3)
        {
            UnEquipAllShips();
            ship04.gameObject.SetActive(true);
        }
        if (choiceNum == 4)
        {
            UnEquipAllShips();
            ship05.gameObject.SetActive(true);
        }
    }

    private void UnEquipAllShips()
    {
        ship01.gameObject.SetActive(false);
        ship02.gameObject.SetActive(false);
        ship03.gameObject.SetActive(false);
        ship04.gameObject.SetActive(false);
        ship05.gameObject.SetActive(false);
    }
}
