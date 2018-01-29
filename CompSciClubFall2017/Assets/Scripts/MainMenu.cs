using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public bool isStart;
    public bool isChallenge;
    public bool isGallery; 
    public bool isCredits;
    public bool isQuit;

    void OnMouseUp()
    {
	    if(isStart)
    	{ Application.LoadLevel(1); }
        if (isCredits)
        { Application.LoadLevel(2); }
        if (isQuit)
	    { Application.Quit(); }
    } 
}
