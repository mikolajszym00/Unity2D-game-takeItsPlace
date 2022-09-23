using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDisplayer : IconDisplayer
{
    public void SetRequired(Sprite[] requiredSprites, int[] spritesQuantities, Dictionary<Sprite, int> spritesInCurrLevel)
    {
        int i = 0;
        foreach (Sprite sprite in requiredSprites)
        {
            for (int j = 0; j < spritesQuantities[i]; j++)
            {
                GameObject elemIcon = Instantiate(elemIconPrefab, transform);
                ElemIconHandler elemIconHandler = elemIcon.GetComponent<ElemIconHandler>();


                elemIconHandler.SetName(sprite);
                elemIconHandler.SetQuantity(1);

                if (spritesInCurrLevel.ContainsKey(sprite) && spritesInCurrLevel[sprite] >= 1 + j)
                {
                    elemIconHandler.ApprovedColor(true);
                } else
                {
                    elemIconHandler.ApprovedColor(false);
                }
            }
            i++;
        }
    }
}
