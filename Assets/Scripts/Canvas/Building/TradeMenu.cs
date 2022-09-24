using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeMenu : HumanMenu
{
    [SerializeField] ButtonInventoryDisplayer buttonInventoryDisplayer;

    public override void Display(BuildingFeature buildingFeature, BuildingUpgrade buildingUpgrade)
    {
        BuildingTrade buildingTrade = (BuildingTrade)buildingFeature;

        SetName(buildingTrade.buildingName);

        buttonInventoryDisplayer.SetInventory(buildingTrade.itemsDict, inventory);

        InitBenefits();
    }

    public void InitBenefits() //wszystko ma być na 0
    {

    }

    public void OnTradeClick()
    {

    }

    public void OnItemClick() // beedzie kłopot bo button trzeba połączyć przez kod
    {

    }

    public override void ClearProduction()
    {

    }
}
