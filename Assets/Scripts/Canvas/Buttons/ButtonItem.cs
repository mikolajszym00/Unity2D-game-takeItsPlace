using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonItem : ButtonElement
{
    [SerializeField] GodElemSO godElem;

    [SerializeField] GameObject giftPrc;
    [SerializeField] GameObject prayPrc;

    void Start()
    {
        DisplayElem();
    }

    void DisplayElem()
    {
        Transform image = transform.Find("Image");

        float size = godElem.GetIconSize();
        image.localScale = new Vector3(size, size, size);

        image.gameObject.GetComponent<Image>().sprite = godElem.GetSprite();
        
        giftPrc.GetComponent<TextMeshProUGUI>().text = godElem.GetGiftPrice().ToString();
        prayPrc.GetComponent<TextMeshProUGUI>().text = godElem.GetPrayPrice().ToString();
    }

    public override ElemSO GetMyElem() 
    {
        return godElem;
    }
}
