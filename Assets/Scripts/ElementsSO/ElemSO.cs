using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElemSO : ScriptableObject
{
    [SerializeField] int godPrice;
    [SerializeField] int humanPrice;
    [SerializeField] Sprite mySprite; // do usunięcia

    [SerializeField] GameObject prefabObj;

    [SerializeField] bool isItem;

    public int GetGodPrice()
    {
        return godPrice;
    }

    public int GetHumanPrice()
    {
        return humanPrice;
    }

    public bool IsItem()
    {
        return isItem;
    }

    public Sprite GetSprite()
    {
        return mySprite;
    }

    public GameObject GetPrefabObj()
    {
        return prefabObj;
    }



}
