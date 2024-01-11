using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthReload : MonoBehaviour
{
    PlayerHealth playerHealth;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
            Debug.Log("+10");
            playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.Heal(30);
            Destroy(gameObject);
            
                
            
            if (playerHealth.currentHealth > 100)
            {
                playerHealth = other.GetComponent<PlayerHealth>();
                playerHealth.currentHealth = 100;
                playerHealth.healthText.SetText($"{playerHealth.maxHealth}");
                Debug.Log("Full Health");
            }
        }
      
    }
}
