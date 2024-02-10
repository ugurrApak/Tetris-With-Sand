using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Block : Block
{
    private bool[,] blocks = new bool[2, 4] {
            {true, true, true, false },
            {true, false, false, false } };

    public Grid<IGridObject> Grid => grid;
    public J_Block(Grid<IGridObject> grid) : base(grid)
    {
        tilemapSprite = Cell.TilemapSprite.J;
        CreateBlock(blocks);
    }
}
