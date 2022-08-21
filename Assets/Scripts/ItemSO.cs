using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ItemSO")]
public class ItemSO : ScriptableObject 
{
    [SerializeField] Sprite mySprite;
    [SerializeField] int godPrice;
    [SerializeField] int humanPrice;

    public Sprite GetSprite()
    {
        return mySprite;
    }

    public int GetGodPrice()
    {
        return godPrice;
    }

    public int GetHumanPrice()
    {
        return humanPrice;
    }
}
