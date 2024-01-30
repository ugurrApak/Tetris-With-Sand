using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Tilemap.TilemapObject;

public class CellMoveLogic : MonoBehaviour
{
    [SerializeField] private TilemapVisual tilemapVisual;
    private Tilemap tilemap;
    private TilemapSprite noneSprite;
    private TilemapSprite tilemapSprite;
    private Tilemap.TilemapObject tilemapObject;
    private float cellSize = 7f;

    private void Start()
    {
        tilemap = new Tilemap(10, 5, cellSize, Vector3.zero);
        noneSprite = TilemapSprite.None;
        tilemap.SetTilemapVisual(tilemapVisual);
        tilemap.SetTilemapSprite(9,4, TilemapSprite.Ground);
        tilemapObject = tilemap.GetTilemapObject(9,4);
        InvokeRepeating("UpdateCellPos", 0.02f, 0.02f);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = Utils.GetMouseWorldPosition();
            tilemap.SetTilemapSprite(mouseWorldPosition, TilemapSprite.Ground);
        }
    }

    private void UpdateCellPos()
    {
        Vector3Int xyPosDown = new Vector3Int(tilemapObject.X, tilemapObject.Y - 1, 0);
        Vector3Int xyPosDownLeft = new Vector3Int(tilemapObject.X - 1, tilemapObject.Y - 1, 0);
        Vector3Int xyPosDownRight = new Vector3Int(tilemapObject.X + 1, tilemapObject.Y - 1, 0);
        Debug.Log(xyPosDown.y);
        if (tilemap.GetTilemapObject(xyPosDown.x, xyPosDown.y).GetTilemapSprite() == TilemapSprite.None)
        {
            tilemapSprite = tilemapObject.GetTilemapSprite();
            Debug.Log("Done");
            Vector3Int cellPos = new Vector3Int(tilemapObject.X, tilemapObject.Y);
            tilemap.SetTilemapSprite(cellPos.x,cellPos.y, noneSprite);
            tilemap.SetTilemapSprite(xyPosDown.x, xyPosDown.y, tilemapSprite);
            Debug.Log(tilemap.GetTilemapObject(xyPosDown.x, xyPosDown.y).GetTilemapSprite());
            tilemapObject = tilemap.GetTilemapObject(xyPosDown.x, xyPosDown.y);
        }
        else if (tilemap.GetTilemapObject(xyPosDownLeft) == null)
        {
            Vector3 cellPos = new Vector3(tilemapObject.X, tilemapObject.Y);
            tilemap.SetTilemapSprite(cellPos, noneSprite);
            tilemap.SetTilemapSprite(xyPosDown, tilemapObject.GetTilemapSprite());
        }
        else if (tilemap.GetTilemapObject(xyPosDownRight) == null)
        {
            Vector3 cellPos = new Vector3(tilemapObject.X, tilemapObject.Y);
            tilemap.SetTilemapSprite(cellPos, noneSprite);
            tilemap.SetTilemapSprite(xyPosDown, tilemapObject.GetTilemapSprite());
        }
        else
        {
            return;
        }
    }
}
