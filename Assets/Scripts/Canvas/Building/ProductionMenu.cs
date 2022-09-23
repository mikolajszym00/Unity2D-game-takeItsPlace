using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionMenu : Menu
{    
    [SerializeField] ComponentsDisplayer componentsDisplayer;
    [SerializeField] ProductsDisplayer productsDisplayer;
    
    [SerializeField] Inventory inventory;

    Sprite[] components;
    int[] componentsQuantities;
    Sprite[] products;

    public void Display(String buildingName, Sprite[] _components, int[] _componentsQuantities, Sprite[] _products)
    {
        // buildingname = _buildingname;
        components = _components;
        componentsQuantities = _componentsQuantities;
        products =_products;

        SetName(buildingName);

        componentsDisplayer.SetComponents(components, componentsQuantities, inventory);
        productsDisplayer.SetProducts(products);
    }

    public void OnProduceClick() //zmienić kolory produktow
    {
        if (!CanAffordTo()) { return; }

        PayForProducts();
        GetProducts();
    }

    bool CanAffordTo()
    {
        // sprawdz czy ma energię

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

        // odbierz energię
    }

    void GetProducts()
    {
        int i = 0;
        foreach (Sprite product in products)
        {
            inventory.AddToInventory(product, 1); // dodać p-stwo niepowodzenia

            i++;
        }
    }

    public void ClearProduction()
    {
        componentsDisplayer.DestroyIcons();
        productsDisplayer.DestroyIcons();
    }
}
