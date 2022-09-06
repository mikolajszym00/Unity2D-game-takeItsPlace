using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedBuilding : MonoBehaviour
{

    [SerializeField] GameObject buiCanvas;
    GameObject tradeMenu;

    bool standByTheBui = false;

    GameObject buildingObj;
    BuildingCollision building;

    [SerializeField] GameObject hero;

    void Start()
    {
        tradeMenu = buiCanvas.transform.Find("Trade Menu").gameObject;
    }

    void OnEnter()
    {
        if (!standByTheBui) { return; }


// po wyłączeniu lub trajdzie wymaga kliknięcia myszy żeby dziłało 

        DeactivateOtherInputs();
        buiCanvas.SetActive(true);

        building = buildingObj.GetComponent<BuildingCollision>();

        tradeMenu.GetComponent<TradeHandler>().InitValues(building.GetMyBuildingname(), 
                                                          building.GetMyComponent(),
                                                          building.GetMyProduct());
        tradeMenu.GetComponent<TradeHandler>().SetSlider();
    }

    public void SetStandByTheBui(bool newState)
    {
        standByTheBui = newState;
    }

    public void SetBuilding(GameObject newBuilding)
    {
        buildingObj = newBuilding;
    }

    public void DeactivateOtherInputs()
    {
        standByTheBui = false;
        hero.SetActive(false);
    }

    public void DeactivateTrade()
    {
        standByTheBui = true; 
        buiCanvas.SetActive(false);
        hero.SetActive(true);
    }

    public void OnCloseClick()
    {
        DeactivateTrade(); 
    }
}