using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] int halfWidth, halfHeight;
    [SerializeField] GameObject hero;

    [SerializeField] Tile tilePrefab;

    // Tile[] baredTiles;
    // Tile[] coveredTiles;

    Tile tileWithMouse;

    void Start() 
    {
        // tileArray = new Tile[halfWidth*4*halfHeight]; 
        GenerateGrid();
    }

    void GenerateGrid()
    {
        Vector2 heroPos = hero.transform.position;

        int x = Mathf.FloorToInt(heroPos.x);
        int y = Mathf.FloorToInt(heroPos.y);

        for (int i = x - halfWidth; i < x + halfWidth; i++) {
            for (int j = y - halfHeight; j < y + halfHeight; j++) {
                Transform parent = transform.Find("Bared").transform;
                Instantiate(tilePrefab, new Vector3 (i, j), Quaternion.identity, parent);
            }
        }
    }

    public void SetTileWithMouse(Tile tile)
    {
        tileWithMouse = tile;
    }

    public bool IsMouseOverTiles() {
        return tileWithMouse.IsCovered();
    }

    public void CoverTile(Sprite newSprite) 
    {
        tileWithMouse.GetComponent<SpriteRenderer>().sprite = newSprite;

        Transform parent = transform.Find("Covered").transform;
        tileWithMouse.GetComponent<Transform>().SetParent(parent);
    }
}
