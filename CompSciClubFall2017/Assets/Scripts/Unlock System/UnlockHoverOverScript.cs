using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockHoverOverScript : MonoBehaviour
{
    public Text pop;
    public Text pop2; 

    void OnMouseOver()
    {
        pop.gameObject.SetActive(true);
        pop2.gameObject.SetActive(true);

    }

    void OnMouseExit()
    {
        pop.gameObject.SetActive(false);
        pop2.gameObject.SetActive(false);

    }
}


