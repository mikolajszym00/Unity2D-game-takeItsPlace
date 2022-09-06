using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodFortune : MonoBehaviour
{

    [SerializeField] int giftCoin;
    [SerializeField] int prayCoin;

    public int GetGiftCoin()
    {
        return giftCoin;
    }

    public int GetPrayCoin()
    {
        return prayCoin;
    }

    public void AddGiftCoin(int value)
    {
        giftCoin += value;
    }

    public void AddPrayCoin(int value)
    {
        prayCoin += value;
    }

}
