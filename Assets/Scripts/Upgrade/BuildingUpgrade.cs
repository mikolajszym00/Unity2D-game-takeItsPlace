using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUpgrade : MonoBehaviour // moznaby zmienić, że upgrade posiada sprite i wymaganą ilość
// sprite który koliduje z budynkiem jest dodawany do słownika podczas sprawdzania poziomu tworzony jest słownik
// rezerwowy od którego odejmowane są wartości wymagane dla kolejnych leveli dopóki jakiś poziom nie sprawi ze bedzie ujemna ilość
{
    [SerializeField] BuildingCollision buiCollision;

    UpgradePathSO myUpgradePath;
    (int, int) pathSize;

    LevelContainer[] levels;

    int currLevel = 0;

    public void SetUpgradePath(UpgradePathSO upgradePath)
    {
        myUpgradePath = upgradePath;

        CreateEmptyLevelContainer();
    }

    public void CreateEmptyLevelContainer()
    {
        levels = new LevelContainer[myUpgradePath.CountLevels()];

        int i = 0;
        foreach (UpgradeSO upgrade in myUpgradePath.GetUpgrades())
        {
            levels[i] = ScriptableObject.CreateInstance("LevelContainer") as LevelContainer;
            levels[i].init(upgrade.GetSize());

            i++;
        }
    }

    public void AddElemToCurrentLevel(Sprite newSprite, GameObject elem)
    {
        if (levels.Length == currLevel) // został osiąngnięty maksymalny poziom
            { return; }

        int i = 0;
        foreach (Sprite levelSprite in myUpgradePath.GetSpritesFromLevel(currLevel))
        {
            if (newSprite == levelSprite)
            {

                if (!levels[currLevel].GetElem(i))
                {
                    levels[currLevel].SetElem(i, elem);

                    currLevel += CheckLevelCompleting(currLevel);

                    break;
                }
            }

            i++;
        }
    }

    public int CheckLevelCompleting(int currLevel)
    {
        int completedLevels = 0;
        for (int i = currLevel; i < levels.Length; i++)
        {
            if (levels[i].levelCompleted()) 
            {
                completedLevels++;
            } else
            {
                break;
            }
        }

        return completedLevels;
    }

    public void RefreshCurrentLevel(GameObject destroyedObj, UpgradeMenu upgradeMenu)
    {
        int i = 0;
        foreach (LevelContainer level in levels)
        {
            for (int j = 0; j < level.Length(); j++)
            {
                if (level.GetElem(j) == destroyedObj)
                {
                    level.SetElem(j, null);

                    currLevel = i;
                    return;
                }
            }
            i++;
        }
    }

    public void DisplayUpgradeWindow(UpgradeMenu upgradeMenu)
    {
        if (levels.Length == currLevel)
        {
            upgradeMenu.DisplayMaxLevelReached();
            return;
        }

        upgradeMenu.Display(buiCollision.GetMyBuildingname(), 
                            myUpgradePath.GetSpritesFromLevel(currLevel), 
                            levels[currLevel],
                            myUpgradePath.GetSuccessFromCurentLevel(currLevel), 
                            myUpgradePath.GetEnergyLossFromCurentLevel(currLevel));
    }
}
