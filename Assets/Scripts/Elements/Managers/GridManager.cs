using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : ElementManager
{
    [SerializeField] Tile tilePrefab;
    [SerializeField] Sprite mySprite;

    [SerializeField] GameObject campfire;

    Transform coveredParent;
    Transform baredParent;

    void Start() 
    {
        coveredParent = transform.Find("Covered");
        baredParent = transform.Find("Bared");

        CreateStartingTiles();
    }

    void CreateStartingTiles()
    {
        Vector2 campfirePos = campfire.transform.position;
        int x = Mathf.FloorToInt(campfirePos.x);
        int y = Mathf.FloorToInt(campfirePos.y);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Tile tile = Instantiate(tilePrefab, new Vector3 (x + i, y + j), Quaternion.identity, coveredParent);

                tile.SetCovered(mySprite, false);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                CreateBareTiles(x + i, y + j);
            }
        }

        BaredTileDeactivateHighlight();
    }

    void BaredTileDeactivateHighlight()
    {
        foreach(Transform child in baredParent)
        {
            if (child.tag == "BaredTile")
            {
                child.gameObject.GetComponent<Tile>().DeactivateHighlight();
            }
        }
    }

    public override void prepare(ElemSO elem)
    {
        foreach(Transform child in baredParent)
        {
            if (child.tag == "BaredTile")
            {
                child.gameObject.GetComponent<Tile>().ActivateHighlight();
            }
        }

    }

    public override void clean()
    {
        BaredTileDeactivateHighlight();
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
                Tile tile = Instantiate(tilePrefab, new Vector3 (coord.i, coord.j), Quaternion.identity, baredParent.transform);
                tile.ActivateCollision();
                tile.ActivateHighlight();
            }

            isCovered = false;
        }
    }

    public override GameObject MouseClickHandler(Vector3 mousePos)
    {
        (int x, int y) mouse = Floor(mousePos + new Vector3(0.5f, 0.5f, 0f)); 

        foreach(Transform tile in baredParent)
        {
            (int x, int y) pos = Floor(tile.position);

            if (pos.x == mouse.x && pos.y == mouse.y)
            {
                tile.gameObject.GetComponent<Tile>().SetCovered(mySprite, true);
                CreateBareTiles(pos.x, pos.y);

                return tile.gameObject;
            }
        }

        return null;
    }

    public bool IsPositionOnCoveredTiles(Vector3 myPos) // mozna przyspieszyc szukanie jesli 
    // zrobi sie chunki i na podstawie nazywy i koordynat bedzie mozna swierdzic w ktorym trzeba szukać
    // np chunki 10x10
    {
        (int x, int y) floorPos = Floor(myPos + new Vector3(0.5f, 0.5f, 0f)); 

        foreach(Transform tile in coveredParent)
        {
            (int x, int y) pos = Floor(tile.position);

            if (pos.x == floorPos.x && pos.y == floorPos.y)
            {
                return true;
            }
        }

        return false;
    }

    (int x, int y) Floor(Vector3 pos)
    {
        return (Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y));
    }

    public override void SetSprite(Sprite newSprite)
    {
        mySprite = newSprite;
    }

    public Sprite GetSprite()
    {
        return mySprite;
    }

    public Transform GetCoveredParent()
    {
        return coveredParent;
    }
}
