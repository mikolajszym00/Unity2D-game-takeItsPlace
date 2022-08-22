using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Tile tilePrefab;
    [SerializeField] Sprite mySprite;

    [SerializeField] GameObject hero;

    Transform coveredParent;
    Transform baredParent;

    Tile tileWithMouse;

    GameObject tileCD;

    void Start() 
    {
        coveredParent = transform.Find("Covered");
        baredParent = transform.Find("Bared");

        tileCD = transform.Find("TileCD").gameObject;
        CreateStartingTile();
    }

    void Update()
    {

    }

    void CreateStartingTile()
    {
        Vector2 heroPos = hero.transform.position;
        int x = Mathf.FloorToInt(heroPos.x);
        int y = Mathf.FloorToInt(heroPos.y);

        Tile tile = Instantiate(tilePrefab, new Vector3 (x, y), Quaternion.identity, coveredParent);

        tile.SetCovered(mySprite, false);

        CreateBareTiles(x, y);
    }


    public bool IterateTilesContainer((int i, int j) coord, Transform parent)
    {
        foreach(Transform tile in parent)
        {
            (int x, int y) pos = Floor(tile.position);

            if (pos.x == coord.i && pos.y == coord.j)
            {
                return true;
            }
        }

        return false;
    }

    public void CreateBareTiles(int x, int y)
    {
        bool isCovered = false;
        (int i, int j) [] coordsToCheck = new [] {(x-1, y), (x+1, y), (x, y-1), (x, y+1)};
        
        foreach ((int i, int j) coord in coordsToCheck)
        {   
            isCovered = IterateTilesContainer(coord, coveredParent) || IterateTilesContainer(coord, baredParent);

            if (!isCovered) 
            {
                Instantiate(tilePrefab, new Vector3 (coord.i, coord.j), Quaternion.identity, baredParent.transform);
            }

            isCovered = false;
        }

        baredParent.gameObject.SetActive(false);
    }

    public bool MouseClickHandler(Vector3 mousePos)
    {
        (int x, int y) mouse = Floor(mousePos + new Vector3(0.5f, 0.5f, 0f)); 

        foreach(Transform tile in baredParent)
        {
            (int x, int y) pos = Floor(tile.position);

            if (pos.x == mouse.x && pos.y == mouse.y)
            {
                tile.gameObject.GetComponent<Tile>().SetCovered(mySprite, true);
                CreateBareTiles(pos.x, pos.y);
                DeactivateBare();

                return true;
            }
        }

        return false;
    }

    (int x, int y) Floor(Vector3 pos)
    {
        return (Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y));
    }

    public void SetSprite(Sprite newSprite)
    {
        mySprite = newSprite;
    }

    public Sprite GetSprite()
    {
        return mySprite;
    }

    public void ActivateBare() 
    {
        transform.Find("Bared").gameObject.SetActive(true);
    }

    public void DeactivateBare() 
    {
        transform.Find("Bared").gameObject.SetActive(false);
    }

    public Transform GetCoveredParent()
    {
        return coveredParent;
    }

    



    // void GenerateGrid()
    // {
    //     Vector2 heroPos = hero.transform.position;

    //     int x = Mathf.FloorToInt(heroPos.x);
    //     int y = Mathf.FloorToInt(heroPos.y);

    //     for (int i = x - halfWidth; i < x + halfWidth; i++) {
    //         for (int j = y - halfHeight; j < y + halfHeight; j++) {
    //             Transform parent = transform.Find("Bared").transform;
    //             Instantiate(tilePrefab, new Vector3 (i, j), Quaternion.identity, parent);
    //         }
    //     }
    // }

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
