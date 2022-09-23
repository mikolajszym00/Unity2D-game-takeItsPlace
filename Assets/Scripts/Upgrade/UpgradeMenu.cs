using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] UpgradeDisplayer upgradeDisplayer;

    [SerializeField] GameObject successObj;
    [SerializeField] GameObject successValue;

    [SerializeField] GameObject energyLossObj;
    [SerializeField] GameObject energyLossValue;

    public void Display(String buildingName, 
                        Sprite[] requiredSprites, 
                        int[] spritesQuantities, 
                        Dictionary<Sprite, int> spritesInCurrLevel, 
                        int success, 
                        int energyLoss)
    {
        SetName(buildingName);
        upgradeDisplayer.SetRequired(requiredSprites, spritesQuantities, spritesInCurrLevel);
        SetBenefits(success, energyLoss);
    }

    public void DisplayMaxLevelReached()
    {
        SetName("Max Level");
    }

    void SetName(string buildingName)
    {
        transform.Find("Name").GetComponent<TextMeshProUGUI>().text = buildingName;
    }

    void SetBenefits(int success, int energyLoss)
    {
        if (success == 0) 
        {
            successObj.SetActive(false); // trzeba włączyć podczas zamykania
        } else 
        {
            successValue.GetComponent<TextMeshProUGUI>().text = success.ToString() + "%";
        }

        if (energyLoss == 0) 
        {
            energyLossObj.SetActive(false); // trzeba włączyć podczas zamykania
        } else 
        {
            energyLossValue.GetComponent<TextMeshProUGUI>().text = energyLoss.ToString();
        }
    }

    public GameObject GetSuccessObj()
    {
        return successObj;
    }

    public GameObject GetEnergyLossObj()
    {
        return energyLossObj;
    }

    public UpgradeDisplayer GetUpgradeDisplayer()
    {
        return upgradeDisplayer;
    }
}
