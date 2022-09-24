using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInventoryDisplayer : IconDisplayer
{
    public void SetInventory(Dictionary<Sprite, ItemSO> itemsDict, Inventory inventory)
    {
        Dictionary<Sprite, int> inventoryDict = inventory.GetInventory();
        foreach (Sprite sprite in inventoryDict.Keys)
        {
            GameObject elemIcon = Instantiate(elemIconPrefab, transform);
            elemIconList.Add(elemIcon);

            ElemIconButtonHandler elemIconButtonHandler = elemIcon.GetComponent<ElemIconButtonHandler>(); //trzeba jeszcze dodać na co ma
            // reagować button

            elemIconButtonHandler.SetName(sprite);
            elemIconButtonHandler.SetFade(true);
        }
    }
}
