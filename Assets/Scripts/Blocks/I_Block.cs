using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Block : Block
{
    private bool[,] blocksI = new bool[4, 4] {
            {false, false, false, false },
            {true, true, true, true },
            {false, false, false, false },
            {false, false, false, false } };

    public Grid<IGridObject> Grid => grid;
    public I_Block(Grid<IGridObject> grid) : base(grid)
    {
        tilemapSprite = Cell.TilemapSprite.I;
        blocks = blocksI;
        CreateBlock(blocks);
    }
}
