using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingCollision : MonoBehaviour
{
    [SerializeField] protected BuildingUpgrade buildingUpgrade;

    protected GameObject buildingCont;
    protected PlacedBuildingHuman placedBuilding;

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
}
