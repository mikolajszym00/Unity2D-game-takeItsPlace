using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject highlight;
    // bool isMouseOver = false;
    [SerializeField] bool isCovered = false;
    
    GameObject gridManagerObj;
    GridManager gridManager;

    void Start()
    {
        GameObject container = transform.parent.gameObject;
        gridManagerObj = container.transform.parent.gameObject;
        gridManager = gridManagerObj.GetComponent<GridManager>();
    }

    // void OnMouseDown() // moze byc nieoptmalne, działa dla zwykłych też
    // {
    //     SetCovered(gridManager.GetSprite(), true);

    //     Vector3 pos = transform.position;

    //     int x = Mathf.FloorToInt(pos.x);
    //     int y = Mathf.FloorToInt(pos.y);

    //     gridManager.CreateBareTiles(x, y);

    //     gridManager.DeactivateBare();
    // }

    public void SetCovered(Sprite mySprite, bool setParent)
    {
        transform.gameObject.tag = "CoveredTile";
        GetComponent<SpriteRenderer>().sprite = mySprite;

        if (setParent) { transform.SetParent(gridManager.GetCoveredParent()); }
    }


    // void OnMouseEnter() 
    // {
    //     Debug.Log("tile ma mysz");

    //     // sprawdzić czy moze byc położona, jeśli tak podkreśl
    //     highlight.SetActive(true);  
    //     // isMouseOver = true;
    //     GameObject container = transform.parent.gameObject;

    //     GameObject gridManager = container.transform.parent.gameObject;
    //     gridManager.GetComponent<GridManager>().SetTileWithMouse(this);
    // }

    // void OnMouseExit() 
    // {
    //     Debug.Log("tile nie ma mysz");
    //     highlight.SetActive(false);   
    //     // isMouseOver = false; 
    // }

    public bool IsCovered()
    {
        return isCovered;
    }
}
