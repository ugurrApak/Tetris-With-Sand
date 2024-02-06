using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public sealed class Tilemap : MonoBehaviour
{
	private Grid<IGridObject> grid;
	[SerializeField] private int width, height;
	[SerializeField] private float cellSize;
	[SerializeField] private Vector3 originPosition;

    public static Tilemap Instance { get; private set; }

    public int Width => width;
	public int Height => height;
	public float CellSize => cellSize;
    public Vector3 OriginPosition => originPosition;
    public Grid<IGridObject> Grid => grid;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        grid = new Grid<IGridObject>(width, height, cellSize, originPosition, (Grid<IGridObject> g, int x, int y) => new Cell(g, x, y));
    }
    public void SetTilemapSprite(Vector3 worldPosition, Cell.TilemapSprite tilemapSprite)
	{
        IGridObject tilemapObject = grid.GetGridObject(worldPosition);
		tilemapObject.SetTilemapSprite(tilemapSprite);
    }
	public void SetTilemapSprite(int x, int y, Cell.TilemapSprite tilemapSprite)
    {
        IGridObject tilemapObject = grid.GetGridObject(x,y);
        tilemapObject.SetTilemapSprite(tilemapSprite);
    }
    public void SetTilemapVisual(TilemapVisual tilemapVisual)
    {
        tilemapVisual.SetGrid(this, grid);
    }
	public IGridObject GetTilemapObject(int x, int y)
	{
		IGridObject tilemapObject = grid.GetGridObject(x, y);
		return tilemapObject;
	}
	public IGridObject GetTilemapObject(Vector3 objectPos)
	{
		IGridObject tilemapObject = grid.GetGridObject(objectPos);
		return tilemapObject;
    }
}
