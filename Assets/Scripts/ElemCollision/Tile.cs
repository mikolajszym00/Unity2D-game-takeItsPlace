using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] BoxCollider2D bc;
    
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
        DeactivateBoxCollider();

        if (setParent) { transform.SetParent(gridManager.GetCoveredParent()); }
    }

    public void ActivateBoxCollider() 
    {
        bc.enabled = true;
    }

    public void DeactivateBoxCollider() 
    {
        bc.enabled = false;
    }
}
