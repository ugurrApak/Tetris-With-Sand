using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBlock : MonoBehaviour
{
    [SerializeField] private Sprite[] blockSprites;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        spriteRenderer.sprite = null;
    }
    public void UpdateNextBlockSprite(int nextBlock)
    {
        switch (nextBlock)
        {
            case 0:
                spriteRenderer.sprite = blockSprites[nextBlock];
                break;
            case 1:
                spriteRenderer.sprite = blockSprites[nextBlock];

                break;
            case 2:
                spriteRenderer.sprite = blockSprites[nextBlock];
                break;
            case 3:
                spriteRenderer.sprite = blockSprites[nextBlock];
                break;
            case 4:
                spriteRenderer.sprite = blockSprites[nextBlock];
                break;
            case 5:
                spriteRenderer.sprite = blockSprites[nextBlock];
                break;
            default:
                break;
        }
    }
}
