using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ItemSO")]
public class ItemSO : ElemSO
{
    [SerializeField] int patience;

    public int GetPatience()
    {
        return patience;
    }
}
