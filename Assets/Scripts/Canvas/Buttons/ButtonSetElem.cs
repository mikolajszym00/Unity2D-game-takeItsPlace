using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonSetElem : MonoBehaviour
{
    [SerializeField] ButtonElement[] buttons;
    ElemSO choseElem = null;

    [SerializeField] GameObject turnOffWhenClick;
    [SerializeField] GameObject turnOnWhenClick;

    [SerializeField] GameObject ElemOrganizer;

    public void OnButtonSelected (int index) 
    {
        turnOffWhenClick.SetActive(false);
        turnOnWhenClick.SetActive(true);

        // jeśli cię stać czyli jeśli kolor jest zielony
        choseElem = buttons[index].GetMyElem();
        ElemOrganizer.GetComponent<ElementSetter>().RunSetter(choseElem);
    }
}
