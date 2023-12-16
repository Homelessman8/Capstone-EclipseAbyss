using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPlay : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public GameObject Sword;

    void Update()
    {
            if (Input.GetMouseButton(0))
            {
                animator.SetBool("isSlashing", true);
            }
            else
            {
                animator.SetBool("isSlashing", false);
            }


            if (Input.GetMouseButton(1))
            {
                animator.SetBool("isThrusting", true);
            }
            else
            {
                animator.SetBool("isThrusting", false);
            }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"Hit Enemy {1}");
            Actions.OnEnemyAttacked?.Invoke();
            collision.gameObject.GetComponent<Enemy>().currentHealth -= 1;
            Debug.Log("Hit Object");
        }
            
    }
}
