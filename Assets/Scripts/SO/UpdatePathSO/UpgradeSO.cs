using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "upgrade", menuName = "UpgradeSO")]
public class UpgradeSO : ScriptableObject
{
    [SerializeField] Sprite[] sprites; 
    [SerializeField] int energyLossDecrease;
    [SerializeField] int probPercentageIncrease;

    public Sprite[] GetSprites()
    {
        return sprites;
    }

    public int GetSize()
    {
        return sprites.Length;
    }
}
