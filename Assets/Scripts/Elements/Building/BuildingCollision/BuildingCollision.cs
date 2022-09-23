using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingCollision : MonoBehaviour
{
    [SerializeField] protected Sprite[] component;
    [SerializeField] protected Sprite[] product;
    [SerializeField] protected String buildingname;

    [SerializeField] protected BuildingUpgrade buildingUpgrade;

    protected GameObject buildingCont;
    protected PlacedBuildingHuman placedBuilding;

    protected GameObject tradeMenu;

    protected virtual void Start()
    {
        buildingCont = transform.parent.gameObject;
        placedBuilding = buildingCont.GetComponent<PlacedBuildingHuman>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            placedBuilding.SetStandByTheBui(true);
            placedBuilding.SetBuilding(gameObject);

            buildingUpgrade.SetElementsVisability(true);
        }
    }
    
    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            placedBuilding.SetStandByTheBui(false);

            buildingUpgrade.SetElementsVisability(false);
        }
    }

    public Sprite[] GetMyComponent()
    {
        return component;
    }

    public Sprite[] GetMyProduct()
    {
        return product;
    }

    public String GetMyBuildingname()
    {
        return buildingname;
    }
}
