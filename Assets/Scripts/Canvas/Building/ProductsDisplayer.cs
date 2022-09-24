using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductsDisplayer : IconDisplayer
{
    public void SetProducts(Sprite[] sprites)
    {
        foreach (Sprite sprite in sprites)
        {
            GameObject elemIcon = Instantiate(elemIconPrefab, transform);
            elemIconList.Add(elemIcon);

            ElemIconHandler elemIconHandler = elemIcon.GetComponent<ElemIconHandler>();

            elemIconHandler.SetName(sprite);
            elemIconHandler.SetQuantity(1);
        }
    }

    public void BlinkApprovedColor(bool state)
    {
        foreach (GameObject elemIcon in elemIconList)
        {
            ElemIconHandler elemIconHandler = elemIcon.GetComponent<ElemIconHandler>();

            elemIconHandler.ApprovedColor(state); // trzeba dodać blinking
        }
    }
}
