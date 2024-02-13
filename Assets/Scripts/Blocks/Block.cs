//using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEditor.Rendering;
using UnityEngine;

public abstract class Block
{
    protected Cell.TilemapSprite tilemapSprite;
    private int cellCount;
    protected Grid<IGridObject> grid;
    private int startPosX;
    private int startPosY;
    private int endPosX;
    private int endPosY;
    private int changeX = 0;
    private int changeY = 0;
    private bool canMove;
    private bool canMoveRight;
    private bool canMoveLeft;
    private MonoBehaviour mb;
    protected Vector2Int[,] blockArray;
    protected bool[,] blocks;
    
    public Cell.TilemapSprite TilemapSprite { get => tilemapSprite; private set => tilemapSprite = value; }
    public Block(Grid<IGridObject> grid)
    {
        canMove = true;
        canMoveRight= true;
        canMoveLeft= true;
        StartCoroutine();
        this.grid = grid;
    }
    
    public void SetTilemapSprite(Cell.TilemapSprite tilemapSprite, int x , int y, int rowBlockCounter)
    {
        startPosX = ((grid.GetWidth() - (4 * cellCount)) / 2) + ((x - 1) * cellCount) - 1 + changeX;
        endPosX = startPosX + cellCount * rowBlockCounter;
        startPosY = grid.GetHeight() + changeY - (cellCount * 4) + ((y - 1) * cellCount) - 1;
        endPosY = startPosY + cellCount;
        for (int i = startPosY; i < endPosY; i++)
        {
            for (int j = startPosX; j < endPosX; j++)
            {
                grid.GetGridObject(j, i).SetTilemapSprite(tilemapSprite);
                blockArray[((y - 1) * cellCount) + i - startPosY, ((x - 1) * cellCount) + j - startPosX] = new Vector2Int(j, i);
            }
        }
    }
    public void StartCoroutine()
    {
        mb = GameObject.FindObjectOfType<MonoBehaviour>();
        if (mb != null)
        {
            mb.StartCoroutine(WaitForCellMove());
        }
        else
        {
            Debug.Log("Object not found.");
        }
    }
    public void StopCoroutine()
    {
        if (mb != null)
        {
            mb.StopCoroutine(WaitForCellMove());
        }
        else
        {
            Debug.Log("Object not found.");
        }
    }
    public void UpdateCellPos()
    {
        for (int i = 0; i < blockArray.GetLength(0); i++)
        {
            for (int j = 0; j < blockArray.GetLength(1); j++)
            {
                int x = blockArray[i, j].x;
                int y = blockArray[i, j].y;
                if (blockArray[i,j] != Vector2Int.zero)
                {
                    if (y <= 0 || grid.GetGridObject(x, y - 1).GetTilemapSprite() != Cell.TilemapSprite.None)
                    {
                        for (int k = 0; k < blockArray.GetLength(0); k++)
                        {
                            for (int l = 0; l < blockArray.GetLength(1); l++)
                            {
                                if (blockArray[k, l] != Vector2Int.zero)
                                {
                                    grid.GetGridObject(blockArray[k, l].x, blockArray[k, l].y).StartCoroutine(tilemapSprite);
                                    canMove = false;
                                }
                            }
                        }
                        SoundManager.Instance.PlaySound("tetromino_drop");
                        return;
                    }
                    grid.GetGridObject(x, y).SetTilemapSprite(Cell.TilemapSprite.None);
                    grid.GetGridObject(x, y - 1).SetTilemapSprite(tilemapSprite);
                    blockArray[i, j] = new Vector2Int(x, y - 1);
                }
            }
        }
        changeY -= 1;
    }
    public void CreateBlock(bool[,] blocks)
    {
        cellCount = Tilemap.Instance.Width / 10;
        int rowBlockCounter = 0;
        int firstRowBlock = 0;
        blockArray = new Vector2Int[4 * cellCount, 4 * cellCount];
        for (int i = 0; i < blocks.GetLength(0); i++)
        {
            for (int j = 0; j < blocks.GetLength(1); j++)
            {
                if (blocks[i, j])
                {
                    if (rowBlockCounter == 0)
                    {
                        firstRowBlock = j;
                    }
                    rowBlockCounter++;
                }
            }
            SetTilemapSprite(tilemapSprite, firstRowBlock + 1, i + 1, rowBlockCounter);
            rowBlockCounter = 0;
        }
    }
    public async void RotateBlock()
    {
        if (canMove)
        {
            StopCoroutine();
            canMove = false;
            await Task.Delay(10);
            bool[,] temp = (bool[,])blocks.Clone();
            for (int i = 0; i < blocks.GetLength(0); i++)
            {
                for (int j = 0; j < blocks.GetLength(1); j++)
                {
                    blocks[i, j] = temp[temp.GetLength(0) - j - 1, i];
                    //if (temp[temp.GetLength(0) - j - 1, i] != Vector2Int.zero)
                    //{
                    //    Vector2Int change = new Vector2Int(temp[temp.GetLength(0) - j - 1, i].x + (temp.GetLength(0) - j - 1 - i), temp[temp.GetLength(0) - j - 1, i].y + (j - i));
                    //    //temp[blockArray.GetLength(0) - j - 1, i] = change;
                    //    blockArray[i, j] = change;
                    //}
                }
            }
            for (int i = 0; i < blockArray.GetLength(0); i++)
            {
                for (int j = 0; j < blockArray.GetLength(1); j++)
                {
                    if (blockArray[i, j] != Vector2Int.zero)
                    {
                        grid.GetGridObject(blockArray[i, j].x, blockArray[i, j].y).SetTilemapSprite(Cell.TilemapSprite.None);
                    }
                }
            }
            CreateBlock(blocks);
            canMove = true;
            canMoveRight = true; canMoveLeft = true;
            StartCoroutine();
        }
    }
    public void MoveBlock(float horizontalInput)
    {
        if (horizontalInput > 0 && canMove && canMoveRight)
        {
            for (int i = 0; i < blockArray.GetLength(0); i++)
            {
                for (int j = blockArray.GetLength(1) -1; j >= 0; j--)
                {
                    int x = blockArray[i, j].x;
                    int y = blockArray[i, j].y;
                    if (blockArray[i, j] != Vector2Int.zero)
                    {
                        if (y <= 0 || x + horizontalInput >= Tilemap.Instance.Width)
                        {
                            canMoveRight = false;
                            return;
                        }
                        grid.GetGridObject(x, y).SetTilemapSprite(Cell.TilemapSprite.None);
                        grid.GetGridObject(x + (int)horizontalInput, y).SetTilemapSprite(tilemapSprite);
                        blockArray[i, j] = new Vector2Int(x + (int)horizontalInput, y);
                    }
                    else if ((y <= 0 || x + horizontalInput >= Tilemap.Instance.Width) && blockArray[i, j] != Vector2Int.zero)
                    {
                        canMoveRight = false;
                        return;
                    }
                }
            }
            canMoveLeft = true;
            changeX += 1;
        }
        else if (canMove && canMoveLeft && horizontalInput < 0)
        {
            for (int i = 0; i < blockArray.GetLength(0); i++)
            {
                for (int j = 0; j < blockArray.GetLength(1); j++)
                {
                    int x = blockArray[i, j].x;
                    int y = blockArray[i, j].y;
                    if (blockArray[i, j] != Vector2Int.zero)
                    {
                        if (y <= 0 || x + horizontalInput < 0)
                        {
                            canMoveLeft = false;
                            return;
                        }
                        grid.GetGridObject(x, y).SetTilemapSprite(Cell.TilemapSprite.None);
                        grid.GetGridObject(x + (int)horizontalInput, y).SetTilemapSprite(tilemapSprite);
                        blockArray[i, j] = new Vector2Int(x + (int)horizontalInput, y);
                    }
                }
            }
            canMoveRight = true;
            changeX -= 1;
        }
    }
    IEnumerator WaitForCellMove()
    {
        while (canMove)
        {
            if (tilemapSprite != Cell.TilemapSprite.None)
            {
                UpdateCellPos();
            }
            yield return new WaitForSeconds(.02f);
        }
    }
    public override string ToString()
    {
        string str = "\n";
        for (int i = 0; i < blockArray.GetLength(0); i++)
        {
            for (int j = 0; j < blockArray.GetLength(1); j++)
            {
                str += blockArray[i, j].ToString();
                str += "\t |";
            }
            str += "\n";
            str += "----------------------------------------------------";
            str+= "\n";
        }
        return str;
    }
}
