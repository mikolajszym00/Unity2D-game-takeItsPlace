using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : ElemSetPointerManager
{
    [SerializeField] GameObject buildingContainer;

    GodElemSO myElem;
    GameObject boundaries;

    public override void prepare(ElemSO elem)
    {
        base.prepare(elem);

        myElem = (GodElemSO) elem;

        boundaries = myElem.GetPrefabObj().transform.Find("Object Boundaries").gameObject;
        setPointer.GetComponent<CircleCollider2D>().radius = boundaries.GetComponent<CircleCollider2D>().radius;
    }

    public override GameObject MouseClickHandler(Vector3 mousePos) 
    {
        if (!MouseClickCorrectness(mousePos)) { return null; }

        setPointer.GetComponent<SetPointerCD>().ResetCounter();

        Transform parent = transform.Find("Item Container").transform;

        GameObject item = Instantiate(myElem.GetPrefabObj(), base.GetMousePos(), Quaternion.identity, parent);
        
        PlacedBuildingHuman pbh = buildingContainer.GetComponent<PlacedBuildingHuman>();
        item.GetComponent<ItemAct>().InitItem(base.GetMousePos(), pbh);

        return item;
    }
}
