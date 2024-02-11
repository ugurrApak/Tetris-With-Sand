using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class StartLight : MonoBehaviour
{
    [SerializeField] Image[] startLights;
    private void Awake()
    {
        StartGame();
    }
    private async void StartGame()
    {
        foreach (Image light in startLights)
        {
            light.gameObject.SetActive(true);
            SoundManager.Instance.PlaySound("start_beep");
            await Task.Delay(1000);
            light.gameObject.SetActive(false);
        }
        SoundManager.Instance.PlaySound("play_beep");
        gameObject.SetActive(false);
        GameManager.Instance.UpdateGameState(GameState.INGAME);
    }
}
