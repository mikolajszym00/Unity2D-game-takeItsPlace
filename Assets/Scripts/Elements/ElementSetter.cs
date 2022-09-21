using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ElementSetter : MonoBehaviour
{
    [SerializeField] GameObject buttonPanel;

    ElemSO myElem;
    ElemCost elemCosts;

    [SerializeField] Functions func;

    [SerializeField] ElementManager itemManager;
    [SerializeField] ElementManager tileManager;
    [SerializeField] ElementManager buildingManager;

    ElementManager manager;

    [SerializeField] GameObject buildingContainer;
    PlacedBuildingGod placedBuildingGod;

    void Start()
    {
        GetComponent<PlayerInput>().DeactivateInput();
        placedBuildingGod = buildingContainer.GetComponent<PlacedBuildingGod>();
    }
    
    public void RunSetter(ElemSO elem, ElemCost elemCost)
    {
        myElem = elem;
        elemCosts = elemCost;

        GetComponent<PlayerInput>().ActivateInput();

        if (elem.GetElemType() == "item") { manager = itemManager; } // bardzo bardzo złe
        else 
            if (elem.GetElemType() == "tile") { manager = tileManager; }
            else { manager = buildingManager; }
            
        manager.prepare(elem);
        manager.SetSprite(elem.GetSprite());
   }

    void OnSet()
    {
        if (!elemCosts.CanBeBuilt()) { return; }

        Vector3 mousePos = GetMousePos();

        GameObject settedElem = manager.MouseClickHandler(mousePos);
        if (settedElem) 
        {
            elemCosts.PayForElem();
            placedBuildingGod.CheckUpgrades(mousePos, myElem.GetSprite(), settedElem);
        }
    }

    void OnDelete() 
    {
        manager.clean();

        GetComponent<PlayerInput>().DeactivateInput();
        buttonPanel.SetActive(true);
    }

    Vector3 GetMousePos()
    {
        Vector3 mousePos3 = Input.mousePosition;

        mousePos3 = Camera.main.ScreenToWorldPoint(mousePos3);

        return new Vector3(mousePos3.x, mousePos3.y, 0); // mysz jest tam gdzie kamera czyli na -1
    }
}
