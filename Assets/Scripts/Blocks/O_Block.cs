using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class O_Block : Block
{
	private float cellSizeMultiplier;
	private Vector3 originPosition;
	private Cell.TilemapSprite tilemapSprite = Cell.TilemapSprite.Path;
	private bool[,] blocks = new bool[2, 4] { 
			{false, true, true, false },
			{false, true, true, false } };

public Grid<IGridObject> Grid => grid;
	public O_Block(Grid<IGridObject> grid) : base(grid)
	{
		CreateBlock(blocks,tilemapSprite);
    }
	//  public void SetTilemapSprite(Cell.TilemapSprite tilemapSprite)
	//  {
	//for (int i = 0; i < blocks.GetLength(0); i++)
	//{
	//	for (int j = 0; j < blocks.GetLength(1); j++)
	//	{
	//		if (blocks[i, j] != null)
	//		{
	//			blocks[i, j].SetTilemapSprite(tilemapSprite,j + 1,i + 1);
	//              }
	//	}
	//}
	//  }
	//public void UpdateCellPos(Cell.TilemapSprite tilemapSprite)
	//{
	//	for (int i = 0; i < blocks.GetLength(0); i++)
	//	{
	//		for (int j = 0; j < blocks.GetLength(1); j++)
	//		{
	//			if (blocks[i, j] != null)
	//			{
	//				blocks[i, j].UpdateCellPos(tilemapSprite);
	//			}
	//		}
	//	}
	//}
}
