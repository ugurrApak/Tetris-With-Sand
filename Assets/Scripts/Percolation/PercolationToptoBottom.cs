using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PercolationToptoBottom
{
    private int lengthX;
    private int lengthY;
    private WeightedQU connections;
    bool[] states;
    int yTolerance = 50;
    public PercolationToptoBottom()
    {
        lengthX = Tilemap.Instance.Width;
        lengthY = Tilemap.Instance.Height;
        connections = new WeightedQU(lengthX * (lengthY - yTolerance) + 2);
        states= new bool[lengthX * (lengthY - yTolerance) + 2];
        for (int i = 0; i < states.Length; i++)
        {
            states[i] = false;
        }
        states[lengthX * (lengthY - yTolerance)] = true;
        states[lengthX * (lengthY - yTolerance) + 1] = true;
        Tilemap.Instance.Grid.OnGridObjectChanged += Grid_OnGridValueChanged;
    }
    public void Open(int x, int y)
    {
        Validate(x,y);
        int cell = xyto1D(x,y);
        if (x != 0 && IsOpen(x - 1,y))
        {
            Union(xyto1D(x - 1, y), cell);
        }
        if (x != lengthX - 1 && IsOpen(x + 1, y))
        {
            Union(xyto1D(x + 1, y), cell);
        }
        if (y != 0 && IsOpen(x, y - 1))
        {
            Union(xyto1D(x,y - 1), cell);
        }
        else if (y == 0)
        {
            Union(lengthX * (lengthY - yTolerance), cell);
        }
        if (y != (lengthY - yTolerance) - 1 && IsOpen(x, y + 1))
        {
            Union(xyto1D(x, y + 1), cell);
        }
        else if (y == (lengthY - yTolerance) - 1)
        {
            Union(lengthX * (lengthY - yTolerance) + 1, cell);
        }
    }
    public void Union(int x, int y)
    {
        if (!connections.Connected(x,y))
        {
            connections.Union(x,y);
        }
    }
    private bool IsOpen(int x, int y)
    {
        return states[xyto1D(x,y)];
    }
    private int xyto1D(int x, int y)
    {
        //Validate(x, y);
        return lengthX * y + x;
    }
    public bool Percolates()
    {
        return connections.Connected(lengthX * (lengthY - yTolerance), lengthX * (lengthY - yTolerance) + 1);
    }
    private void Validate(int x, int y)
    {
        if (x > lengthX || x < 0 || y < 0 || y > (lengthY - yTolerance))
        {
            throw new ArgumentOutOfRangeException();
        }
    }
    private void UpdateConnections()
    {
        for (int i = 0; i < lengthX * (lengthY - yTolerance); i++)
        {
            Vector2Int xy = xto2D(i);
            if (states[i])
            {
                Open(xy.x, xy.y);
            }
        }
        if (Percolates())
        {
            GameManager.Instance.UpdateGameState(GameState.LOSE);
        }
        connections.ClearAll();
    }
    private Vector2Int xto2D(int x)
    {
        return new Vector2Int(x % (lengthX), (x - (x % (lengthX))) / (lengthX));
    }
    public IEnumerator Wait()
    {
        while (true)
        {
            UpdateConnections();
            yield return new WaitForSeconds(.01f);
        }
    }
    private void Grid_OnGridValueChanged(object sender, Grid<IGridObject>.OnGridObjectChangedEventArgs e)
    {
        if (xyto1D(e.x, e.y) < lengthX * (lengthY - yTolerance))
        {
            if (Tilemap.Instance.GetTilemapObject(e.x, e.y).GetTilemapSprite() != Cell.TilemapSprite.None)
            {
                states[xyto1D(e.x, e.y)] = true;
            }
            else
            {
                states[xyto1D(e.x, e.y)] = false;
            }
        }
    }
}
