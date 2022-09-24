using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedBuildingHuman : MonoBehaviour
// human interaction with building
{
    [SerializeField] GameObject humanMode;

    [SerializeField] GameObject buiCanvas;
    [SerializeField] ProductionMenu productionMenu;

    bool standByTheBui = false;

    GameObject buildingObj;
    // BuildingProduction buildingProduction;

    [SerializeField] UpgradeMenu upgradeMenu;

    [SerializeField] GameObject hero;

    void OnEnter()
    {
        if (!(standByTheBui && humanMode.activeSelf)) { return; }

        // po wyłączeniu lub trajdzie wymaga kliknięcia myszy żeby dziłało 

        DeactivateOtherInputs();

        productionMenu.Display(buildingObj.GetComponent<BuildingProduction>(), buildingObj.GetComponent<BuildingUpgrade>());

        buiCanvas.SetActive(true);
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

    public void OnCloseClick()
    {
        standByTheBui = true; 
        buiCanvas.SetActive(false);
        hero.SetActive(true);

        productionMenu.ClearProduction();
    }

    public void checkDowngrades(GameObject destroyedObj, Sprite destroyedSprite, Vector3 mousePos) 
    {
        foreach (Transform building in transform)
        {
            if (building.Find("Object Upgrade Area").gameObject.GetComponent<CircleCollider2D>().bounds.Contains(mousePos))
            {
                building.gameObject.GetComponent<BuildingUpgrade>().RefreshCurrentLevel(destroyedObj, destroyedSprite);
            }
        }
    }
}