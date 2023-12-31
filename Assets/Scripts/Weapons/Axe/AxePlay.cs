using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxePlay : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public GameObject Axe;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("isSmashing", true);
        }
        else
        {
            animator.SetBool("isSmashing", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log($"Hit Enemy {1}");
                collision.gameObject.GetComponent<EnemyHealth>().AxeDamage();
            }

        if (collision.gameObject.CompareTag("MinotaurEnemy"))
        {
            collision.gameObject.GetComponent<MinotaurHealth>().AxeDamage();
        }
    }

}
