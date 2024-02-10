using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Block : Block
{
    private bool[,] blocks = new bool[2, 4] {
            {true, true, true, false },
            {false, true, false, false } };

    public Grid<IGridObject> Grid => grid;
    public T_Block(Grid<IGridObject> grid) : base(grid)
    {
        tilemapSprite = Cell.TilemapSprite.T;
        CreateBlock(blocks);
    }
}
