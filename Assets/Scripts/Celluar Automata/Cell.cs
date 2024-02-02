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

    public void UpdateCellPos(TilemapSprite _tilemapSprite)
    {
        Vector3Int xyPosDown = new Vector3Int(x, y - 1, 0);
        Vector3Int xyPosDownLeft = new Vector3Int(x - 1, y - 1, 0);
        Vector3Int xyPosDownRight = new Vector3Int(x + 1, y - 1, 0);
        if (xyPosDown.y < 0)
        {
            return;
        }
        if (Tilemap.Instance.GetTilemapObject(xyPosDown.x, xyPosDown.y).GetTilemapSprite() == TilemapSprite.None)
        {
            Vector3Int cellPos = new Vector3Int(x, y);
            Tilemap.Instance.SetTilemapSprite(cellPos.x, cellPos.y, TilemapSprite.None);
            Tilemap.Instance.SetTilemapSprite(xyPosDown.x, xyPosDown.y, _tilemapSprite);
        }
        else if (xyPosDownLeft.x >= 0 && Tilemap.Instance.GetTilemapObject(xyPosDownLeft.x, xyPosDownLeft.y).GetTilemapSprite() == TilemapSprite.None)
        {
            Vector3Int cellPos = new Vector3Int(x, y);
            Tilemap.Instance.SetTilemapSprite(cellPos.x, cellPos.y, TilemapSprite.None);
            Tilemap.Instance.SetTilemapSprite(xyPosDownLeft.x, xyPosDownLeft.y, _tilemapSprite);
        }
        else if (xyPosDownRight.x <= 9 && Tilemap.Instance.GetTilemapObject(xyPosDownRight.x, xyPosDownRight.y).GetTilemapSprite() == TilemapSprite.None)
        {
            Vector3Int cellPos = new Vector3Int(x, y);
            Tilemap.Instance.SetTilemapSprite(cellPos.x, cellPos.y, TilemapSprite.None);
            Tilemap.Instance.SetTilemapSprite(xyPosDownRight.x, xyPosDownRight.y, _tilemapSprite);
        }
        else return;
    }
    public override string ToString()
    {
        return tilemapSprite.ToString();
    }
}
