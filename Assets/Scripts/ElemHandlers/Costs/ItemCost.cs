using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCost : ElemCost
{
    [SerializeField] GameObject fortuneObj;
    GodFortune fortune;

    [SerializeField] GameObject giftCoinObj;
    int giftPrice;

    [SerializeField] GameObject prayCoinObj;
    int prayPrice;

    void Start()
    {
        fortune = fortuneObj.GetComponent<GodFortune>();
    }

    public override bool CanBeBuilt()
    {
        giftPrice = int.Parse(giftCoinObj.GetComponent<TextMeshProUGUI>().text);
        prayPrice = int.Parse(prayCoinObj.GetComponent<TextMeshProUGUI>().text);

        if(fortune.GetGiftCoin() >=  giftPrice && fortune.GetPrayCoin() >= prayPrice)
        {
            return true;
        }

        return false;
    }

    public override void PayForElem()
    {
        fortune.AddGiftCoin(-giftPrice);
        fortune.AddPrayCoin(-prayPrice);
    }
}
