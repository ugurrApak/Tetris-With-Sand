using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGridObject 
{
    void SetTilemapSprite(Cell.TilemapSprite tilemapSprite);
    void UpdateCellPos(Cell.TilemapSprite tilemapSprite);
    Cell.TilemapSprite GetTilemapSprite();
    public int X { get; }
    public int Y { get; }
}
