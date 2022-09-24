using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUpgrade : MonoBehaviour
{
    [SerializeField] BuildingProduction buildingProduction;

    UpgradePathSO myUpgradePath;
    (int, int) pathSize;

    int currLevel = 0;

    List<GameObject> usedElements = new List<GameObject>();

    Dictionary<Sprite, int> spritesInUpgradeArea = new Dictionary<Sprite, int>();
    Dictionary<Sprite, int> spritesInCurrLevel = new Dictionary<Sprite, int>();

    public void SetUpgradePath(UpgradePathSO upgradePath)
    {
        myUpgradePath = upgradePath;
    }

    public void AddElemToCurrentLevel(Sprite newSprite, GameObject elem)
    {
        usedElements.Add(elem);
        AddSpriteToDict(spritesInUpgradeArea, newSprite);

        if (myUpgradePath.CountLevels() <= currLevel) // został osiąngnięty maksymalny poziom
        { return; }

        AddSpriteToDict(spritesInCurrLevel, newSprite);

        currLevel += CheckLevelsCompleteness(currLevel);

    }

    void AddSpriteToDict(Dictionary<Sprite, int> dict, Sprite sprite)
    {
        if (dict.ContainsKey(sprite))
        {
            dict[sprite] += 1;
        } else 
        {
            dict.Add(sprite, 1);
        }
    }

    bool CheckLevelCompleteness(int level)
    {
        int[] spritesQuantities = myUpgradePath.GetSpritesQuantitiesFromLevel(level);

        int i = 0;
        foreach (Sprite levelSprite in myUpgradePath.GetSpritesFromLevel(level))
        {
            if (!(spritesInCurrLevel.ContainsKey(levelSprite) && 
                spritesInCurrLevel[levelSprite] >= spritesQuantities[i]))
            {
                return false;
            }

            i++;
        }
        
        return true;
    }

    void RemoveFromCurrentDict(int level)
    {
        int[] spritesQuantities = myUpgradePath.GetSpritesQuantitiesFromLevel(level);

        int i = 0;
        foreach (Sprite levelSprite in myUpgradePath.GetSpritesFromLevel(level))
        {
            spritesInCurrLevel[levelSprite] -= spritesQuantities[i];
            i++;
        }
    }

    public void RefreshCurrentLevel(GameObject destroyedObj, Sprite destroyedSprite)
    {
        if (!ObjectInArea(destroyedObj))
        { return; }

        RefreshCurrLevelDict(destroyedSprite);

        currLevel = CheckLevelsCompleteness(0);
    }

    bool ObjectInArea(GameObject obj)
    {
        if (usedElements.Contains(obj)) 
        {
            usedElements.Remove(obj);
            return true;
        }

        return false;
    }

    void RefreshCurrLevelDict(Sprite destroyedSprite)
    {
    
        spritesInCurrLevel.Clear();

        if (spritesInUpgradeArea[destroyedSprite] == 1) 
        {
            spritesInUpgradeArea.Remove(destroyedSprite);
        }
        else
        {
            if (spritesInUpgradeArea[destroyedSprite] == 0) { Debug.Log("Wartość nie może być 0"); }
            spritesInUpgradeArea[destroyedSprite] -= 1;
        }

        foreach (Sprite sprite in spritesInUpgradeArea.Keys)
        {
            spritesInCurrLevel.Add(sprite, spritesInUpgradeArea[sprite]);
        }
    }

    int CheckLevelsCompleteness(int start)
    {
        int completedLevels = 0;
        for (int i = start; i < myUpgradePath.CountLevels(); i++)
        {
            if (CheckLevelCompleteness(i))
            { 
                RemoveFromCurrentDict(i); 
                completedLevels += 1;
            } else 
            {
                return completedLevels;
            }
        }

        return completedLevels;
    }

    public void DisplayUpgradeWindow(UpgradeMenu upgradeMenu)
    {
        if (myUpgradePath.CountLevels() == currLevel)
        {
            upgradeMenu.DisplayMaxLevelReached();
            return;
        }

        upgradeMenu.Display(buildingProduction.buildingName, 
                            myUpgradePath.GetSpritesFromLevel(currLevel), 
                            myUpgradePath.GetSpritesQuantitiesFromLevel(currLevel),
                            spritesInCurrLevel,
                            myUpgradePath.GetSuccessFromLevel(currLevel), 
                            myUpgradePath.GetEnergyLossFromLevel(currLevel));
    }

    public void SetElementsVisability(bool state)
    {
        foreach (GameObject elem in usedElements)
        {
            elem.transform.Find("Object Highlight").gameObject.GetComponent<Interaction>().SetCircleVisability(state);
        }
    }

    public int GetUpgradeSuccess()
    {
        if (currLevel == 0)
        { return 0; }

        return myUpgradePath.GetSuccessFromLevel(currLevel - 1); // przy najwiższym poziomie currLevel jest równy ilości upgradów
    }

    public int GetUpgradeEnergyLossDecrease()
    {
        if (currLevel == 0)
        { return 0; }

        return myUpgradePath.GetEnergyLossFromLevel(currLevel - 1); 
    }
}
