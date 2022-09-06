using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonItem : ButtonElement
{
    void Start()
    {
        DisplayItem();
    }

    void DisplayItem() // przyda się do podmiany Elemu
    {
        GameObject image = transform.Find("Image").gameObject;
        // Debug.Log(image.GetType().ToString());
        image.GetComponent<Image>().sprite = myElem.GetSprite();
        // Debug.Log(image.GetComponent<Image>().GetType().ToString());

        GameObject price = transform.Find("Price").gameObject;

        GameObject humanPrc = price.transform.Find("PrayPrc").gameObject;
        
        humanPrc.GetComponent<TextMeshProUGUI>().text = myElem.GetHumanPrice().ToString();

        GameObject godPrc = price.transform.Find("GiftPrc").gameObject;
        godPrc.GetComponent<TextMeshProUGUI>().text = myElem.GetGodPrice().ToString();
    }



}
