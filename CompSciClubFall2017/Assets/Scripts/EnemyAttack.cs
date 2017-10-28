using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{



    void OnCollisionStay(Collision collision)
    {
        Debug.Log("test");
        var hit = collision.gameObject;
        var health = hit.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(10);
            Debug.Log(health);
        }

        Destroy(gameObject);
    }
}