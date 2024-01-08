using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public Animator minotaurAnimator;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void SwordDamage()
    {
        minotaurAnimator.SetBool("isHit", true);
        currentHealth -= 2;

        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void DaggerDamage()
    {
        minotaurAnimator.SetBool("isHit", true);
        currentHealth -= 1;

        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void AxeDamage()
    {
        minotaurAnimator.SetBool("isHit", true);
        currentHealth -= 5;

        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void GunDamage()
    {
        minotaurAnimator.SetBool("isHit", true);
        currentHealth -= 1;

        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void EnemyDied()
    {
        currentHealth -= 1;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
        }
    }
}
