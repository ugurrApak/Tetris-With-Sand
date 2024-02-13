using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Block : Block
{
    private bool[,] blocksT = new bool[4, 4] {
            {false, false, false, false },
            {true, true, true, false },
            {false, true, false, false },
            {false, false, false, false },};

    public Grid<IGridObject> Grid => grid;
    public T_Block(Grid<IGridObject> grid) : base(grid)
    {
        tilemapSprite = Cell.TilemapSprite.T;
        blocks = blocksT;
        CreateBlock(blocks);
    }
}
