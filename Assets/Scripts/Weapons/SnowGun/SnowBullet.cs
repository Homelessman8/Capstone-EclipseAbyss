using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBullet : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 10f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"Hit Enemy {1}");
            Actions.OnEnemyAttacked?.Invoke();
            collision.gameObject.GetComponent<Enemy>().currentHealth -= 1;
            Destroy(gameObject);
        }
        
    }
}
