using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public bool isResume;
    public bool isReturn;

    void OnMouseUp() {
        if (isResume)
        {
            Time.timeScale = 1;
        }
        if (isReturn)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}