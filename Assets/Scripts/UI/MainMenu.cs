using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void HowToPlay()
    {
        MenuManager.Instance.UpdateMenuState(MenuState.HELP);
        SoundManager.Instance.PlaySound("menu_select");
    }
    public void Back()
    {
        MenuManager.Instance.UpdateMenuState(MenuState.START_GAME);
        SoundManager.Instance.PlaySound("menu_select");
        gameObject.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        MenuManager.Instance.UpdateMenuState(MenuState.PLAY_GAME);
        SoundManager.Instance.PlaySound("menu_select");
        gameObject.SetActive(false);
    }
}
