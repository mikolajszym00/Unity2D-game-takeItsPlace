using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : ElemSetPointerManager
{
    BuildingSO myElem;

    public override void prepare(ElemSO elem)
    {
        base.prepare(elem);

        myElem = (BuildingSO)elem;
        setPointer.GetComponent<CircleCollider2D>().radius = myElem.GetObjectBoundariesRadius();
    }

    public override bool MouseClickHandler(Vector3 mousePos) 
    {
        if (!base.MouseClickHandler(mousePos)) { return false; }

        setPointer.GetComponent<SetPointerCD>().ResetCounter();

        Transform parent = transform.Find("Building Container").transform; //!!!!
        Instantiate(myElem.GetPrefabObj(), base.GetMousePos(), Quaternion.identity, parent);

        return true;
    }
}
