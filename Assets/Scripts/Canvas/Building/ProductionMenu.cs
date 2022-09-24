using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductionMenu : HumanMenu
{    
    [SerializeField] HeroVitality vitality;

    [SerializeField] GameObject successValue;
    [SerializeField] GameObject energyCostValue;

    [SerializeField] ComponentsDisplayer componentsDisplayer;
    [SerializeField] ProductsDisplayer productsDisplayer;

    Sprite[] components;
    int[] componentsQuantities;
    Sprite[] products;

    int success;
    int energyCost;

    System.Random random = new System.Random();

    public override void Display(BuildingFeature buildingFeature, BuildingUpgrade buildingUpgrade)
    {
        BuildingProduction buildingProduction = (BuildingProduction)buildingFeature;

        components = buildingProduction.components;
        componentsQuantities = buildingProduction.componentsQuantities;
        products = buildingProduction.products;

        SetName(buildingProduction.buildingName);

        success = SetSuccess(buildingProduction.baseSuccess + buildingUpgrade.GetUpgradeSuccess());
        energyCost = SetEnergyCost(buildingProduction.baseEnergyCost - buildingUpgrade.GetUpgradeEnergyLossDecrease());

        componentsDisplayer.SetComponents(components, componentsQuantities, inventory);
        productsDisplayer.SetProducts(products);
    }

    int SetSuccess(int success)
    {
        successValue.GetComponent<TextMeshProUGUI>().text = "Success: " + success.ToString() + "%";
        
        return success;
    }

    int SetEnergyCost(int energyCost)
    {
        energyCostValue.GetComponent<TextMeshProUGUI>().text = "Energy: " + energyCost.ToString();

        return energyCost;
    }

    public void OnProduceClick()
    {
        componentsDisplayer.RefreshColor();
        if (!CanAffordTo()) { return; }

        PayForProducts();
        GetProducts();
    }

    bool CanAffordTo()
    {
        if ((float)energyCost > vitality.GetEnergy())
            { return false; } // jesli brak energii mogłaby zapulsować ikona energii

        int i = 0;
        foreach (Sprite component in components)
        {
            if (inventory.GetItemQuantity(component) < componentsQuantities[i])
            {
                return false;
            }

            i++;
        }

        return true;
    }

    void PayForProducts()
    {
        int i = 0;
        foreach (Sprite component in components)
        {
            inventory.AddToInventory(component, -componentsQuantities[i]);

            i++;
        }

        vitality.ChangeEnergy(-(float)energyCost);
    }

    void GetProducts()
    {
        int i = 0;
        foreach (Sprite product in products)
        {
            if (random.Next(0,100) < success) 
            {
                inventory.AddToInventory(product, 1);
                productsDisplayer.BlinkApprovedColor(true);
            } else {
                productsDisplayer.BlinkApprovedColor(false);
            }
            

            i++;
        }
    }

    public override void ClearProduction()
    {
        componentsDisplayer.DestroyIcons();
        productsDisplayer.DestroyIcons();
    }
}
