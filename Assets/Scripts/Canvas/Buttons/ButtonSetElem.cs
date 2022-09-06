using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonSetElem : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;
    ElemSO choseElem;

    [SerializeField] GameObject turnOffWhenClick;
    [SerializeField] GameObject turnOnWhenClick;

    [SerializeField] GameObject ElemOrganizer;

    ElemCost elemCosts;

    public void OnButtonSelected (int index) 
    {
        choseElem = buttons[index].GetComponent<ButtonElement>().GetMyElem();
        
        elemCosts = buttons[index].GetComponent<ElemCost>();

        if (!elemCosts.CanBeBuilt()) { return; }

        turnOffWhenClick.SetActive(false);
        turnOnWhenClick.SetActive(true);

        ElemOrganizer.GetComponent<ElementSetter>().RunSetter(choseElem, elemCosts);
    }
}
