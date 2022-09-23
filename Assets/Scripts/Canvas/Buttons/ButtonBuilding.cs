using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBuilding : ButtonElement
{

    [SerializeField] protected BuildingSO myBuilding;

    public override ElemSO GetMyElem() {
        return myBuilding;
    }
}
