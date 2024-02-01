using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Percolation
{
    private Cell.TilemapSprite sprite;
    private int lengthX;
    private int lengthY;
    private bool[] states;
    private WeightedQU connections;

    public Percolation()
    {
        lengthX = Tilemap.Instance.Width;
        lengthY = Tilemap.Instance.Height;
        connections = new WeightedQU(lengthX * lengthY + 2);
        states = new bool[lengthX * lengthY + 2];
        for (int i = 0; i < lengthX * lengthY; i++)
        {
            states[i] = false;
        }
        states[lengthX * lengthY] = true;
        states[lengthX * lengthY + 1] = true;
    }
    public void Open(int i, int j)
    {
        Validate(i, j);
        if (IsOpen(i, j)) return;
        int cell = xyto1D(i,j);
        states[cell] = true;

        if (i != 0 && IsOpen(i-1,j))
        {
            Union(xyto1D(i - 1, j),cell);
        }
        else if(i == 0)
        {
            Union(cell, lengthX * lengthY);
        }

        if (i != lengthX - 1 && IsOpen(i + 1, j))
        {
            Union(xyto1D(i + 1, j),cell);
        }
        else if (i == lengthX - 1)
        {
            Union(cell, lengthX * lengthY + 1);
        }

        if (j != 0 && IsOpen(i, j -1))
        {
            Union(xyto1D(i, j - 1), cell);
        }

        if (j != lengthY -1 && IsOpen(i, j + 1))
        {
            Union(xyto1D(i, j + 1), cell);
        }
    }
    private void Union(int x, int y)
    {
        if (!connections.Connected(x, y))
        {
            connections.Union(x,y);
        }
    }
    public bool IsOpen(int i, int j)
    {
        Validate(i, j);
        return states[xyto1D(i, j)];
    }
    public bool isFull(int i, int j)
    {
        Validate(i, j);
        return connections.Connected(lengthX * lengthY, xyto1D(i, j));
    }

    public bool Percolates()
    {
        return connections.Connected(lengthY * lengthX, lengthX * lengthY + 1);
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
}
