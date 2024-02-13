using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class O_Block : Block
{
	private bool[,] blocksO = new bool[4, 4] { 
			{false, false, false, false },
			{false, true, true, false },
			{false, true, true, false },
			{false, false, false, false } };

	public Grid<IGridObject> Grid => grid;
	public O_Block(Grid<IGridObject> grid) : base(grid)
	{
		tilemapSprite = Cell.TilemapSprite.O;
		blocks = blocksO;
		CreateBlock(blocks);
    }
}
