using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAction : MonoBehaviour
{
    Animator anim;

    float actKeyIsPushed;

    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
    }

    void Update()
    {

    }

    void OnAction(InputValue value)
    {
        actKeyIsPushed = value.Get<float>();

        anim.SetBool("isUsingHand", actKeyIsPushed == 1 ? true: false);
    }

    public bool IsUsingHand() 
    {
        return anim.GetBool("isUsingHand");
    }
}
