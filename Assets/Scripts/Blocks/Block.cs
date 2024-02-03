using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : IGridObject
{
    private int x;
    private int y;
    private int width;
    private int height;
    Cell.TilemapSprite sprite;
    Grid<Block> grid;
    public int Width => width;
    public int Height => height;
    public Block(Grid<Block> grid, int x, int y, Cell.TilemapSprite sprite)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        this.sprite = sprite;
    }

    public void SetTilemapSprite(Cell.TilemapSprite tilemapSprite)
    {
        this.sprite = tilemapSprite;
        grid.TriggerGridObjectChanged(x,y);
    }

    public void UpdateCellPos(Cell.TilemapSprite tilemapSprite)
    {
        throw new System.NotImplementedException();
    }

    public Cell.TilemapSprite GetTilemapSprite()
    {
        return sprite;
    }
}
