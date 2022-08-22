using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject highlight;
    // bool isMouseOver = false;
    [SerializeField] bool isCovered = false;

    void Start()
    {
        // GetComponent<PlayerInput>().DeactivateInput(s); // trzeba sworzyć player input
    }

    void OnMouseEnter() 
    {
        Debug.Log("tile ma mysz");

        // sprawdzić czy moze byc położona, jeśli tak podkreśl
        highlight.SetActive(true);  
        // isMouseOver = true;
        GameObject container = transform.parent.gameObject;

        GameObject gridManager = container.transform.parent.gameObject;
        gridManager.GetComponent<GridManager>().SetTileWithMouse(this);
    }

    void OnMouseExit() 
    {
        Debug.Log("tile nie ma mysz");
        highlight.SetActive(false);   
        // isMouseOver = false; 
    }

    public bool IsCovered()
    {
        return isCovered;
    }
}
