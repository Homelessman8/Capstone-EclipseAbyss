using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        Actions.OnPlayerAttacked += TakeDamage;
    }

    private void OnDisable()
    {
        Actions.OnPlayerAttacked -= TakeDamage;
    }

    private void TakeDamage()
    {
        currentHealth--;
        Debug.Log($"Hit Player: {currentHealth}");

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Player Has Died");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyWeapon"))
        {
            TakeDamage();
        }
        
    }
}
