using System;
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
                HandleInGame();
                break;
            case GameState.VICTORY:
                break;
            case GameState.LOSE:
                HandleLose();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState));
        }
        OnGameStateChanged?.Invoke(newState);
    }
    private void HandleInGame()
    {
        SoundManager.Instance.PlayMusic();
    }
    private void HandleStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void HandleLose()
    {
        SoundManager.Instance.PlaySound("game_over");
        MenuManager.Instance.UpdateMenuState(MenuState.LOSE);
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
