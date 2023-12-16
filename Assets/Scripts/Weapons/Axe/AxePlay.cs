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
            Actions.OnEnemyAttacked?.Invoke();
            collision.gameObject.GetComponent<Enemy>().currentHealth -= 1;
        }

    }

}
