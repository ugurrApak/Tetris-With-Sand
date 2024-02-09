using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Test : MonoBehaviour
{
    private Block o_Block;
    [SerializeField] private TilemapVisual tilemapVisual;
    private Percolation perc;

    private void Start()
    {
        Tilemap.Instance.SetTilemapVisual(tilemapVisual);
        perc = new Percolation();
        StartCoroutine(perc.Wait());
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CancelInvoke();
            o_Block = new O_Block(Tilemap.Instance.Grid);
            InvokeRepeating("Move", .01f, .01f);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Vector3 mouseWorldPosition = Utils.GetMouseWorldPosition();
            Tilemap.Instance.SetTilemapSprite(mouseWorldPosition, Cell.TilemapSprite.None);
        }
    }
    private void Move()
    {
        o_Block.MoveBlock(Input.GetAxisRaw("Horizontal"));
    }
}