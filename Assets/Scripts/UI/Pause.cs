using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.Instance.UpdateMenuState(MenuState.PLAY);
            SoundManager.Instance.PlaySound("menu_select");
            gameObject.SetActive(false);
        }
    }
}
