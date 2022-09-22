using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingCollision : MonoBehaviour
{
    [SerializeField] protected Sprite[] component;
    [SerializeField] protected Sprite[] product;
    [SerializeField] protected String buildingname;

    [SerializeField] protected GameObject upgradeArea;
    Interaction interaction;

    protected GameObject buildingCont;
    protected PlacedBuildingHuman placedBuilding;

    protected GameObject tradeMenu;

    protected virtual void Start()
    {
        buildingCont = transform.parent.gameObject;
        placedBuilding = buildingCont.GetComponent<PlacedBuildingHuman>();

        interaction = upgradeArea.GetComponent<Interaction>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            placedBuilding.SetStandByTheBui(true);
            placedBuilding.SetBuilding(gameObject);

            interaction.SetCircleVisability(true); //tu odwołać się do building upgrade i przeiterować wszystkie
            // elementy które należą do upgradu i włączyć ich widoczność. Nie włączać widoczności dużego koła (bo po co)
        }
    }
    
    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            placedBuilding.SetStandByTheBui(false);

            interaction.SetCircleVisability(false);
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
