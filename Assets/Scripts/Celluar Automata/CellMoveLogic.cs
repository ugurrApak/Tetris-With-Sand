using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CellMoveLogic : MonoBehaviour
{
    [SerializeField] private TilemapVisual tilemapVisual;
    private Block o_Block;

    private void Start()
    {
        Tilemap.Instance.SetTilemapVisual(Tilemap.Instance.Grid, tilemapVisual);
        o_Block = new O_Block(Tilemap.Instance.Grid);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 mouseWorldPosition = Utils.GetMouseWorldPosition();
            Tilemap.Instance.SetTilemapSprite(Tilemap.Instance.Grid, mouseWorldPosition, Cell.TilemapSprite.Ground);
        }
    }
    private void FixedUpdate()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.1f);
        o_Block.UpdateCellPos(Cell.TilemapSprite.Path);
    }
}
