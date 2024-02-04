using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Percolation perc;
    private void Awake()
    {
        perc = new Percolation();
    }
    private void Update()
    {
        for (int i = 0; i < Tilemap.Instance.Width; i++)
        {
            for (int j = 0; j < Tilemap.Instance.Height; j++)
            {
                if (Tilemap.Instance.GetTilemapObject(Tilemap.Instance.Grid, i, j).GetTilemapSprite() == Cell.TilemapSprite.Ground)
                {
                    perc.Open(i, j);
                }
            }
        }
        Debug.Log(perc.Percolates());
    }
}
