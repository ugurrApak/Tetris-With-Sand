using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public void Ok()
    {
        gameObject.SetActive(false);
        SoundManager.Instance.PlaySound("menu_select");
        MenuManager.Instance.UpdateMenuState(MenuState.MAIN_MENU);
    }
}
