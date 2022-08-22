using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ItemSO")]
public class ItemSO : ScriptableObject 
{
    [SerializeField] bool isGround;

    [SerializeField] GameObject prefabFeatures;
    [SerializeField] GameObject setPointerTemplate;

    [SerializeField] Sprite mySprite;
    [SerializeField] int godPrice;
    [SerializeField] int humanPrice;

    [SerializeField] float objectBoundariesRadius;

    public bool IsGround()
    {
        return isGround;
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
}
