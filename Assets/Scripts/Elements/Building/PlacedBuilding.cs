using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedBuilding : MonoBehaviour
{
    bool standByTheBui = false;

    GameObject building;
    [SerializeField] GameObject hero;

    void OnEnter()
    {
        if (standByTheBui)
        {
            building.GetComponent<BuildingCollision>().OpenBuiMenu();
        }
    }

    public void SetStandByTheBui(bool newState)
    {
        standByTheBui = newState;
    }

    public void SetBuilding(GameObject newBuilding)
    {
        building = newBuilding;
    }

    public void DeactivateOtherInputs()
    {
        standByTheBui = false;
        hero.SetActive(false);
    }
}