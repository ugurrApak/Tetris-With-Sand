using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRandomizer : MonoBehaviour
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
            if (block == null)
            {
                CreateRandomBlock();
            }
            else if (!block.CanMove)
            {
                CreateRandomBlock();
            }
        }
    }
    public void CreateRandomBlock()
    {
        int nextBlock = Random.Range(0, 6);
        switch (nextBlock)
        {
            case 0:
                CreateO_Block();
                break;
            case 1:
                CreateI_Block();
                break;
            case 2:
                CreateJ_Block();
                break;
            case 3:
                CreateS_Block();
                break;
            case 4:
                CreateT_Block();
                break;
            case 5:
                CreateZ_Block();
                break;
            default:
                break;
        }
    }
    private void CreateZ_Block()
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
    private void CreateT_Block()
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
    private void CreateS_Block()
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
    private void CreateJ_Block()
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

    private void CreateI_Block()
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

    private void CreateO_Block()
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
    private void Move()
    {
        block.MoveBlock(Input.GetAxisRaw("Horizontal"));
    }
}
