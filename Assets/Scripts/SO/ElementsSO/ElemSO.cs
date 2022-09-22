using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElemSO : ScriptableObject
{
    [SerializeField] int godPrice;
    [SerializeField] int humanPrice;
    [SerializeField] Sprite mySprite; // do usunięcia

    [SerializeField] GameObject prefabObj;

    [SerializeField] String type;

    public int GetGodPrice()
    {
        return godPrice;
    }

    public int GetHumanPrice()
    {
        return humanPrice;
    }

    public String GetElemType()
    {
        return type;
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
