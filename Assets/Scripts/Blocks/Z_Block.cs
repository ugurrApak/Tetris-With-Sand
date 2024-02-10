using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_Block : Block
{
    private bool[,] blocks = new bool[2, 4] {
            {false, true, true, false },
            {true, true, false, false } };

    public Grid<IGridObject> Grid => grid;
    public Z_Block(Grid<IGridObject> grid) : base(grid)
    {
        tilemapSprite = Cell.TilemapSprite.Z;
        CreateBlock(blocks);
    }
}
