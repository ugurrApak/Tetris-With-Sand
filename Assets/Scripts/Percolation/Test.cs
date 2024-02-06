using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Test : MonoBehaviour
{
    Percolation perc;
    Block o_Block;
    private void Awake()
    {
        perc = new Percolation();
        InvokeRepeating("Move", .01f, .01f);
    }
    private void Update()
    {
        for (int i = 0; i < Tilemap.Instance.Width; i++)
        {
            for (int j = 0; j < Tilemap.Instance.Height; j++)
            {
                if (Tilemap.Instance.GetTilemapObject(i, j).GetTilemapSprite() == Cell.TilemapSprite.Path)
                {
                    perc.Open(i, j);
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            o_Block = new O_Block(Tilemap.Instance.Grid);
        }
    }
    private void FixedUpdate()
    {
        //if (perc.Percolates())
        //{
        //    foreach (var item in perc.GetConnectedCoords())
        //    {
        //        Tilemap.Instance.SetTilemapSprite(item.x, item.y, Cell.TilemapSprite.None);
        //    }
        //    perc.ClearAllConnections();
        //}
    }
    private void Move()
    {
        o_Block.MoveBlock(Input.GetAxisRaw("Horizontal"));
    }
}