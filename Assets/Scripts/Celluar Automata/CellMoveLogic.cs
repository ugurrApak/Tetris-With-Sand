using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CellMoveLogic : MonoBehaviour
{
    [SerializeField] private TilemapVisual tilemapVisual;
    private Tilemap tilemap;
    private Cell.TilemapSprite noneSprite;
    private Cell.TilemapSprite tilemapSprite;
    private Cell tilemapObject;
    private float cellSize = 7f;

    private void Start()
    {
        tilemap = new Tilemap(10, 5, cellSize, Vector3.zero);
        tilemap.SetTilemapVisual(tilemapVisual);
        tilemap.SetTilemapSprite(9,4, Cell.TilemapSprite.Ground);
        tilemapObject = tilemap.GetTilemapObject(9,4);
        InvokeRepeating("UpdateCellPos",.1f,.1f);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = Utils.GetMouseWorldPosition();
            tilemap.SetTilemapSprite(mouseWorldPosition, Cell.TilemapSprite.Ground);
            tilemapObject = tilemap.GetTilemapObject(mouseWorldPosition);
            InvokeRepeating("UpdateCellPos", .1f, .1f);
        }
    }

    private void UpdateCellPos()
    {
        Vector3Int xyPosDown = new Vector3Int(tilemapObject.X, tilemapObject.Y - 1, 0);
        Vector3Int xyPosDownLeft = new Vector3Int(tilemapObject.X - 1, tilemapObject.Y - 1, 0);
        Vector3Int xyPosDownRight = new Vector3Int(tilemapObject.X + 1, tilemapObject.Y - 1, 0);
        if (tilemap.GetTilemapObject(xyPosDown.x, xyPosDown.y).GetTilemapSprite() == Cell.TilemapSprite.None)
        {
            tilemapSprite = tilemapObject.GetTilemapSprite();
            Vector3Int cellPos = new Vector3Int(tilemapObject.X, tilemapObject.Y);
            tilemap.SetTilemapSprite(cellPos.x, cellPos.y, noneSprite);
            tilemap.SetTilemapSprite(xyPosDown.x, xyPosDown.y, tilemapSprite);
            tilemapObject = tilemap.GetTilemapObject(xyPosDown.x, xyPosDown.y);
        }
        else if (tilemap.GetTilemapObject(xyPosDownLeft).GetTilemapSprite() == Cell.TilemapSprite.None && xyPosDownLeft.x >= 0)
        {
            tilemapSprite = tilemapObject.GetTilemapSprite();
            Vector3Int cellPos = new Vector3Int(tilemapObject.X, tilemapObject.Y);
            tilemap.SetTilemapSprite(cellPos.x, cellPos.y, noneSprite);
            tilemap.SetTilemapSprite(xyPosDownLeft.x, xyPosDownLeft.y, tilemapSprite);
            tilemapObject = tilemap.GetTilemapObject(xyPosDownLeft.x, xyPosDownLeft.y);
        }
        else if (tilemap.GetTilemapObject(xyPosDownRight).GetTilemapSprite() == Cell.TilemapSprite.None && xyPosDownRight.x <= 9)
        {
            tilemapSprite = tilemapObject.GetTilemapSprite();
            Vector3Int cellPos = new Vector3Int(tilemapObject.X, tilemapObject.Y);
            tilemap.SetTilemapSprite(cellPos.x, cellPos.y, noneSprite);
            tilemap.SetTilemapSprite(xyPosDownRight.x, xyPosDownRight.y, tilemapSprite);
            tilemapObject = tilemap.GetTilemapObject(xyPosDownRight.x, xyPosDownRight.y);
        }

        if (tilemapObject.Y == 0)
        {
            CancelInvoke("UpdateCellPos");
        }
    }
}
