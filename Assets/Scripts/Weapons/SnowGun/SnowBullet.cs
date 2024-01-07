using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBullet : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject,4f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"Hit Enemy {1}");
            collision.gameObject.GetComponent<EnemyHealth>().GunDamage();
            Destroy(gameObject);
        }
        
    }
}
