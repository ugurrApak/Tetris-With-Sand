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
        if (Input.GetMouseButtonDown(0))
        {
            CancelInvoke();
            block = new O_Block(Tilemap.Instance.Grid);
            InvokeRepeating("Move", .01f, .01f);
            if (percOBlock == null)
            {
                percOBlock = new Percolation(block.TilemapSprite);
                StartCoroutine(percOBlock.Wait());
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            CancelInvoke();
            block = new I_Block(Tilemap.Instance.Grid);
            InvokeRepeating("Move", .01f, .01f);
            if (percIBlock == null)
            {
                percIBlock = new Percolation(block.TilemapSprite);
                StartCoroutine(percIBlock.Wait());
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CancelInvoke();
            block = new J_Block(Tilemap.Instance.Grid);
            InvokeRepeating("Move", .01f, .01f);
            if (percJBlock == null)
            {
                percJBlock = new Percolation(block.TilemapSprite);
                StartCoroutine(percJBlock.Wait());
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CancelInvoke();
            block = new S_Block(Tilemap.Instance.Grid);
            InvokeRepeating("Move", .01f, .01f);
            if (percSBlock == null)
            {
                percSBlock = new Percolation(block.TilemapSprite);
                StartCoroutine(percSBlock.Wait());
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CancelInvoke();
            block = new T_Block(Tilemap.Instance.Grid);
            InvokeRepeating("Move", .01f, .01f);
            if (percTBlock == null)
            {
                percTBlock = new Percolation(block.TilemapSprite);
                StartCoroutine(percTBlock.Wait());
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CancelInvoke();
            block = new Z_Block(Tilemap.Instance.Grid);
            InvokeRepeating("Move", .01f, .01f);
            if (percZBlock == null)
            {
                percZBlock = new Percolation(block.TilemapSprite);
                StartCoroutine(percZBlock.Wait());
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.Instance.UpdateMenuState(MenuState.PAUSE);
        }
    }
    private void TestGame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CancelInvoke();
            block = new O_Block(Tilemap.Instance.Grid);
            InvokeRepeating("Move", .01f, .01f);
            if (percOBlock == null)
            {
                percOBlock = new Percolation(block.TilemapSprite);
                StartCoroutine(percOBlock.Wait());
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            CancelInvoke();
            block = new I_Block(Tilemap.Instance.Grid);
            InvokeRepeating("Move", .01f, .01f);
            if (percIBlock == null)
            {
                percIBlock = new Percolation(block.TilemapSprite);
                StartCoroutine(percIBlock.Wait());
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CancelInvoke();
            block = new J_Block(Tilemap.Instance.Grid);
            InvokeRepeating("Move", .01f, .01f);
            if (percJBlock == null)
            {
                percJBlock = new Percolation(block.TilemapSprite);
                StartCoroutine(percJBlock.Wait());
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CancelInvoke();
            block = new S_Block(Tilemap.Instance.Grid);
            InvokeRepeating("Move", .01f, .01f);
            if (percSBlock == null)
            {
                percSBlock = new Percolation(block.TilemapSprite);
                StartCoroutine(percSBlock.Wait());
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CancelInvoke();
            block = new T_Block(Tilemap.Instance.Grid);
            InvokeRepeating("Move", .01f, .01f);
            if (percTBlock == null)
            {
                percTBlock = new Percolation(block.TilemapSprite);
                StartCoroutine(percTBlock.Wait());
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CancelInvoke();
            block = new Z_Block(Tilemap.Instance.Grid);
            InvokeRepeating("Move", .01f, .01f);
            if (percZBlock == null)
            {
                percZBlock = new Percolation(block.TilemapSprite);
                StartCoroutine(percZBlock.Wait());
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.Instance.UpdateMenuState(MenuState.PAUSE);
        }
    }
    private void Move()
    {
        block.MoveBlock(Input.GetAxisRaw("Horizontal"));
    }
}