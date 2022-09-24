using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTrade : BuildingFeature
{
    [SerializeField] ItemSO[] items;

    public Dictionary<Sprite, ItemSO> itemsDict = new Dictionary<Sprite, ItemSO>();

    void Start() 
    {
        foreach (ItemSO item in items)
        {
            itemsDict.Add(item.GetSprite(), item);
        }
    }
}
