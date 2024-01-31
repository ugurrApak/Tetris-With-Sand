using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Cell 
{
    public enum TilemapSprite
    {
        None,
        Ground,
        Path
    }
    private Grid<Cell> grid;
    private int x;
    private int y;
    private TilemapSprite tilemapSprite;

    public int X { get => x; private set => x = value; }
    public int Y { get => y; private set => y = value; }

    public Cell(Grid<Cell> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void SetTilemapSprite(TilemapSprite tilemapSprite)
    {
        this.tilemapSprite = tilemapSprite;
        grid.TriggerGridObjectChanged(x, y);
    }

    public TilemapSprite GetTilemapSprite() { return tilemapSprite; }

    public override string ToString()
    {
        return tilemapSprite.ToString();
    }
}
