using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElemCost : MonoBehaviour
{
    public abstract bool CanBeBuilt();

    public abstract void PayForElem();
}
