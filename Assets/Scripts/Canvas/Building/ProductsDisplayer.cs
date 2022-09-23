using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductsDisplayer : IconDisplayer
{
    public void SetProducts(Sprite[] sprites)
    {
        int i = 0;
        foreach (Sprite sprite in sprites)
        {
            GameObject elemIcon = Instantiate(elemIconPrefab, transform);
            ElemIconHandler elemIconHandler = elemIcon.GetComponent<ElemIconHandler>();

            elemIconHandler.SetName(sprite);
            elemIconHandler.SetQuantity(1);
            // dodać success
            
            i++; 
        }
    }
}
