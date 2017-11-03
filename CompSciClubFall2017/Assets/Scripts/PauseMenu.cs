using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isResume;
    public bool isReturnToMenu;

    void OnMouseUp()
    {
        if (isResume)
        {
            Time.timeScale = 1;
            Application.LoadLevel(1);
            // How to unpause
        }
        if (isReturnToMenu)
        {
            Time.timeScale = 1;
            Application.LoadLevel(0);
        }
    }
}