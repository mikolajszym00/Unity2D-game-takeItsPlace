using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonItem : MonoBehaviour
{
    [SerializeField] ItemSO myItem;

    void Start()
    {
        DisplayItem();
    }

    public void SetMyItem(ItemSO newItem) {
        myItem = newItem;
    }

    public ItemSO GetMyItem() {
        return myItem;
    }


    void DisplayItem() // przyda się do podmiany itemu
    {
        GameObject image = transform.Find("Image").gameObject;
        // Debug.Log(image.GetType().ToString());
        image.GetComponent<Image>().sprite = myItem.GetSprite();
        // Debug.Log(image.GetComponent<Image>().GetType().ToString());

        GameObject price = transform.Find("Price").gameObject;

        GameObject humanPrc = price.transform.Find("HumanPrc").gameObject;

        TextMeshProUGUI textt = humanPrc.GetComponent<TextMeshProUGUI>();
        humanPrc.GetComponent<TextMeshProUGUI>().text = myItem.GetHumanPrice().ToString();

        GameObject godPrc = price.transform.Find("GodPrc").gameObject;
        godPrc.GetComponent<TextMeshProUGUI>().text = myItem.GetGodPrice().ToString();
    }



}
