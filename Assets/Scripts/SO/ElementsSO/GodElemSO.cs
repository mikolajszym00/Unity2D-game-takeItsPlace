using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GodElem", menuName = "GodElemSO")]
public class GodElemSO : ElemSO
{
    [SerializeField] int giftPrice;
    [SerializeField] int prayPrice;

    [SerializeField] float iconSize;

    public int GetGiftPrice()
    {
        return giftPrice;
    }

    public int GetPrayPrice()
    {
        return prayPrice;
    }

    public float GetIconSize()
    {
        return iconSize;
    }
}
