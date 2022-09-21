using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : ElemSetPointerManager
{
    BuildingSO myElem;
    GameObject boundaries;

    public override void prepare(ElemSO elem)
    {
        base.prepare(elem);

        myElem = (BuildingSO)elem;

        boundaries = myElem.GetPrefabObj().transform.Find("Object Boundaries").gameObject;

        setPointer.GetComponent<CircleCollider2D>().radius = boundaries.GetComponent<CircleCollider2D>().radius;
    }

    public override GameObject MouseClickHandler(Vector3 mousePos) 
    {
        if (!MouseClickCorrectness(mousePos)) { return null; }

        setPointer.GetComponent<SetPointerCD>().ResetCounter();

        Transform parent = transform.Find("Building Container").transform;

        return Instantiate(myElem.GetPrefabObj(), base.GetMousePos(), Quaternion.identity, parent);
    }
}
