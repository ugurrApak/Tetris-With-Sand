using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CellMoveLogic : MonoBehaviour
{
    [SerializeField] private TilemapVisual tilemapVisual;
    private Block o_Block;

    private void Start()
    {
        Tilemap.Instance.SetTilemapVisual(tilemapVisual);
        o_Block = new O_Block(Tilemap.Instance.Grid);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 mouseWorldPosition = Utils.GetMouseWorldPosition();
            Tilemap.Instance.SetTilemapSprite(mouseWorldPosition, Cell.TilemapSprite.Ground);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Vector3 mouseWorldPosition = Utils.GetMouseWorldPosition();
            Tilemap.Instance.SetTilemapSprite(mouseWorldPosition, Cell.TilemapSprite.None);
        }
    }
}
