using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerPlayVersion2 : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public GameObject Dagger;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("isThrow", true);
        }
        else
        {
            animator.SetBool("isThrow", false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log($"Hit Enemy {1}");
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage();
            }
    }
}
