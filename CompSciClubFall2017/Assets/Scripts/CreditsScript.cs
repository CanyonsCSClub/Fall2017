using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    void Start ()
    {
        
    }

    public void FixedUpdate() // FixedUpdate is called on a regular timeline. Use FixedUpdate for physics based functions that need to be executed.
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("hit space");
            Application.LoadLevel(0);
        }
    }
}
