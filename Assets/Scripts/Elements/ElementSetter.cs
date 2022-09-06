using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ElementSetter : MonoBehaviour
{
    [SerializeField] GameObject buttonPanel;
    ElemCost elemCosts;

    [SerializeField] Functions func;

    [SerializeField] ElementManager itemManager;
    [SerializeField] ElementManager tileManager;
    [SerializeField] ElementManager buildingManager;

    ElementManager manager;

    void Start()
    {
        GetComponent<PlayerInput>().DeactivateInput();
    }
    
    public void RunSetter(ElemSO elem, ElemCost elemCost)
    {
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

        if (manager.MouseClickHandler(GetMousePos()))
        {
            elemCosts.PayForElem();
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
