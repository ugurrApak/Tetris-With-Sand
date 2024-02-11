using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public static Action<MenuState> OnMenuStateChanged;
    public MenuState State;
    [SerializeField] GameObject startLightPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject helpPanel;
    [SerializeField] GameObject startGamePanel;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(this);
            DontDestroyOnLoad(transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        UpdateMenuState(MenuState.START_GAME);
    }
    public void UpdateMenuState(MenuState state)
    {
        State = state;
        switch (state)
        {
            case MenuState.START_GAME:
                HandleStartGame();
                break;
            case MenuState.MAIN_MENU:
                HandleMainMenu();
                break;
            case MenuState.HELP:
                HandleHelp();
                break;
            case MenuState.SETTINGS:
                break;
            case MenuState.PLAY_GAME:
                HandlePlayGame();
                break;
            case MenuState.PAUSE:
                HandlePause();
                break;
            case MenuState.WIN:
                break;
            case MenuState.LOSE:
                break;
            case MenuState.PLAY:
                HandlePlay();
                break;
            default:
                break;
        }
    }
    private void HandleStartGame()
    {
        if (GameManager.Instance.State != GameState.MENU)
        {
            GameManager.Instance.UpdateGameState(GameState.MENU);
        }
        startGamePanel.SetActive(true);
    }
    private void HandleMainMenu()
    {
        if (GameManager.Instance.State != GameState.MENU)
        {
            GameManager.Instance.UpdateGameState(GameState.MENU);
        }
        mainMenuPanel.SetActive(true);
    }
    private void HandleHelp()
    {
        if (GameManager.Instance.State != GameState.MENU)
        {
            GameManager.Instance.UpdateGameState(GameState.MENU);
        }
        helpPanel.SetActive(true);
    }
    private async void HandlePlayGame()
    {
        GameManager.Instance.UpdateGameState(GameState.START);
        await Task.Delay(100);
        startLightPanel.SetActive(true);
    }
    private void HandlePause()
    {
        if (GameManager.Instance.State != GameState.MENU)
        {
            GameManager.Instance.UpdateGameState(GameState.MENU);
        }
        pausePanel.SetActive(true);
    }
    private void HandlePlay()
    {
        GameManager.Instance.UpdateGameState(GameState.INGAME);
    }
}
public enum MenuState
{
    START_GAME,
    MAIN_MENU,
    HELP,
    SETTINGS,
    PLAY_GAME,
    PAUSE,
    WIN,
    LOSE,
    PLAY
}
