using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDisplayer : MonoBehaviour
{
    [SerializeField] GameObject elemIconPrefab;

    public void SetRequired(Sprite[] requiredSprites, int[] spritesQuantities, Dictionary<Sprite, int> spritesInCurrLevel)
    {
        int i = 0;
        foreach (Sprite sprite in requiredSprites)
        {
            for (int j = 0; j < spritesQuantities[i]; j++)
            {
                GameObject elemIcon = Instantiate(elemIconPrefab, transform);

                GameObject elem = elemIcon.transform.Find("Elem").gameObject;
                elem.GetComponent<Image>().sprite = sprite;

                if (spritesInCurrLevel.ContainsKey(sprite) && spritesInCurrLevel[sprite] >= 1 + j)
                {
                    elemIcon.GetComponent<Image>().color = new Color32(0, 255, 0, 100);
                } else
                {
                    elemIcon.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
                }
            }
            i++;
        }
    }

    public void DestroyRequired()
    {
        foreach (Transform icon in transform)
        {
            Destroy(icon.gameObject);
        }
    }
}
