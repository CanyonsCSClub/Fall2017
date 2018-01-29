using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Displayer : MonoBehaviour
{
    public Text pointPop;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        pointPop.transform.position = namePos;
    }
}
