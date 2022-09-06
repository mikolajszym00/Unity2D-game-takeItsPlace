using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonSetElem : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;
    ElemSO choseElem = null;

    [SerializeField] GameObject turnOffWhenClick;
    [SerializeField] GameObject turnOnWhenClick;

    [SerializeField] GameObject ElemOrganizer;

    BuildingCost buildingCost;

    public void OnButtonSelected (int index) 
    {
        choseElem = buttons[index].GetComponent<ButtonBuilding>().GetMyElem(); // błąd bo sie miesza z god mode

        buildingCost = buttons[index].GetComponent<BuildingCost>();

        if (!buildingCost.CanBeBuilt()) { return; }

        turnOffWhenClick.SetActive(false);
        turnOnWhenClick.SetActive(true);

        buildingCost.PayForBuilding();

        ElemOrganizer.GetComponent<ElementSetter>().RunSetter(choseElem);
    }
}
