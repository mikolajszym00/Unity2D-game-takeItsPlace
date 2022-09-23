using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "upgradePath", menuName = "upgradePathSO")]
public class UpgradePathSO : ScriptableObject
{
    [SerializeField] UpgradeSO[] upgrades; 

    public int CountLevels()
    {
        return upgrades.Length;
    }

    public UpgradeSO[] GetUpgrades()
    {
        return upgrades;
    }

    public Sprite[] GetSpritesFromLevel(int index)
    {
        return upgrades[index].GetSprites();
    }

    public int[] GetSpritesQuantitiesFromLevel(int index)
    {
        return upgrades[index].GetSpritesQuantities();
    }

    public int GetSuccessFromCurentLevel(int index)
    {
        return upgrades[index].GetSuccess();
    }

    public int GetEnergyLossFromCurentLevel(int index)
    {
        return upgrades[index].GetEnergyLoss();
    }

}
