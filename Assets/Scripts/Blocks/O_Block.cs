using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class O_Block
{
    private int[,] blockArray;
	private Grid<Block> grid;
	public O_Block()
	{
		blockArray = new int[2,4] { { 0, 1, 1, 0}, {0, 1, 1, 0 } };
		grid = new Grid<Block>(4,2,3, new Vector3(Tilemap.Instance.Width/2, Tilemap.Instance.Height),(Grid<Block> g, int x, int y) => new Block(g,x,y,Cell.TilemapSprite.Path));
	}

}
