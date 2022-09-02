using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] BoxCollider2D bc;
    [SerializeField] SpriteRenderer sr;
    
    GameObject gridManagerObj;
    GridManager gridManager;

    void Start()
    {
        GameObject container = transform.parent.gameObject;
        gridManagerObj = container.transform.parent.gameObject;
        gridManager = gridManagerObj.GetComponent<GridManager>();
    }

    public void SetCovered(Sprite mySprite, bool setParent)
    {
        transform.gameObject.tag = "CoveredTile";
        GetComponent<SpriteRenderer>().sprite = mySprite;
        DeactivateCollision();

        if (setParent) { transform.SetParent(gridManager.GetCoveredParent()); }
    }

    public void ActivateCollision() 
    {
        bc.enabled = true;
    }

    public void DeactivateCollision() 
    {
        bc.enabled = false;
    }

    public void ActivateHighlight()
    {
        sr.enabled = true;
    }

    public void DeactivateHighlight()
    {
        sr.enabled = false;
    }
}
