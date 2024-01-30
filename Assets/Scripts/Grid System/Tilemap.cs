using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tilemap
{
	private Grid<TilemapObject> grid;
	public Tilemap(int width, int height, float cellSize, Vector3 originPosition)
	{
		grid = new Grid<TilemapObject>(width, height, cellSize, originPosition, (Grid<TilemapObject> g, int x, int y) => new TilemapObject(g, x, y));
	}

	public void SetTilemapSprite(Vector3 worldPosition, TilemapObject.TilemapSprite tilemapSprite)
	{
		TilemapObject tilemapObject = grid.GetGridObject(worldPosition);
		if (tilemapObject != null)
		{
			tilemapObject.SetTilemapSprite(tilemapSprite);
		}
	}

	public void SetTilemapSprite(int x, int y, TilemapObject.TilemapSprite tilemapSprite)
	{
        TilemapObject tilemapObject = grid.GetGridObject(x,y);
        if (tilemapObject != null)
        {
            tilemapObject.SetTilemapSprite(tilemapSprite);
        }
    }

    public void SetTilemapVisual(TilemapVisual tilemapVisual)
    {
        tilemapVisual.SetGrid(this, grid);
    }

	public TilemapObject GetTilemapObject(int x, int y)
	{
		TilemapObject tilemapObject = grid.GetGridObject(x, y);
		if (tilemapObject != null)
		{
			return tilemapObject;
		}
		else
		{
			return null;
		}
	}

	public TilemapObject GetTilemapObject(Vector3 objectPos)
	{
		TilemapObject tilemapObject = grid.GetGridObject(objectPos);
        if (tilemapObject != null)
        {
            return tilemapObject;
        }
        else
        {
            return null;
        }
    }


    public class TilemapObject
	{
		public enum TilemapSprite
		{
			None,
			Ground,
			Path
		}

		private Grid<TilemapObject> grid;
		private int x;
		private int y;
		private TilemapSprite tilemapSprite;

        public int X { get => x; private set => x = value; }
        public int Y { get => y; private set => y = value; }

        public TilemapObject(Grid<TilemapObject> grid, int x, int y)
		{
			this.grid = grid;
			this.x = x;
			this.y = y;
		}

		public void SetTilemapSprite(TilemapSprite tilemapSprite)
		{
			this.tilemapSprite = tilemapSprite;
            grid.TriggerGridObjectChanged(X, Y);
        }

        public TilemapSprite GetTilemapSprite() { return tilemapSprite; }

        public override string ToString()
        {
            return tilemapSprite.ToString();
        }
    }
}
