using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CellMoveLogic : MonoBehaviour
{
    [SerializeField] private TilemapVisual tilemapVisual;
    private Cell.TilemapSprite noneSprite;
    private Cell.TilemapSprite tilemapSprite;
    private Cell tilemapObject;

    private void Start()
    {
        Tilemap.Instance.SetTilemapVisual(tilemapVisual);
        Tilemap.Instance.SetTilemapSprite(9,4, Cell.TilemapSprite.Ground);
        tilemapObject = Tilemap.Instance.GetTilemapObject(9,4);
        InvokeRepeating("UpdateCellPos",.02f,.02f);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = Utils.GetMouseWorldPosition();
            Tilemap.Instance.SetTilemapSprite(mouseWorldPosition, Cell.TilemapSprite.Ground);
            tilemapObject = Tilemap.Instance.GetTilemapObject(mouseWorldPosition);
            InvokeRepeating("UpdateCellPos", .02f, .02f);
        }
    }

    private void UpdateCellPos()
    {
        Vector3Int xyPosDown = new Vector3Int(tilemapObject.X, tilemapObject.Y - 1, 0);
        Vector3Int xyPosDownLeft = new Vector3Int(tilemapObject.X - 1, tilemapObject.Y - 1, 0);
        Vector3Int xyPosDownRight = new Vector3Int(tilemapObject.X + 1, tilemapObject.Y - 1, 0);
        if (Tilemap.Instance.GetTilemapObject(xyPosDown.x, xyPosDown.y).GetTilemapSprite() == Cell.TilemapSprite.None)
        {
            tilemapSprite = tilemapObject.GetTilemapSprite();
            Vector3Int cellPos = new Vector3Int(tilemapObject.X, tilemapObject.Y);
            Tilemap.Instance.SetTilemapSprite(cellPos.x, cellPos.y, noneSprite);
            Tilemap.Instance.SetTilemapSprite(xyPosDown.x, xyPosDown.y, tilemapSprite);
            tilemapObject = Tilemap.Instance.GetTilemapObject(xyPosDown.x, xyPosDown.y);
        }
        else if (Tilemap.Instance.GetTilemapObject(xyPosDownLeft.x,xyPosDownLeft.y).GetTilemapSprite() == Cell.TilemapSprite.None && xyPosDownLeft.x >= 0)
        {
            tilemapSprite = tilemapObject.GetTilemapSprite();
            Vector3Int cellPos = new Vector3Int(tilemapObject.X, tilemapObject.Y);
            Tilemap.Instance.SetTilemapSprite(cellPos.x, cellPos.y, noneSprite);
            Tilemap.Instance.SetTilemapSprite(xyPosDownLeft.x, xyPosDownLeft.y, tilemapSprite);
            tilemapObject = Tilemap.Instance.GetTilemapObject(xyPosDownLeft.x, xyPosDownLeft.y);
        }
        else if (Tilemap.Instance.GetTilemapObject(xyPosDownRight.x,xyPosDownRight.y).GetTilemapSprite() == Cell.TilemapSprite.None && xyPosDownRight.x <= 9)
        {
            tilemapSprite = tilemapObject.GetTilemapSprite();
            Vector3Int cellPos = new Vector3Int(tilemapObject.X, tilemapObject.Y);
            Tilemap.Instance.SetTilemapSprite(cellPos.x, cellPos.y, noneSprite);
            Tilemap.Instance.SetTilemapSprite(xyPosDownRight.x, xyPosDownRight.y, tilemapSprite);
            tilemapObject = Tilemap.Instance.GetTilemapObject(xyPosDownRight.x, xyPosDownRight.y);
        }
        if (tilemapObject.Y == 0)
        {
            CancelInvoke("UpdateCellPos");
        }
    }
}
