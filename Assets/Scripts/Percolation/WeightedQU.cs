using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedQU
{
    private int[] parent;
	private int[] size;
	private int count;

	public int Count => count;

	public WeightedQU(int n)
	{
		parent = new int[n];
		size = new int[n];
		count = n;
		for (int i = 0; i < n; i++)
		{
			parent[i] = i;
			size[i] = 1;
		}
	}
	public int Find(int p)
	{
		Validate(p);
        int root = p;
        while (root != parent[root])
            root = parent[root];
        while (p != root)
        {
            int newp = parent[p];
            parent[p] = root;
            p = newp;
        }
        return root;
    }

	public bool Connected(int p, int q)
	{
		Validate(p);
		Validate(q);
		return Find(p) == Find(q);
	}

	public void Union(int p, int q)
	{
		Validate(p);
		Validate(q);
		int rootP = Find(p);
		int rootQ = Find(q);

		if (rootP == rootQ) return;
		if (size[p] < size[q])
		{
			parent[rootP] = rootQ;
			size[rootQ] += size[rootP];
		}
		else
		{
			parent[rootQ] = rootP;
			size[rootP] += size[rootQ];
		}
		count--;
	}
	private void Validate(int p)
	{
		int n = parent.Length;
		if (p > n || p < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
	}
}
