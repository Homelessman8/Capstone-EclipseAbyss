using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void SwordDamage()
    {
        currentHealth -= 1;

        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void DaggerDamage()
    {
        currentHealth -= 1;

        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void AxeDamage()
    {
        currentHealth -= 1;

        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void GunDamage()
    {
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
            Destroy(gameObject);
        }
    }
}
