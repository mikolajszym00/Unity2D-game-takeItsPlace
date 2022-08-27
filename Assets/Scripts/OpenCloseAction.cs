using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseAction : MonoBehaviour
{
    [SerializeField] GameObject hiddenInv;
    [SerializeField] GameObject extendedInv;

    public void OnButtonOpen() 
    {
        hiddenInv.SetActive(false);
        extendedInv.SetActive(true);
    }

    public void OnButtonClose() 
    {
        hiddenInv.SetActive(true);
        extendedInv.SetActive(false);
    }
}
