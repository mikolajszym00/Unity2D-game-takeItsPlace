using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElemIconButtonHandler : MonoBehaviour
{
    [SerializeField] GameObject elem;

    public void SetName(Sprite sprite) // mozna wywalic do rodzica z elem icon handler
    {
        elem.GetComponent<Image>().sprite = sprite;
    }

    public void SetFade(bool state)
    {
        if (state)
        {
            GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            elem.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        } else {
            GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            elem.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}
