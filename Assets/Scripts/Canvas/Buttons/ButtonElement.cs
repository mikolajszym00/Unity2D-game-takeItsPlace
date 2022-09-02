using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonElement : MonoBehaviour
{
    [SerializeField] protected ElemSO myElem;

    public void SetMyElem(ElemSO newElem) {
        myElem = newElem;
    }

    public ElemSO GetMyElem() {
        return myElem;
    }

}
