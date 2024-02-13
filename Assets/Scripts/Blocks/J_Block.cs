using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Block : Block
{
    private bool[,] blocksJ = new bool[4, 4] {
            {false, false, false, false },
            {true, true, true, false },
            {true, false, false, false },
            {false, false, false, false } };

    public Grid<IGridObject> Grid => grid;
    public J_Block(Grid<IGridObject> grid) : base(grid)
    {
        tilemapSprite = Cell.TilemapSprite.J;
        blocks = blocksJ;
        CreateBlock(blocks);
    }
}
