using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public AudioSource EnemyHitAud;
    public AudioClip Clip1;
    public AudioClip Clip2;
    public int currentHealth;
    public int maxHealth;

    KillCounter killCounterScript;

    void Start()
    {
        currentHealth = maxHealth;
        killCounterScript = GameObject.Find("KCO").GetComponent<KillCounter>();
    }

    public void SwordDamage()
    {
        currentHealth -= 1;
        EnemyHitAud.PlayOneShot(Clip1);
        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void DaggerDamage()
    {
        currentHealth -= 1;
        EnemyHitAud.PlayOneShot(Clip1);
        if (currentHealth <= 0)
        {
            EnemyDied();
        }
    }

    public void AxeDamage()
    {
        currentHealth -= 1;
        EnemyHitAud.PlayOneShot(Clip1);
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
        EnemyHitAud.PlayOneShot(Clip2);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
            killCounterScript.AddKill();
            EnemyHitAud.PlayOneShot(Clip2);
        }
    }
}
