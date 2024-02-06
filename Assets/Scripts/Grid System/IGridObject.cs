using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGridObject 
{
    void SetTilemapSprite(Cell.TilemapSprite tilemapSprite);
    void UpdateCellPos(Cell.TilemapSprite tilemapSprite);
    Cell.TilemapSprite GetTilemapSprite();
    void StartCoroutine(Cell.TilemapSprite tilemapSprite);
    public int X { get; }
    public int Y { get; }
    public bool CanMove { get; }
}
