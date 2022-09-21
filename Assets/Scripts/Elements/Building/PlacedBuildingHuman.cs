using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedBuildingHuman : MonoBehaviour
// human interaction with building
{
    [SerializeField] GameObject humanMode;

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
        if (!(standByTheBui && humanMode.activeSelf)) { return; }

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

    public void checkDowngrades(Vector3 mousePos) 
    {
        foreach (Transform building in transform)
        {
            if (building.Find("Object Upgrade Area").gameObject.GetComponent<CircleCollider2D>().bounds.Contains(mousePos))
            {
                building.gameObject.GetComponent<BuildingUpgrade>().RefreshCurrentLevel();
            }
        }
    }
}