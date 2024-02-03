using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CellMoveLogic : MonoBehaviour
{
    [SerializeField] private TilemapVisual tilemapVisual;

    private void Start()
    {
        Tilemap.Instance.SetTilemapVisual(Tilemap.Instance.Grid, tilemapVisual);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 mouseWorldPosition = Utils.GetMouseWorldPosition();
            Tilemap.Instance.SetTilemapSprite(Tilemap.Instance.Grid, mouseWorldPosition, Cell.TilemapSprite.Ground);
        }
    }
}
