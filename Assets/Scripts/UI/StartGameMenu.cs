using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            MenuManager.Instance.UpdateMenuState(MenuState.MAIN_MENU);
            SoundManager.Instance.PlaySound("menu_select");
            gameObject.SetActive(false);
        }
    }
    public void StartGame()
    {
        MenuManager.Instance.UpdateMenuState(MenuState.MAIN_MENU);
        SoundManager.Instance.PlaySound("menu_select");
        gameObject.SetActive(false);
    }
}
