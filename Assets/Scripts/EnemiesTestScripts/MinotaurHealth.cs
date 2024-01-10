using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private MinotaurHealthUi minotaurHealthBar;

    //public GameObject healthBar;

    void Start()
    {
        //animator.SetBool("isDead", false);
        currentHealth = maxHealth;
        minotaurHealthBar.SetMaxHealth(maxHealth);
    }

    public void SwordDamage()
    {
        animator.SetBool("isHit", true);
        currentHealth -= 2;
        minotaurHealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void DaggerDamage()
    {
       
        animator.SetBool("isHit", true);
        currentHealth -= 1;

        minotaurHealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void AxeDamage()
    {
        animator.SetBool("isHit", true);
        currentHealth -= 1;

        minotaurHealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void GunDamage()
    {
        animator.SetBool("isHit", true);
        currentHealth -= 1;

        minotaurHealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void EnemyDied()
    {

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            //animator.SetBool("isIdle", false);
            //animator.SetBool("isWalking", false);
            //animator.SetBool("isAttacking", false);
            animator.SetBool("isDead", true);
            //Destroy(healthBar);
            Invoke("DestroyMinotaur", 2.08f);
        }
    }

     void DestroyMinotaur()
    {
        Destroy(gameObject);
    }
}
