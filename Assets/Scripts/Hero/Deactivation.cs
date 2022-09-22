using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivation : MonoBehaviour
{
    HeroMovement heroMovement;
    Animator heroAnimator;
    [SerializeField] GameObject handAction;

    void Start()
    {
        heroMovement = gameObject.GetComponent<HeroMovement>();
        heroAnimator = gameObject.GetComponent<Animator>();
    }

    public void ActivateInteraction(bool state)
    {
        heroMovement.enabled = state;
        // heroAnimator.enabled = state; //zmienić animację
        handAction.SetActive(state);
    }

}
