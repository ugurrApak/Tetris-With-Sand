using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Test : MonoBehaviour
{
    private Block block;
    [SerializeField] private TilemapVisual tilemapVisual;
    private Percolation percIBlock;
    private Percolation percOBlock;
    private Percolation percJBlock;
    private Percolation percSBlock;
    private Percolation percTBlock;
    private Percolation percZBlock;
    private PercolationToptoBottom percToptoBottom;

    private void Start()
    {
        Tilemap.Instance.SetTilemapVisual(tilemapVisual);

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
        TestGame();
    }
    private void TestGame()
    {

    }
    private void Move()
    {
        block.MoveBlock(Input.GetAxisRaw("Horizontal"));
    }
}