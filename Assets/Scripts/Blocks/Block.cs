using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public abstract class Block
{
    protected Cell.TilemapSprite tilemapSprite;
    private int cellCount;
    protected Grid<IGridObject> grid;
    private int startPosX;
    private int startPosY;
    private int endPosX;
    private int endPosY;
    private bool canMove;
    protected Vector2Int[,] blockArray;
    
    public Cell.TilemapSprite TilemapSprite { get => tilemapSprite; private set => tilemapSprite = value; }
    public Block(Grid<IGridObject> grid)
    {
        canMove = true;
        StartCoroutine();
        this.grid = grid;
    }
    
    public void SetTilemapSprite(Cell.TilemapSprite tilemapSprite, int x , int y, int rowBlockCounter)
    {
        startPosX = ((grid.GetWidth() - (4 * cellCount)) / 2) + ((x - 1) * cellCount) - 1;
        endPosX = startPosX + cellCount * rowBlockCounter;
        startPosY = grid.GetHeight() - (cellCount * 2) + ((y - 1) * cellCount) - 1;
        endPosY = startPosY + cellCount;
        for (int i = startPosY; i < endPosY; i++)
        {
            for (int j = startPosX; j < endPosX; j++)
            {
                grid.GetGridObject(j, i).SetTilemapSprite(tilemapSprite);
                blockArray[((y - 1) * cellCount) + i - startPosY, ((x - 1) * cellCount) + j - startPosX] = new Vector2Int(j, i);
            }
        }
    }
    public void StartCoroutine()
    {
        MonoBehaviour mb = GameObject.FindObjectOfType<MonoBehaviour>();
        if (mb != null)
        {
            mb.StartCoroutine(WaitForCellMove());
        }
        else
        {
            Debug.Log("Object not found.");
        }
    }
    public void UpdateCellPos()
    {
        for (int i = 0; i < blockArray.GetLength(0); i++)
        {
            for (int j = 0; j < blockArray.GetLength(1); j++)
            {
                int x = blockArray[i, j].x;
                int y = blockArray[i, j].y;
                if (blockArray[i,j] != Vector2Int.zero)
                {
                    if (y <= 0 || grid.GetGridObject(x, y - 1).GetTilemapSprite() != Cell.TilemapSprite.None)
                    {
                        for (int k = 0; k < blockArray.GetLength(0); k++)
                        {
                            for (int l = 0; l < blockArray.GetLength(1); l++)
                            {
                                if (blockArray[k, l] != Vector2Int.zero)
                                {
                                    grid.GetGridObject(blockArray[k, l].x, blockArray[k, l].y).StartCoroutine(tilemapSprite);
                                    canMove = false;
                                }
                            }
                        }
                        return;
                    }
                    grid.GetGridObject(x, y).SetTilemapSprite(Cell.TilemapSprite.None);
                    grid.GetGridObject(x, y - 1).SetTilemapSprite(tilemapSprite);
                    blockArray[i, j] = new Vector2Int(x, y - 1);
                }
            }
        }
    }
    public void CreateBlock(bool[,] blocks)
    {
        cellCount = Tilemap.Instance.Height / 20;
        int rowBlockCounter = 0;
        int firstRowBlock = 0;
        blockArray = new Vector2Int[2 * cellCount, 4 * cellCount];
        for (int i = 0; i < blocks.GetLength(0); i++)
        {
            for (int j = 0; j < blocks.GetLength(1); j++)
            {
                if (blocks[i, j])
                {
                    if (rowBlockCounter == 0)
                    {
                        firstRowBlock = j;
                    }
                    rowBlockCounter++;
                }
            }
            SetTilemapSprite(tilemapSprite, firstRowBlock + 1, i + 1, rowBlockCounter);
            rowBlockCounter = 0;
        }
    }
    public void MoveBlock(float horizontalInput)
    {
        
        if (horizontalInput > 0 && canMove)
        {
            for (int i = 0; i < blockArray.GetLength(0); i++)
            {
                for (int j = blockArray.GetLength(1) -1; j > 0; j--)
                {
                    int x = blockArray[i, j].x;
                    int y = blockArray[i, j].y;
                    if (blockArray[i, j] != Vector2Int.zero)
                    {
                        if (y <= 0 || x + horizontalInput >= Tilemap.Instance.Width)
                        {
                            return;
                        }
                        grid.GetGridObject(x, y).SetTilemapSprite(Cell.TilemapSprite.None);
                        grid.GetGridObject(x + (int)horizontalInput, y).SetTilemapSprite(tilemapSprite);
                        blockArray[i, j] = new Vector2Int(x + (int)horizontalInput, y);
                    }
                }
            }
        }
        else if(canMove)
        {
            for (int i = 0; i < blockArray.GetLength(0); i++)
            {
                for (int j = 0; j < blockArray.GetLength(1); j++)
                {
                    int x = blockArray[i, j].x;
                    int y = blockArray[i, j].y;
                    if (blockArray[i, j] != Vector2Int.zero)
                    {
                        if (y <= 0 || x + horizontalInput <= 0)
                        {
                            return;
                        }
                        grid.GetGridObject(x, y).SetTilemapSprite(Cell.TilemapSprite.None);
                        grid.GetGridObject(x + (int)horizontalInput, y).SetTilemapSprite(tilemapSprite);
                        blockArray[i, j] = new Vector2Int(x + (int)horizontalInput, y);
                    }
                }
            }
        }
    }
    IEnumerator WaitForCellMove()
    {
        while (canMove)
        {
            if (tilemapSprite != Cell.TilemapSprite.None)
            {
                UpdateCellPos();
            }
            yield return new WaitForSeconds(.02f);
        }
    }
}
