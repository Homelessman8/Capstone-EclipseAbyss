using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        Actions.OnEnemyAttacked += TakeDamage;
    }

    private void OnDisable()
    {
        Actions.OnEnemyAttacked -= TakeDamage;
    }

    public void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
        }
    }
}
