using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CellMoveLogic : MonoBehaviour
{
    [SerializeField] private TilemapVisual tilemapVisual;

    private void Start()
    {
        Tilemap.Instance.SetTilemapVisual(tilemapVisual);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = Utils.GetMouseWorldPosition();
            Tilemap.Instance.SetTilemapSprite(mouseWorldPosition, Cell.TilemapSprite.Ground);
        }
    }
}
