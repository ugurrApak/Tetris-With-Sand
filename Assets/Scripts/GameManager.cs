using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static Action<GameState> OnGameStateChanged;
    public GameState State;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(Instance);
        }
        State = GameState.MENU;
    }
    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.MENU:
                break;
            case GameState.START:
                HandleStart();
                break;
            case GameState.INGAME:
                break;
            case GameState.VICTORY:
                break;
            case GameState.LOSE:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState));
        }
        OnGameStateChanged?.Invoke(newState);
    }
    private void HandleStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
public enum GameState
{
    MENU,
    START,
    INGAME,
    VICTORY,
    LOSE
}
