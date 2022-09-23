using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComponentsDisplayer : IconDisplayer
{
    public void SetComponents(Sprite[] sprites, int[] spritesQuantities, Inventory inventory)
    {
        int i = 0;
        foreach (Sprite sprite in sprites)
        {
            GameObject elemIcon = Instantiate(elemIconPrefab, transform);
            ElemIconHandler elemIconHandler = elemIcon.GetComponent<ElemIconHandler>();

            elemIconHandler.SetName(sprite);
            elemIconHandler.SetQuantity(spritesQuantities[i]);

            if (inventory.GetItemQuantity(sprite) >= spritesQuantities[i])
            {
                elemIconHandler.ApprovedColor(true);
            } else
            {
                elemIconHandler.ApprovedColor(false);
            }
            
            i++; 
        }
    }




}
