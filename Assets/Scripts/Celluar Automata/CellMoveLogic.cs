using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CellMoveLogic : MonoBehaviour
{
    [SerializeField] private TilemapVisual tilemapVisual;
    private Block o_Block;
    public static Percolation perc;

    private void Start()
    {
        Tilemap.Instance.SetTilemapVisual(tilemapVisual);
        perc = new Percolation();
        //StartCoroutine(perc.Wait());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Vector3 mouseWorldPosition = Utils.GetMouseWorldPosition();
            Tilemap.Instance.SetTilemapSprite(mouseWorldPosition, Cell.TilemapSprite.None);
        }
    }
}
