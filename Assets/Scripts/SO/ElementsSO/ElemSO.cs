using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElemSO : ScriptableObject
{
    [SerializeField] String type;
    [SerializeField] Sprite sprite;
    [SerializeField] GameObject prefabObj;

    public String GetElemType()
    {
        return type;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public GameObject GetPrefabObj()
    {
        return prefabObj;
    }
}
