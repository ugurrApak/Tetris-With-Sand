using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Percolation
{
    private int lengthX;
    private int lengthY;
    private bool[] states;
    private WeightedQU connections;
    private Cell.TilemapSprite tilemapSprite;

    public Percolation(Cell.TilemapSprite tilemapSprite)
    {
        lengthX = Tilemap.Instance.Width;
        lengthY = Tilemap.Instance.Height;
        connections = new WeightedQU(lengthX * lengthY + 1);
        states = new bool[lengthX * lengthY + 1];
        for (int i = 0; i < lengthX * lengthY; i++)
        {
            states[i] = false;
        }
        states[lengthX * lengthY] = true;
        this.tilemapSprite = tilemapSprite;
        Tilemap.Instance.Grid.OnGridObjectChanged += Grid_OnGridValueChanged;
    }
    public void Open(int i, int j)
    {
        Validate(i, j);
        int cell = xyto1D(i, j);
        if (i != 0 && IsOpen(i - 1, j))
        {
            Union(xyto1D(i - 1, j), cell);
        }
        if (i != lengthX - 1 && IsOpen(i + 1, j))
        {
            Union(xyto1D(i + 1, j), cell);
        }
        else if (i == lengthX - 1)
        {
            Union(cell, lengthX * lengthY);
        }

        if (j != 0 && IsOpen(i, j - 1))
        {
            Union(xyto1D(i, j - 1), cell);
        }

        if (j != lengthY - 1 && IsOpen(i, j + 1))
        {
            Union(xyto1D(i, j + 1), cell);
        }


        //if (i != lengthX - 1 && j != 0 && IsOpen(i + 1, j - 1))
        //{
        //    Union(xyto1D(i + 1, j - 1), cell);
        //}
        //if (i != lengthX - 1 && j != lengthY - 1 && IsOpen(i + 1, j + 1))
        //{
        //    Union(xyto1D(i + 1, j + 1), cell);
        //}
        //if (i != 0  && j != 0 && IsOpen(i - 1, j - 1))
        //{
        //    Union(xyto1D(i - 1, j - 1), cell);
        //}
        //if (i != 0  && j != lengthY - 1 && IsOpen(i - 1, j + 1))
        //{
        //    Union(xyto1D(i - 1, j + 1), cell);
        //}
    }
    private void Union(int x, int y)
    {
        if (!connections.Connected(x, y))
        {
            connections.Union(x,y);
        }
    }
    private bool IsOpen(int i, int j)
    {
        Validate(i, j);
        return states[xyto1D(i, j)];
    }
    private bool IsFull(int i, int j)
    {
        Validate(i, j);
        return connections.Connected(lengthX * lengthY, xyto1D(i, j));
    }

    private bool Percolates()
    {
        for (int i = 0; i < lengthY; i++)
        {
            if (connections.Connected(i * (lengthX), lengthX * lengthY))
            {
                return true;
            }
        }
        return false;
    }
    private List<Vector2Int> GetConnectedCoords()
    {
        List<Vector2Int> connectedCoords = new List<Vector2Int>();
        for (int i = 0; i < lengthX * lengthY; i++)
        {
            if (states[i])
            {
                Vector2Int xy = xto2D(i);
                if (IsFull(xy.x,xy.y))
                {
                    connectedCoords.Add(xy);
                }
            }
        }
        return connectedCoords;
    }
    private void Validate(int i, int j)
    {
        if (i > lengthX || i < 0 || j > lengthY || j < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    private int xyto1D(int i, int j)
    {
        return lengthX * j + i;
    }
    private Vector2Int xto2D(int x)
    {
        return new Vector2Int(x % (lengthX), (x - (x % (lengthX))) / (lengthX));
    }
    private void UpdateConnections()
    {
        for (int i = 0; i < lengthX * lengthY; i++)
        {
            Vector2Int xy = xto2D(i);
            if (states[i])
            {
                Open(xy.x,xy.y);
            }
        }
        if (Percolates())
        {
            foreach (var item in GetConnectedCoords())
            {
                Tilemap.Instance.SetTilemapSprite(item.x, item.y, Cell.TilemapSprite.None);
                Tilemap.Instance.GetTilemapObject(item.x, item.y).CanMove = true;
                states[xyto1D(item.x, item.y)] = false;
            }
            for (int i = 0; i < lengthX * lengthY; i++)
            {
                Vector2Int xy = xto2D(i);
                IGridObject gridObject = Tilemap.Instance.GetTilemapObject(xy.x, xy.y);
                if (!gridObject.CanMove)
                {
                    gridObject.CanMove = true;
                    gridObject.StartCoroutine(gridObject.GetTilemapSprite());
                }
            }
            SoundManager.Instance.PlaySound("resolve_1");
        }
        connections.ClearAll();
    }
    public IEnumerator Wait()
    {
        while (true)
        {
            UpdateConnections();
            yield return new WaitForSeconds(.06f);
        }
    }
    private void Grid_OnGridValueChanged(object sender, Grid<IGridObject>.OnGridObjectChangedEventArgs e)
    {
        if (Tilemap.Instance.GetTilemapObject(e.x,e.y).GetTilemapSprite() == tilemapSprite)
        {
            states[xyto1D(e.x, e.y)] = true;
        }
        else
        {
            states[xyto1D(e.x, e.y)] = false;
        }
    }
}
