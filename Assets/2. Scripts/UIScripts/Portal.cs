using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameManager gameManager;

    // This method is called when a Collider2D enters the trigger zone.
    private void OnTriggerEnter(Collider collision)
    {
        // Check if the entering object has the "Player" tag.
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.CompleteLevel();
        }
    }
}
