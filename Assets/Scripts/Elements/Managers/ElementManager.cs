using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElementManager : MonoBehaviour
{
    // [SerializeField] protected Functions func;

    public abstract void prepare(ElemSO elem);

    public abstract void clean();

    public abstract bool MouseClickHandler(Vector3 mousePos);

    public abstract void SetSprite(Sprite newSprite);
}
