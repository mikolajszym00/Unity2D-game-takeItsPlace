using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ElementSetter : MonoBehaviour
{
    [SerializeField] GameObject buttonPanel;

    [SerializeField] Functions func;

    [SerializeField] ElementManager itemManager;
    [SerializeField] ElementManager tileManager;

    ElementManager manager;

    void Start()
    {
        GetComponent<PlayerInput>().DeactivateInput();
    }
    
    public void RunSetter(ItemSO elem)
    {
        GetComponent<PlayerInput>().ActivateInput();

        if (elem.IsItem()) { manager = itemManager; } // bardzo złe
        else { manager = tileManager; }

        manager.prepare(elem);
        manager.SetSprite(elem.GetSprite());
   }

    void OnSet()
    {
        manager.MouseClickHandler(GetMousePos());
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
