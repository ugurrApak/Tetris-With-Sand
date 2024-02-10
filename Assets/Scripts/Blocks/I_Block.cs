using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Block : Block
{
    private bool[,] blocks = new bool[2, 4] {
            {true, true, true, true },
            {false, false, false, false } };

    public Grid<IGridObject> Grid => grid;
    public I_Block(Grid<IGridObject> grid) : base(grid)
    {
        tilemapSprite = Cell.TilemapSprite.Ground;
        CreateBlock(blocks);
    }
}
