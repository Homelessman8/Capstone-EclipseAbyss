using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPlay : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public GameObject Sword;

    public BoxCollider swordCollider;

    void Start()
    {
        BoxCollider swordCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
            if (Input.GetMouseButton(0))
            {
                animator.SetBool("isSlashing", true);
                swordCollider.enabled = true;
            }
            else
            {
                animator.SetBool("isSlashing", false);
                swordCollider.enabled = false;
            }


            if (Input.GetMouseButton(1))
            {
                animator.SetBool("isThrusting", true);
                swordCollider.enabled = true;
            }
            else
            {
                animator.SetBool("isThrusting", false);
                swordCollider.enabled = false;
            }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"Hit Enemy {1}");
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage();
        }
            
    }
}
