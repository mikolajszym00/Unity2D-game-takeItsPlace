using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDisplayer : MonoBehaviour
{
    [SerializeField] GameObject elemIconPrefab;

    public void Add(Sprite sprite, int value)
    {
        GameObject elemIcon = Instantiate(elemIconPrefab, transform);

        Transform stockBG = elemIcon.transform.Find("Stock BG");
        GameObject stockText = stockBG.Find("Stock Value").gameObject;

        stockText.GetComponent<TextMeshProUGUI>().text = value.ToString();

        GameObject elem = elemIcon.transform.Find("Elem").gameObject;
        elem.GetComponent<Image>().sprite = sprite;

    }

    public void Remove(Sprite sprite)
    {
        foreach (Transform child in transform)
        {
            if (child.Find("Elem").gameObject.GetComponent<Image>().sprite == sprite)
            {
                Destroy(child.gameObject);
                break;
            }
        }
    }

    public void Set(Sprite sprite, int value) 
    {
        foreach (Transform child in transform)
        {
            if (child.Find("Elem").gameObject.GetComponent<Image>().sprite == sprite)
            {
                Transform stockBG = child.Find("Stock BG");
                GameObject stockText = stockBG.Find("Stock Value").gameObject;

                stockText.GetComponent<TextMeshProUGUI>().text = value.ToString();

                break;
            }
        }
    }
}
