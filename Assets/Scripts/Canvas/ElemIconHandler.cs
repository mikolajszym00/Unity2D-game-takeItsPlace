using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElemIconHandler : MonoBehaviour
{
    [SerializeField] GameObject stockValue;
    [SerializeField] GameObject stockBG;

    public void SetName(Sprite sprite)
    {
        transform.Find("Elem").gameObject.GetComponent<Image>().sprite = sprite;
    }

    public void SetQuantity(int quantity)
    {
        if (quantity == 1) 
        {
            stockBG.SetActive(false);
        } else 
        {
            stockValue.GetComponent<TextMeshProUGUI>().text = quantity.ToString();
        }
    }

    public void ApprovedColor(bool isApproved)
    {
        if (isApproved) 
        {
            GetComponent<Image>().color = new Color32(0, 255, 0, 100);
        } else
        {
            GetComponent<Image>().color = new Color32(255, 0, 0, 100);
        }
    }
}
