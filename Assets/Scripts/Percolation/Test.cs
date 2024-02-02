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
        if (Input.GetMouseButtonDown(1))
        {
            for (int i = 0; i < Tilemap.Instance.Width; i++)
            {
                for (int j = 0; j < Tilemap.Instance.Height; j++)
                {
                    if (Tilemap.Instance.GetTilemapObject(i,j).GetTilemapSprite() == Cell.TilemapSprite.Ground)
                    {
                        perc.Open(i,j);
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log(perc.Percolates());
        }
    }
}
