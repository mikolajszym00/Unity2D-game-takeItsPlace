using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUpgrade : MonoBehaviour
{
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
        if(levels.Length == currLevel) // został osiąngnięty maksymalny poziom
            { return; }

        int i = 0;
        foreach (Sprite levelSprite in myUpgradePath.GetSpritesFromCurentLevel(currLevel))
        {
            if (newSprite == levelSprite)
            {

                if (!levels[currLevel].GetElem(i))
                {
                    levels[currLevel].SetElem(i, elem);

                    if (levels[currLevel].levelCompleted())
                    {
                        currLevel++;
                        Debug.Log(currLevel);
                        Debug.Log(gameObject);
                        // trzeba to jeszcze zdispleyowac lub dopiero po zmianie na człowika lub po
                        // kliknięciu budynku
                    }

                    break;
                }
            }

            i++;
        }
    }

    public void RefreshCurrentLevel() // funkcja bedzie kazała odsiwieżyć display
    {
        // trzeba przeiterować wsztkei levele i spradzić który jest najwyższy
    }
}
