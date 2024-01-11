using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinotaurHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private MinotaurHealthUi minotaurHealthBar;

    public GameObject bossDeathCutScene;

    void Start()
    {
        currentHealth = maxHealth;
        minotaurHealthBar.SetMaxHealth(maxHealth);
    }

    public void SwordDamage()
    {
        animator.SetBool("isHit", true);
        Invoke("CancelAnimation", 0.2f);
        currentHealth -= 4;
        minotaurHealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void DaggerDamage()
    {
       
        animator.SetBool("isHit", true);
        Invoke("CancelAnimation", 0.2f);
        currentHealth -= 5;

        minotaurHealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void AxeDamage()
    {
        animator.SetBool("isHit", true);
        Invoke("CancelAnimation", 0.2f);
        currentHealth -= 6;

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
            bossDeathCutScene.SetActive(true);
            Invoke("DestroyMinotaur", 2.08f);
        }
    }

    void DestroyMinotaur()
    {
        Destroy(gameObject);
    }

    void CancelAnimation()
    {
        animator.SetBool("isHit", false);
    }
}
