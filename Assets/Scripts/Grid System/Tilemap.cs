using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tilemap
{
	public Grid<Cell> grid;
	public Tilemap(int width, int height, float cellSize, Vector3 originPosition)
	{
		grid = new Grid<Cell>(width, height, cellSize, originPosition, (Grid<Cell> g, int x, int y) => new Cell(g, x, y));
	}

	public void SetTilemapSprite(Vector3 worldPosition, Cell.TilemapSprite tilemapSprite)
	{
		Cell tilemapObject = grid.GetGridObject(worldPosition);
		tilemapObject.SetTilemapSprite(tilemapSprite);
	}

	public void SetTilemapSprite(int x, int y, Cell.TilemapSprite tilemapSprite)
	{
        Cell tilemapObject = grid.GetGridObject(x,y);
        tilemapObject.SetTilemapSprite(tilemapSprite);
    }

    public void SetTilemapVisual(TilemapVisual tilemapVisual)
    {
        tilemapVisual.SetGrid(this, grid);
    }

	public Cell GetTilemapObject(int x, int y)
	{
		Cell tilemapObject = grid.GetGridObject(x, y);
		return tilemapObject;
	}

	public Cell GetTilemapObject(Vector3 objectPos)
	{
		Cell tilemapObject = grid.GetGridObject(objectPos);
		return tilemapObject;
    }

}
