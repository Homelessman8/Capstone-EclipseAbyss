using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    //public Animator minotaurAnimator;

    public MinotaurHealthUi minotaurHealthBar;

    //public GameObject healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        minotaurHealthBar.SetMaxHealth(maxHealth);
    }

    public void SwordDamage()
    {
        minotaurHealthBar.SetHealth(currentHealth);
        //minotaurAnimator.SetBool("isHit", true);
        currentHealth -= 2;

        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void DaggerDamage()
    {
        minotaurHealthBar.SetHealth(currentHealth);
        //minotaurAnimator.SetBool("isHit", true);
        currentHealth -= 1;

        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void AxeDamage()
    {
        minotaurHealthBar.SetHealth(currentHealth);
        //minotaurAnimator.SetBool("isHit", true);
        currentHealth -= 1;

        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void GunDamage()
    {
        minotaurHealthBar.SetHealth(currentHealth);
        //minotaurAnimator.SetBool("isHit", true);
        currentHealth -= 1;

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
            //Destroy(healthBar);
            Destroy(gameObject);
        }
    }
}
