using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Block : Block
{
    private bool[,] blocks = new bool[2, 4] {
            {true, true, false, false },
            {false, true, true, false } };

    public Grid<IGridObject> Grid => grid;
    public S_Block(Grid<IGridObject> grid) : base(grid)
    {
        tilemapSprite = Cell.TilemapSprite.Path;
        CreateBlock(blocks);
    }
}
