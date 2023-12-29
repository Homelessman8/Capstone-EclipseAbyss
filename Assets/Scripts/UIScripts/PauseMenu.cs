using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;  // Indicates whether the game is currently paused.
    public Button yourButton;                // Reference to a button (not used in the provided script).

    public GameObject pauseMenuUI;          // Reference to the pause menu UI GameObject.

    // Update is called once per frame
    void Update()
    {
        // Check if the 'Escape' key is pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume(); // If the game is paused, resume it.
            }
            else
            {
                Pause(); // If the game is not paused, pause it.
            }
        }
    }

    // Method to resume the game.
    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide the pause menu UI.
        Time.timeScale = 1f;         // Set the time scale to 1 to resume normal gameplay speed.
        GameIsPause = false;          // Update the pause state.
    }

    // Method to pause the game.
    public void Pause()
    {
        pauseMenuUI.SetActive(true);  // Show the pause menu UI.
        Time.timeScale = 0f;         // Set the time scale to 0 to pause the game.
        GameIsPause = true;           // Update the pause state.
    }

    // Method to load the main menu.
    public void LoadMenu()
    {
        Time.timeScale = 1f;               // Resume normal time scale.
        SceneManager.LoadScene("MenuDD"); // Load the "MenuDD" scene.
    }
}
