using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class HumanMenu : Menu
{
    [SerializeField] protected Inventory inventory;

    public abstract void Display(BuildingFeature buildingFeature, BuildingUpgrade buildingUpgrade);
    public abstract void ClearProduction();
}
