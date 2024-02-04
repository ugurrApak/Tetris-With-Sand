using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Cell : IGridObject
{
    public enum TilemapSprite
    {
        None,
        Ground,
        Path
    }
    private Grid<IGridObject> grid;
    private int x;
    private int y;
    private TilemapSprite tilemapSprite;
    private MonoBehaviour mb;
    private bool canMove = true;
    public int X { get => x; private set => x = value; }
    public int Y { get => y; private set => y = value; }

    public bool CanMove { get => canMove; private set => canMove = value; }
    public Cell(Grid<IGridObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        StartCoroutine();
    }
    public void StopCoroutine()
    {
        mb = GameObject.FindObjectOfType<MonoBehaviour>();
        if (mb != null)
        {
            mb.StopAllCoroutines();
        }
        else
        {
            Debug.Log("Object not found.");
        }
    }
    public void StartCoroutine()
    {
        mb = GameObject.FindObjectOfType<MonoBehaviour>();
        if (mb != null)
        {
            mb.StartCoroutine(WaitForCellMove());
        }
        else
        {
            Debug.Log("Object not found.");
        }
    }

    public void SetTilemapSprite(TilemapSprite tilemapSprite)
    {
        this.tilemapSprite = tilemapSprite;
        grid.TriggerGridObjectChanged(x, y);
    }
    public TilemapSprite GetTilemapSprite() { return tilemapSprite; }
    public void UpdateCellPos(TilemapSprite _tilemapSprite)
    {
        Vector3Int xyPosDown = new Vector3Int(x, y - 1, 0);
        Vector3Int xyPosDownLeft = new Vector3Int(x - 1, y - 1, 0);
        Vector3Int xyPosDownRight = new Vector3Int(x + 1, y - 1, 0);
        if (xyPosDown.y < 0)
        {
            canMove = false;
            return;
        }
        if (grid.GetGridObject(xyPosDown.x, xyPosDown.y).GetTilemapSprite() == TilemapSprite.None)
        {
            Vector3Int cellPos = new Vector3Int(x, y);
            Tilemap.Instance.SetTilemapSprite(cellPos.x, cellPos.y, TilemapSprite.None);
            Tilemap.Instance.SetTilemapSprite(xyPosDown.x, xyPosDown.y, _tilemapSprite);
        }
        else if (xyPosDownLeft.x >= 0 && grid.GetGridObject(xyPosDownLeft.x, xyPosDownLeft.y).GetTilemapSprite() == TilemapSprite.None)
        {
            Vector3Int cellPos = new Vector3Int(x, y);
            Tilemap.Instance.SetTilemapSprite(cellPos.x, cellPos.y, TilemapSprite.None);
            Tilemap.Instance.SetTilemapSprite(xyPosDownLeft.x, xyPosDownLeft.y, _tilemapSprite);
        }
        else if (xyPosDownRight.x <= Tilemap.Instance.Height && grid.GetGridObject(xyPosDownRight.x, xyPosDownRight.y).GetTilemapSprite() == TilemapSprite.None)
        {
            Vector3Int cellPos = new Vector3Int(x, y);
            Tilemap.Instance.SetTilemapSprite(cellPos.x, cellPos.y, TilemapSprite.None);
            Tilemap.Instance.SetTilemapSprite(xyPosDownRight.x, xyPosDownRight.y, _tilemapSprite);
        }
        else if(!grid.GetGridObject(xyPosDown.x,xyPosDown.y).CanMove && !grid.GetGridObject(xyPosDownLeft.x, xyPosDownLeft.y).CanMove && !grid.GetGridObject(xyPosDownRight.x, xyPosDownRight.y).CanMove)
        {
            canMove = false;
        }
    }
    public override string ToString()
    {
        return tilemapSprite.ToString();
    }
    IEnumerator WaitForCellMove()
    {
        while (canMove /*&& tilemapSprite != TilemapSprite.None*/)
        {
            if (tilemapSprite != TilemapSprite.None)
            {
                UpdateCellPos(tilemapSprite);
            }
            yield return new WaitForSeconds(.02f);
        }
    }
}
