using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ItemSO")]
public class ItemSO : ScriptableObject 
{
    [SerializeField] bool isItem;

    [SerializeField] GameObject prefabFeatures;
    [SerializeField] GameObject setPointerTemplate;
    [SerializeField] GameObject manager;

    [SerializeField] Sprite mySprite;
    [SerializeField] int godPrice;
    [SerializeField] int humanPrice;

    [SerializeField] float objectBoundariesRadius;

    public bool IsItem()
    {
        return isItem;
    }
    
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

    public GameObject GetPrefabFeatures()
    {
        prefabFeatures.GetComponent<SpriteRenderer>().sprite = mySprite;
        return prefabFeatures;
    }

    public GameObject GetSetPointerTemplate() 
    {
        return setPointerTemplate;
    }

    public float GetObjectBoundariesRadius()
    {
        return objectBoundariesRadius;
    }

    public GameObject GetManager()
    {
        return manager;
    }
}
