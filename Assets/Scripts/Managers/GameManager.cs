using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private LevelManager[] levelManagers;

    private State currentState;
    private LevelManager currentLevel;
    private int currentLevelIndex;

    public GameObject player;
    public GameObject gamePauseMenu;
    public GameObject gameOverMenu;
    public GameObject gameEndMenu;
    public GameObject gameOverCamera;
    public GameObject mainCharacterCamera;
    public GameObject endgameUI;  // Reference to the endgame UI GameObject.
    public GameObject healthBar;
    public GameObject minotaurHealthBar;
    public GameObject reticalDot;
    public TextMeshProUGUI outOfDaggersText;
    public TextMeshProUGUI daggerText;
    public TextMeshProUGUI startLevelText;
    public TextMeshProUGUI levelGoalText;
    public TextMeshProUGUI healthText;
    //public TextMeshProUGUI bulletText;
    public TextMeshProUGUI timerText;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        if (levelManagers.Length > 0)
        {
            ChangeState(State.StartGame, levelManagers[currentLevelIndex]);
        }

    }

    public void ChangeState(State newState, LevelManager level)
    {
        currentState = newState;
        currentLevel = level;

        switch (currentState)
        {
            case State.StartGame:
                StartGame();
                break;
            case State.InitiateLevel:
                InitiateLevel();
                break;
            case State.RunLevel:
                RunLevel();
                break;
            case State.CompleteLevel:
                CompleteLevel();
                break;
            case State.Pause:
                Pause();
                break;
            case State.UnPause:
                UnPause();
                break;
            case State.GameOver:
                GameOver();
                break;
            case State.GameOverExit:
                GameOverExit();
                break;
            case State.GameEnd:
                GameEnd();
                break;
            case State.GameEndExit:
                GameEndExit();
                break;

        }
    }

    private void OnEnable()
    {
        Actions.OnPlayerDied += GameOver;

    }

    private void OnDisable()
    {
        Actions.OnPlayerDied -= GameOver;
    }

    private void StartGame()
    {
        Debug.Log("Start Game");
        ChangeState(State.InitiateLevel, currentLevel);
    }

    private void InitiateLevel()
    {
        Debug.Log("Start Level");
        ChangeState(State.RunLevel, currentLevel);
    }

    private void RunLevel()
    {
        Debug.Log("In Level");
    }

    public void CompleteLevel()
    {
        Debug.Log("End of Level");
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;  // Pause the game by setting the time scale to 0.
        player.gameObject.SetActive(false);
        gameOverCamera.gameObject.SetActive(true);
        mainCharacterCamera.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        daggerText.gameObject.SetActive(false);
        healthText.gameObject.SetActive(false);
        minotaurHealthBar.gameObject.SetActive(false);
        reticalDot.gameObject.SetActive(false);
        //bulletText.gameObject.SetActive(false);
        endgameUI.SetActive(true);   // Activate the endgame UI GameObject.
        healthBar.SetActive(false);
        gamePauseMenu = null;
        //ChangeState(State.InitiateLevel, levelManagers[++currentLevelIndex]);
    }

    public void Pause()
    {
        Debug.Log("Paused");
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        player.gameObject.SetActive(false);
        gameOverCamera.gameObject.SetActive(true);
        mainCharacterCamera.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        gamePauseMenu.SetActive(true);
        healthBar.SetActive(false);
        minotaurHealthBar.SetActive(false);
        reticalDot.gameObject.SetActive(false);
        daggerText.gameObject.SetActive(false);
        outOfDaggersText.gameObject.SetActive(false);
        startLevelText.gameObject.SetActive(false);
        levelGoalText.gameObject.SetActive(false);
        healthText.gameObject.SetActive(false);
        //bulletText.gameObject.SetActive(false);

    }

   
    public void UnPause()
    {
        Debug.Log("Back to Game");
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        player.gameObject.SetActive(true);
        gameOverCamera.gameObject.SetActive(false);
        mainCharacterCamera.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);
        gamePauseMenu.SetActive(false);
        healthBar.SetActive(true);
        minotaurHealthBar.SetActive(true);
        daggerText.gameObject.SetActive(true);
        healthText.gameObject.SetActive(true);
        //startLevelText.gameObject.SetActive(true);
        //bulletText.gameObject.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        player.gameObject.SetActive(true);
        gameOverCamera.gameObject.SetActive(false);
        mainCharacterCamera.gameObject.SetActive(true);
        healthBar.SetActive(true);
        timerText.gameObject.SetActive(true);
        daggerText.gameObject.SetActive(true);
        healthText.gameObject.SetActive(true);
        //bulletText.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        Debug.Log("You Lose, Game Over");
        ChangeState(State.GameOverExit, currentLevel);
    }

    private void GameOverExit()
    {
        Cursor.lockState = CursorLockMode.None;
        player.gameObject.SetActive(false);
        gameOverCamera.gameObject.SetActive(true);
        mainCharacterCamera.gameObject.SetActive(false);
        gameOverMenu.SetActive(true);
        timerText.gameObject.SetActive(false);
        daggerText.gameObject.SetActive(false);
        outOfDaggersText.gameObject.SetActive(false);
        healthText.gameObject.SetActive(false);
        reticalDot.gameObject.SetActive(false);
        //bulletText.gameObject.SetActive(false);
        healthBar.SetActive(false);
        minotaurHealthBar.SetActive(false);
        gamePauseMenu = null;
    }

    private void GameEnd()
    {
        ChangeState(State.GameEndExit, currentLevel);
        Debug.Log("Congrats! You Win!");
    }

    private void GameEndExit()
    {
        Cursor.lockState = CursorLockMode.None;
        gameEndMenu.SetActive(true);
    }

    public enum State
    {
        StartGame,
        InitiateLevel,
        RunLevel,
        CompleteLevel,
        Pause,
        UnPause,
        RestartLevel,
        GameOver,
        GameOverExit,
        GameEnd,
        GameEndExit
    }
}
