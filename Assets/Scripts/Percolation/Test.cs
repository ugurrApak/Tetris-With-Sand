using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Test : MonoBehaviour
{
    private Block block;
    [SerializeField] private TilemapVisual tilemapVisual;
    private Percolation percIBlock;
    private Percolation percOBlock;

    private void Start()
    {
        Tilemap.Instance.SetTilemapVisual(tilemapVisual);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CancelInvoke();
            block = new O_Block(Tilemap.Instance.Grid);
            InvokeRepeating("Move", .01f, .01f);
            if (percOBlock == null)
            {
                percOBlock = new Percolation(block.TilemapSprite);
                StartCoroutine(percOBlock.Wait());
                Debug.Log(block.TilemapSprite);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            CancelInvoke();
            block = new I_Block(Tilemap.Instance.Grid);
            InvokeRepeating("Move", .01f, .01f);
            if (percIBlock == null)
            {
                percIBlock = new Percolation(block.TilemapSprite);
                StartCoroutine(percIBlock.Wait());
                Debug.Log(block.TilemapSprite);
            }
        }
    }
    private void Move()
    {
        block.MoveBlock(Input.GetAxisRaw("Horizontal"));
    }
}