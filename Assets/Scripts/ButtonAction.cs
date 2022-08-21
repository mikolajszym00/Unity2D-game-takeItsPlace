using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] ButtonItem[] buttons;
    ItemSO choseItem = null;

    [SerializeField] GameObject ItemContainer;

    public void OnButtonSelected (int index) 
    {
        // jeśli cię stać czyli jeśli kolor jest zielony
        choseItem = buttons[index].GetMyItem();
        ItemContainer.GetComponent<ItemHolder>().CreateHoldingItem(choseItem);
    }
}
