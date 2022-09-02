using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingCollision : MonoBehaviour
{
    protected GameObject buildingCont;
    protected PlacedBuilding placedBuilding;

    protected Transform buiCanvas;
    protected GameObject tradeMenu;

    protected virtual void Start()
    {
        buildingCont = transform.parent.gameObject;
        placedBuilding = buildingCont.GetComponent<PlacedBuilding>();

        buiCanvas = transform.Find("Building Canvas");    
    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            placedBuilding.SetStandByTheBui(true);
            placedBuilding.SetBuilding(gameObject);
        }
    }
    
    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            placedBuilding.SetStandByTheBui(false);
        }
    }

    public void OpenBuiMenu()
    {
        placedBuilding.DeactivateOtherInputs();

        buiCanvas.gameObject.SetActive(true);

        tradeMenu.GetComponent<StumpTradeHandler>().SetSlider();
    }
}
