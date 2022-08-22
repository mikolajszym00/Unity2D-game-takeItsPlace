using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] ButtonItem[] buttons;
    ItemSO choseItem = null;

    [SerializeField] GameObject ItemOrganizer;

    public void OnButtonSelected (int index) 
    {
        // jeśli cię stać czyli jeśli kolor jest zielony
        choseItem = buttons[index].GetMyItem();
        ItemOrganizer.GetComponent<ItemSetter>().CreateSetPointer(choseItem);

                // Button.interactable = false; // trzeba wyłączyć guziki
    }
}
