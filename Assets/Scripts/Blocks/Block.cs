using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block
{
    private int cellCount;
    protected Grid<IGridObject> grid;
    private int startPosX;
    private int startPosY;
    private int endPosX;
    private int endPosY;
    protected Vector2Int[,] blockArray;
    public Block(Grid<IGridObject> grid)
    {
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

    public void UpdateCellPos(Cell.TilemapSprite tilemapSprite)
    {
        for (int i = 0; i < blockArray.GetLength(0); i++)
        {
            for (int j = 0; j < blockArray.GetLength(1); j++)
            {
                int x = blockArray[i, j].x;
                int y = blockArray[i, j].y;
                if (blockArray[i,j] != Vector2Int.zero)
                {
                    if (y <= 0)
                    {
                        return;
                    }
                    grid.GetGridObject(x, y).SetTilemapSprite(Cell.TilemapSprite.None);
                    grid.GetGridObject(x, y - 1).SetTilemapSprite(tilemapSprite);
                    blockArray[i, j] = new Vector2Int(x, y - 1);
                }
            }
        }
    }
    public void CreateBlock(bool[,] blocks, Cell.TilemapSprite tilemapSprite)
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
}
