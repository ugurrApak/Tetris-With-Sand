using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(0);
            MenuManager.Instance.UpdateMenuState(MenuState.START_GAME);
        } 
    }
}
