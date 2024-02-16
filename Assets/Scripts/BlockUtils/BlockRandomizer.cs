using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BlockRandomizer : MonoBehaviour
{
    private static Block block;
    [SerializeField] private TilemapVisual tilemapVisual;
    [SerializeField] private NextBlock nextBlockScript;
    private Percolation percIBlock;
    private Percolation percOBlock;
    private Percolation percJBlock;
    private Percolation percSBlock;
    private Percolation percTBlock;
    private Percolation percZBlock;
    int nextBlockNumber;
    private void Start()
    {
        Tilemap.Instance.SetTilemapVisual(tilemapVisual);
        block = null;
        nextBlockNumber = Random.Range(0,5);
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
        int currentBlock = nextBlockNumber;
        nextBlockNumber = Random.Range(0, 5);
        nextBlockScript.UpdateNextBlockSprite(nextBlockNumber);
        switch (currentBlock)
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
        block = new Z_Block(Tilemap.Instance.Grid);
        if (percZBlock == null)
        {
            percZBlock = new Percolation(block.TilemapSprite);
            StartCoroutine(percZBlock.Wait());
        }
    }
    private void CreateT_Block()
    {
        block = new T_Block(Tilemap.Instance.Grid);
        if (percTBlock == null)
        {
            percTBlock = new Percolation(block.TilemapSprite);
            StartCoroutine(percTBlock.Wait());
        }
    }
    private void CreateS_Block()
    {
        block = new S_Block(Tilemap.Instance.Grid);
        if (percSBlock == null)
        {
            percSBlock = new Percolation(block.TilemapSprite);
            StartCoroutine(percSBlock.Wait());
        }
    }
    private void CreateJ_Block()
    {
        block = new J_Block(Tilemap.Instance.Grid);
        if (percJBlock == null)
        {
            percJBlock = new Percolation(block.TilemapSprite);
            StartCoroutine(percJBlock.Wait());
        }
    }

    private void CreateI_Block()
    {
        block = new I_Block(Tilemap.Instance.Grid);
        if (percIBlock == null)
        {
            percIBlock = new Percolation(block.TilemapSprite);
            StartCoroutine(percIBlock.Wait());
        }
    }

    private void CreateO_Block()
    {
        block = new O_Block(Tilemap.Instance.Grid);
        if (percOBlock == null)
        {
            percOBlock = new Percolation(block.TilemapSprite);
            StartCoroutine(percOBlock.Wait());
        }
    }
    public static Block GetCurrentBlock()
    {
        return block;
    }
}
