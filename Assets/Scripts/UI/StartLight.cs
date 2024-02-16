using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class StartLight : MonoBehaviour
{
    [SerializeField] Image[] startLights;
    private void Start()
    {
        StartGame();
    }
    public async void StartGame()
    {
        foreach (Image light in startLights)
        {
            light.gameObject.SetActive(true);
            SoundManager.Instance.PlaySound("start_beep");
            await UniTask.Delay(1000, true);
            light.gameObject.SetActive(false);
        }
        SoundManager.Instance.PlaySound("play_beep");
        gameObject.SetActive(false);
        SoundManager.Instance.PlayMusic("music_c");
        GameManager.Instance.UpdateGameState(GameState.INGAME);
    }
}
