using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndgameMenu : MonoBehaviour
{
    public GameObject endgameUI;  // Reference to the endgame UI GameObject.


    void Update()
    {
        // has player reach the end
        //endgameUI.SetActive(true);
        //Time.timeScale = 0f;
    }
    
    // Method to load the second level.
    public void LevelTwo()
    {
        Time.timeScale = 1f;  // Resume normal game time scale.
        SceneManager.LoadScene("DDFloor2"); // Load the "DDFloor2" scene.

        // Optionally, you can hide the endgame UI when transitioning to the next level.
        //endgameUI.SetActive(false);
    }

    // Method to load the main menu.
    public void LoadMenu()
    {
        Time.timeScale = 1f; // Resume normal game time scale.
        SceneManager.LoadScene("MenuDD"); // Load the "MenuDD" scene.
    }
}