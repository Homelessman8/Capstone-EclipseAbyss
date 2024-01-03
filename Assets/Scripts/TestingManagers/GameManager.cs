using System.Collections;
using System.Collections.Generic;
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
            ChangeState(State.Level1, levelManagers[currentLevelIndex]);
        }

    }

    public void ChangeState(State newState, LevelManager level)
    {
        currentState = newState;
        currentLevel = level;

        switch (currentState)
        {
            case State.Level1:
                Level1();
                break;
            case State.Level2:
                Level2();
                break;
            case State.Level3:
                Level3();
                break;
            case State.Level4:
                Level4();
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

    private void Level1()
    {
        Debug.Log("Starting Level 1");
        ChangeState(State.Level2, currentLevel);
    }

    private void Level2()
    {
        Debug.Log("Starting Level 2");
        ChangeState(State.Level3, currentLevel);
    }

    private void Level3()
    {
        Debug.Log("Starting Level 3");
        ChangeState(State.Level4, currentLevel);
    }

    private void Level4()
    {
        Debug.Log("Starting Level 4");
        ChangeState(State.GameEnd, currentLevel);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Debug.Log("You Lose, Game Over");
        ChangeState(State.GameOverExit, currentLevel);
    }

    private void GameOverExit()
    {
        Cursor.lockState = CursorLockMode.None;
        //gameOverMenu.SetActive(true);
    }

    private void GameEnd()
    {
        ChangeState(State.GameEndExit, currentLevel);
        Debug.Log("Congrats! You Win!");
    }

    private void GameEndExit()
    {
        Cursor.lockState = CursorLockMode.None;
        //gameEndMenu.SetActive(true);
    }

    private void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        //gamepauseMenu.SetActive(true);
    }

    public enum State
    {
        Level1,
        Level2,
        Level3,
        Level4,
        Pause,
        RestartLevel,
        GameOver,
        GameOverExit,
        GameEnd,
        GameEndExit
    }
}
