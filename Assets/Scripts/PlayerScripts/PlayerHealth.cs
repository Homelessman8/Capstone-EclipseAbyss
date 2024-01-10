using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    // [SerializeField]
    //private Transform player;

    public GameObject player;

    [HideInInspector]
    public int maxHealth = 100;

    [HideInInspector]
    public int currentHealth;

    Rigidbody rb;

    public HealthUI healthBar;

    public TextMeshProUGUI healthText;

    public GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthText.SetText($"{maxHealth}");
    }

    private void OnEnable()
    {
        Actions.OnPlayerAttacked += PlayerDied;
        Actions.OnPlayerDied += CancelInput;
    }

    private void OnDisable()
    {
        Actions.OnPlayerAttacked -= PlayerDied;
        Actions.OnPlayerDied -= CancelInput;
    }

    private void CancelInput()
    {
        Debug.Log("Dead");
        Time.timeScale = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SkeletonWeapon"))
        {
            SkeletonDamage();
        }

        if (collision.gameObject.CompareTag("BigSkeleton"))
        {
            BigSkeletonDamage();
        }

        if (collision.gameObject.CompareTag("ZombieHands"))
        {
            ZombieDamage();
        }

        if (collision.gameObject.CompareTag("MinotaurAxe"))
        {
            MinotaurDamage();
        }
    }

    private void SkeletonDamage()
    {
        currentHealth -= 5;

        healthBar.SetHealth(currentHealth);
        healthText.SetText($"{currentHealth}");

        if (currentHealth <= 0)
        {
            PlayerDied();
        }
    }

    private void BigSkeletonDamage()
    {
        currentHealth -= 10;

        healthBar.SetHealth(currentHealth);
        healthText.SetText($"{currentHealth}");

        if (currentHealth <= 0)
        {
            PlayerDied();
        }
    }

    private void ZombieDamage()
    {
        currentHealth -= 4;

        healthBar.SetHealth(currentHealth);
        healthText.SetText($"{currentHealth}");

        if (currentHealth <= 0)
        {
            PlayerDied();
        }
    }

    private void MinotaurDamage()
    {
        currentHealth -= 8;

        healthBar.SetHealth(currentHealth);
        healthText.SetText($"{ currentHealth}");

        if (currentHealth <= 0)
        {
            PlayerDied();
        }
    }
    private void PlayerDied()
    {
            currentHealth = 0;
            Actions.OnPlayerDied.Invoke();
            gameManager.GameOver();
            Debug.Log("Player Has Died");
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        healthBar.SetHealth(currentHealth);
        healthText.SetText($"{currentHealth}");
    }

   
}
