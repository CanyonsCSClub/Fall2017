using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour {
    Canvas CanvasObject;
    // Use this for initialization
    void Start () {
        CanvasObject = GetComponent<Canvas>();
        //CanvasObject.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (Time.timeScale == 0f)
        {
            CanvasObject.enabled = true;
        } else
        {
            CanvasObject.enabled = false;
        }

    }
}
