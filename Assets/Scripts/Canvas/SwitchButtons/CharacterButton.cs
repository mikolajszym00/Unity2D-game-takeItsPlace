using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] GameObject godMode;
    [SerializeField] GameObject humanMode;

    [SerializeField] Deactivation heroActivation;

    [SerializeField] OpenCloseAction closeBuildier;
    [SerializeField] OpenCloseAction closeInventory;

    [SerializeField] GameObject god;
    [SerializeField] GameObject human;

    void Start()
    {
        god.GetComponent<Button>().interactable = false;

        heroActivation.ActivateInteraction(false);
    }

    public void OnButtonSelected(int index) 
    {
        if (index == 1) 
        {
            humanMode.SetActive(false);
            godMode.SetActive(true);

            human.GetComponent<Button>().interactable = true;
            god.GetComponent<Button>().interactable = false;

            heroActivation.ActivateInteraction(false);

            closeBuildier.OnButtonClose();
            closeInventory.OnButtonClose();
        }
        else
        {
            humanMode.SetActive(true);
            godMode.SetActive(false);

            human.GetComponent<Button>().interactable = false;
            god.GetComponent<Button>().interactable = true;

            heroActivation.ActivateInteraction(true);
        }


    }
}
