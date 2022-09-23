using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingProduction : MonoBehaviour
{
    [SerializeField] Sprite[] component;
    [SerializeField] int[] componentsQuantities;
    [SerializeField] Sprite[] product;
    [SerializeField] String buildingname;

    public Sprite[] GetMyComponents()
    {
        return component;
    }

    public int[] GetMyComponentsQuantities()
    {
        return componentsQuantities;
    }

    public Sprite[] GetMyProducts()
    {
        return product;
    }

    public String GetMyBuildingname()
    {
        return buildingname;
    }
}
