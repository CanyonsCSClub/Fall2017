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
        { Application.LoadLevel(0); }
        if (isStart)
    	{ Application.LoadLevel(1); }
        if (isHangar)
        { Application.LoadLevel(2); }
        if (isControls)
        { Application.LoadLevel(3); }
        if (isCredits)
        { Application.LoadLevel(4); }
        if (isQuit)
	    { Application.Quit(); }
        if (isResume)
        {
            canvasObj.gameObject.SetActive(false); 
            Time.timeScale = 1;
        }
    } 
}
