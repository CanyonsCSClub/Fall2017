using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingerBullet : MonoBehaviour {

    private Rigidbody stingerbulletRigidbody; // Creating a variable to hold the Stinger rigidbody reference.

	void Start () {
        stingerbulletRigidbody = GetComponent<Rigidbody>();
	}

    public void FixedUpdate()
    {
        stingerbulletRigidbody.transform.Translate(-transform.right * Time.deltaTime * 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (GameObject.Find("PlayerTester"))
        //    {
        //    GameObject.Find("PlayerTester").GetComponent<Player>takeDamage();
        //    }
    }

}
