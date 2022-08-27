using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpCollision : BuildingCollision
{
    [SerializeField] Sprite component;
    [SerializeField] Sprite product;
    [SerializeField] String buildingname;

    protected override void Start()
    {
        base.Start();

        tradeMenu = buiCanvas.Find("Trade Menu").gameObject;
        tradeMenu.GetComponent<StumpTradeHandler>().InitValues(buildingname, component, product); // zmienic na tradeHandler
    }
}
