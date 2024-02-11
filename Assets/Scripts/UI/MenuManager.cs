using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public static Action<MenuState> OnMenuStateChanged;
    public MenuState State;
    [SerializeField] GameObject startLightPanel;
    [SerializeField] GameObject pausePanel;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }
    public void UpdateMenuState(MenuState state)
    {
        State = state;
        switch (state)
        {
            case MenuState.MAIN_MENU:
                break;
            case MenuState.SETTINGS:
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
    private void GameManagerOnGameStateChanged(GameState obj)
    {
        startLightPanel.SetActive(obj == GameState.START);
    }
    private void HandlePause()
    {
        GameManager.Instance.UpdateGameState(GameState.MENU);
        pausePanel.SetActive(true);
    }
    private void HandlePlay()
    {
        GameManager.Instance.UpdateGameState(GameState.INGAME);
    }
}
public enum MenuState
{
    MAIN_MENU,
    SETTINGS,
    PAUSE,
    WIN,
    LOSE,
    PLAY
}
