using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Block : Block
{
    private bool[,] blocksS = new bool[4, 4] {
            {false, false, false, false },
            {true, true, false, false },
            {false, true, true, false },
            {false, false, false, false },};

    public Grid<IGridObject> Grid => grid;
    public S_Block(Grid<IGridObject> grid) : base(grid)
    {
        tilemapSprite = Cell.TilemapSprite.S;
        blocks = blocksS;
        CreateBlock(blocks);
    }
}
