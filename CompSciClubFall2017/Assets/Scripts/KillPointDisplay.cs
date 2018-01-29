using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPointDisplay : MonoBehaviour
{
    public float lifeTime = 1f;
    private Rigidbody rb;
    public float speed;  
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;

        Destroy(gameObject, lifeTime);
    }
}
