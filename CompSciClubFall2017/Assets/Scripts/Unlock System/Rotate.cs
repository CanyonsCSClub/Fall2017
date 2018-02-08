using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool isUp;
    public bool isDown;
    public bool isLeft;
    public bool isRight; 

	void Update ()
    {
        if (isUp)
        {
            GetComponent<Rigidbody>().transform.Rotate(Vector3.up * Time.deltaTime * 100);
        }
        if (isDown)
        {
            GetComponent<Rigidbody>().transform.Rotate(Vector3.down * Time.deltaTime * 100);
        }
        if (isLeft)
        {
            GetComponent<Rigidbody>().transform.Rotate(Vector3.left * Time.deltaTime * 100);
        }
        if (isRight)
        {
            GetComponent<Rigidbody>().transform.Rotate(Vector3.right * Time.deltaTime * 100);
        }
    }
}
