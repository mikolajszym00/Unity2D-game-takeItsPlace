using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : ElemSetPointerManager
{
    public override bool MouseClickHandler(Vector3 mousePos) 
    {
        if (!base.MouseClickHandler(mousePos)) { return false; }

        setPointer.GetComponent<SetPointerCD>().ResetCounter();

        Transform parent = transform.Find("Building Container").transform; //!!!!
        Instantiate(myElem.GetPrefabObj(), base.GetMousePos(), Quaternion.identity, parent);

        return true;
    }
}
