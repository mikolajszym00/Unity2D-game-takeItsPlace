using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAction : MonoBehaviour
{

    float actKeyIsPushed;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnAction(InputValue value)
    {
        actKeyIsPushed = value.Get<float>();
    }

    public float GetActKeyIsPushed() 
    {
        return actKeyIsPushed;
    }
}
