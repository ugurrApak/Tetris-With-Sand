using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public sealed class Tilemap : MonoBehaviour
{
	private Grid<Cell> grid;
	[SerializeField] private int width, height;
	[SerializeField] private float cellSize;
	[SerializeField] private Vector3 originPosition;

    public static Tilemap Instance { get; private set; }

    public int Width => width;
	public int Height => height;
	public float CellSize => cellSize;
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
        grid = new Grid<Cell>(width, height, cellSize, originPosition, (Grid<Cell> g, int x, int y) => new Cell(g, x, y));
    }

    public void SetTilemapSprite(Vector3 worldPosition, Cell.TilemapSprite tilemapSprite)
	{
        Cell tilemapObject = grid.GetGridObject(worldPosition);
		tilemapObject.SetTilemapSprite(tilemapSprite);
        StartCoroutine(Wait(tilemapSprite, tilemapObject));
    }

	public void SetTilemapSprite(int x, int y, Cell.TilemapSprite tilemapSprite)
	{
        Cell tilemapObject = grid.GetGridObject(x,y);
        tilemapObject.SetTilemapSprite(tilemapSprite);
        StartCoroutine(Wait(tilemapSprite,tilemapObject));

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
    IEnumerator Wait(Cell.TilemapSprite tilemapSprite, Cell tilemapObject)
    {
        yield return new WaitForSeconds(.2f);
        if (tilemapSprite != Cell.TilemapSprite.None)
        {
            tilemapObject.UpdateCellPos(tilemapSprite);
        }
    }
}
