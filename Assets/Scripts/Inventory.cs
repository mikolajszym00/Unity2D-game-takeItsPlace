using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    Dictionary<Sprite, int> ItemInventory = new Dictionary<Sprite, int>(); 


    public void AddToInventory(Sprite sprite, int value)
    {
        if (!ItemInventory.ContainsKey(sprite))
        {
            ItemInventory.Add(sprite, value);
            return;
        }

        int newValue = ItemInventory[sprite] + value;

        if (newValue <= 0)
        {
            ItemInventory.Remove(sprite);
        }
        else
        {
            ItemInventory[sprite] = newValue;
        }
    }
}
