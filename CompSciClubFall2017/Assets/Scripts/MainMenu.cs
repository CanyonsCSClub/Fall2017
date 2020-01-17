using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public bool isStart;
    public bool isChallenge;
    public bool isGallery; 
    public bool isCredits;
    public bool isQuit;
    public bool isMainMenu; 
    public bool isControls;
    public bool isHangar;
    public bool isResume;

    public Transform canvasObj;     // Populated with the pause canvas in-engine 

    void OnMouseUp()
    {
        if (isMainMenu)
        {
            Time.timeScale = 1;
            Application.LoadLevel(0);
        }
        if (isStart)
    	{
            Time.timeScale = 1;
            Application.LoadLevel(1);
        }
        if (isHangar)
        {
            Time.timeScale = 1;
            Application.LoadLevel(2);
        }
        if (isControls)
        {
            Time.timeScale = 1;
            Application.LoadLevel(3);
        }
        if (isCredits)
        {
            Time.timeScale = 1;
            Application.LoadLevel(4);
        }
        if (isQuit)
	    {
            Time.timeScale = 1;
            Application.Quit();
        }
        if (isResume)
        {
            canvasObj.gameObject.SetActive(false); 
            Time.timeScale = 1;
        }
    } 
}
