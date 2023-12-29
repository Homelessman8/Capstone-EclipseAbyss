using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject endgameUI;  // Reference to the endgame UI GameObject.

    // This method is called when a Collider2D enters the trigger zone.
    private void OnTriggerEnter(Collider collision)
    {
        // Check if the entering object has the "Player" tag.
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;      // Pause the game by setting the time scale to 0.
            endgameUI.SetActive(true); // Activate the endgame UI GameObject.
        }
    }
}
