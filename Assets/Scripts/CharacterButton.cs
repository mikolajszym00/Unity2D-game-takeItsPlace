using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] GameObject godMode;
    [SerializeField] GameObject humanMode;

    public void OnButtonSelected (int index) 
    {
        if (index == 1) 
        {
            humanMode.SetActive(false);
            godMode.SetActive(true);
        }
        else
        {
            humanMode.SetActive(true);
            godMode.SetActive(false);
        }


    }
}
