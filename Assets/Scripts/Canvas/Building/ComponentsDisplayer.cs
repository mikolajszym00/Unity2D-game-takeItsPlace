using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComponentsDisplayer : IconDisplayer
{
    Sprite[] sprites;
    int[] spritesQuantities;
    Inventory inventory;

    public void SetComponents(Sprite[] _sprites, int[] _spritesQuantities, Inventory _inventory)
    {
        spritesQuantities = _spritesQuantities;
        sprites = _sprites;
        inventory = _inventory;

        int i = 0;
        foreach (Sprite sprite in sprites)
        {
            GameObject elemIcon = Instantiate(elemIconPrefab, transform);
            elemIconList.Add(elemIcon);

            ElemIconHandler elemIconHandler = elemIcon.GetComponent<ElemIconHandler>();

            elemIconHandler.SetName(sprite);
            elemIconHandler.SetQuantity(spritesQuantities[i]);

            SetColor(elemIconHandler, i);
            
            i++; 
        }
    }

    public void RefreshColor()
    {
        int i = 0;
        foreach (GameObject elemIcon in elemIconList)
        {
            ElemIconHandler elemIconHandler = elemIcon.GetComponent<ElemIconHandler>();

            SetColor(elemIconHandler, i);

            i++;
        }
    }

    void SetColor(ElemIconHandler elemIconHandler, int index)
    {
        if (inventory.GetItemQuantity(sprites[index]) >= spritesQuantities[index])
        {
            elemIconHandler.ApprovedColor(true);
        } else
        {
            elemIconHandler.ApprovedColor(false);
        }
    }
}
