using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDisplayer : MonoBehaviour
{
    [SerializeField] GameObject elemIconPrefab;

    public void SetRequired(Sprite[] requiredSprites, LevelContainer accomplishedSprites)
    {
        int i = 0;
        foreach (Sprite sprite in requiredSprites)
        {
            GameObject elemIcon = Instantiate(elemIconPrefab, transform);

            GameObject elem = elemIcon.transform.Find("Elem").gameObject;
            elem.GetComponent<Image>().sprite = sprite;

            if(accomplishedSprites.GetElem(i))
            {
                elemIcon.GetComponent<Image>().color = new Color32(0, 255, 0, 100);
            } else
            {
                elemIcon.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
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
