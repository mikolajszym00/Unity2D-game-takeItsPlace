using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Dictionary<Sprite, int> ItemInventory = new Dictionary<Sprite, int>(); 

    [SerializeField] GameObject invUIObj;
    InventoryDisplayer invDisplayer;

    void Start()
    {
        invDisplayer = invUIObj.GetComponent<InventoryDisplayer>();
    }

    public void AddToInventory(Sprite sprite, int value)
    {
        if (value == 0) { return; }

        if (!ItemInventory.ContainsKey(sprite))
        {
            ItemInventory.Add(sprite, value);
            invDisplayer.Add(sprite, value);

            return;
        }

        int newValue = ItemInventory[sprite] + value;

        if (newValue <= 0)
        {
            ItemInventory.Remove(sprite);
            invDisplayer.Remove(sprite);
        }
        else
        {
            ItemInventory[sprite] = Math.Min(newValue, 100);
            invDisplayer.Set(sprite, Math.Min(newValue, 100));
        }
    }

    public int GetItemQuantity(Sprite sprite)
    {
        // return 100; //debug mode

        if (!ItemInventory.ContainsKey(sprite))
        {
            return 0;
        }

        return ItemInventory[sprite];
    }

    public Dictionary<Sprite, int> GetInventory()
    {
        return ItemInventory;
    }
}
