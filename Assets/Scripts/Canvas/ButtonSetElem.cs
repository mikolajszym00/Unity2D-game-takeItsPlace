using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonSetElem : MonoBehaviour
{
    [SerializeField] ButtonItem[] buttons;
    ItemSO choseItem = null;

    [SerializeField] GameObject ItemOrganizer;

    public void OnButtonSelected (int index) 
    {
        gameObject.SetActive(false);

        // jeśli cię stać czyli jeśli kolor jest zielony
        choseItem = buttons[index].GetMyItem();
        ItemOrganizer.GetComponent<ElementSetter>().RunSetter(choseItem);
    }
}
