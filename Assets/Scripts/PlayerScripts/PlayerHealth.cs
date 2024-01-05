using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    // [SerializeField]
    //private Transform player;

    public GameObject player;

    private int maxHealth = 100;
    private int currentHealth;

    Rigidbody rb;

    public HealthUI healthBar;

    public GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnEnable()
    {
        Actions.OnPlayerAttacked += TakeDamage;
        Actions.OnPlayerDied += CancelInput;
    }

    private void OnDisable()
    {
        Actions.OnPlayerAttacked -= TakeDamage;
        Actions.OnPlayerDied -= CancelInput;
    }

    private void CancelInput()
    {
        Debug.Log("Dead");
        Time.timeScale = 0f;
    }

    private void TakeDamage()
    {
        currentHealth--;
        Debug.Log($"Hit Player: {currentHealth}");

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Actions.OnPlayerDied.Invoke();
            gameManager.GameOver();
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
