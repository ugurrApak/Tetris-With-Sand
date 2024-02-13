using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_Block : Block
{
    private bool[,] blocksZ = new bool[4, 4] {
            {false, false, false, false },
            {false, true, true, false },
            {true, true, false, false },
            {false, false, false, false }};

    public Grid<IGridObject> Grid => grid;
    public Z_Block(Grid<IGridObject> grid) : base(grid)
    {
        tilemapSprite = Cell.TilemapSprite.Z;
        blocks = blocksZ;
        CreateBlock(blocks);
    }
}
