using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class O_Block : Block
{
	private Cell.TilemapSprite tilemapSprite = Cell.TilemapSprite.Path;
	private bool[,] blocks = new bool[2, 4] { 
			{false, true, true, false },
			{false, true, true, false } };

public Grid<IGridObject> Grid => grid;
	public O_Block(Grid<IGridObject> grid) : base(grid)
	{
		CreateBlock(blocks,tilemapSprite);
    }
}
