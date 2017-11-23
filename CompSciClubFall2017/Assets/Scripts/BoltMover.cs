/* 
 * Programmer:	Hunter Goodin 
 * Date:		11/5/2017 
 * Project: 	CompSciClubFall2017
 * Description: Creating the Bolt object the player will shoot. 
 */

using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class BoltMover : MonoBehaviour
{
    public float speed;             // The speed at which the Bolt moves. This float can be accessed in-engine when inspecting the Bolt prefab. 
    public int damage = 1;

    private Rigidbody rb;           // Creating the Rigidbody for this script named 'rb'. 
    private float lifetime = 1.5f;    // We will use this to destory our bolts after 2 second. 

    void Start()			// The following code will occur the frame a Bolt is created. 
    {
        rb = GetComponent<Rigidbody>(); 			 // rb is set to Bolt's Rigidbody established in-engine. 
        rb.velocity = transform.right * speed;       // The Rigidbody will move right based on the speed float. 
        Destroy(gameObject, lifetime);               // Destroys this object based on our lifetime float we created earlier. 
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Stinger")
        {
            GameObject.Find("Stinger").GetComponent<StingerSuperClass>().takeDamage(damage);
        }
        else if (col.gameObject.name == "Stinger (1)")
        {
            GameObject.Find("Stinger (1)").GetComponent<StingerSuperClass>().takeDamage(damage);
        }
        else if (col.gameObject.name == "Stinger (2)")
        {
            GameObject.Find("Stinger (2)").GetComponent<StingerSuperClass>().takeDamage(damage);
        }
        else if (col.gameObject.name == "Stinger (3)")
        {
            GameObject.Find("Stinger (3)").GetComponent<StingerSuperClass>().takeDamage(damage);
        }
        else if (col.gameObject.name == "Stinger (4)")
        {
            GameObject.Find("Stinger (4)").GetComponent<StingerSuperClass>().takeDamage(damage);
        }
        else if (col.gameObject.name == "Stinger (5)")
        {
            GameObject.Find("Stinger (5)").GetComponent<StingerSuperClass>().takeDamage(damage);
        }
        else if (col.gameObject.name == "StingerBullet(Clone)")
        {
            Destroy(col.gameObject);
        }
    }
}
