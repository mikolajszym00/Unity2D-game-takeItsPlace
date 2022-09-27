using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAction : MonoBehaviour
{
    [SerializeField] HeroVitality vitality;

    Animator anim;

    float actKeyIsPushed;

    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
    }

    void Update()
    {
        vitality.AttackEnergyCost(anim.GetBool("isAtacking"));
    }

    void OnAction(InputValue value)
    {
        actKeyIsPushed = value.Get<float>();

        anim.SetBool("isAtacking", actKeyIsPushed == 1 ? true: false);
    }

    public bool IsAtacking() 
    {
        return anim.GetBool("isAtacking");
    }
}
