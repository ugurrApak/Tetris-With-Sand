using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    private PercolationToptoBottom percToptoBottom;
    private void Start()
    {
        InvokeRepeating("Move",.01f,.01f);
        percToptoBottom = new PercolationToptoBottom();
        StartCoroutine(percToptoBottom.Wait());
    }
    private void Update()
    {
        if (GameManager.Instance.State == GameState.INGAME)
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
        }
        else
        {
            Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            BlockRandomizer.GetCurrentBlock().RotateBlock();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.Instance.UpdateMenuState(MenuState.PAUSE);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            BlockRandomizer.GetCurrentBlock().blockSpeed = .005f;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            BlockRandomizer.GetCurrentBlock().blockSpeed = .02f;
        }
    }
    private void Move()
    {
        if (BlockRandomizer.GetCurrentBlock() != null)
        {
            BlockRandomizer.GetCurrentBlock().MoveBlock(Input.GetAxisRaw("Horizontal"));
        }
    }
}
