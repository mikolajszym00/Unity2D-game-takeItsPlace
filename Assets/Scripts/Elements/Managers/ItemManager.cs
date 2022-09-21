using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : ElemSetPointerManager
{
    [SerializeField] GameObject buildingContainer;

    ItemSO myElem;
    GameObject boundaries;

    public override void prepare(ElemSO elem)
    {
        base.prepare(elem);

        myElem = (ItemSO)elem;
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



    // [SerializeField] GameObject gridManager;

    // [SerializeField] GameObject setPointerTemplate;

    // [SerializeField] float moveSpeed = 0.1f;
    // [SerializeField] Sprite denySprite;

    // ItemSO myElem;

    // GameObject setPointer;
    // Rigidbody2D rb;

    // void Update()
    // {
    //     if (setPointer) 
    //     { 
    //         MoveSetPointer();
    //         // itemDetector.ChangeSprite(); 
    //     }
    // }

    // void MoveSetPointer()
    // {
    //     Vector2 position = Vector2.Lerp(setPointer.transform.position, GetMousePos(), moveSpeed);
    //     rb.MovePosition(position);
    // } 

    // // void ChangeSprite() // nie podoba mi się to, wykonuje się cały czas
    // // {
    // //     if (true) // trzeba zmienić
    // //     {
    // //         mySpriteRenderer.sprite = mySprite;
    // //     }
    // //     else
    // //     {
    // //         mySpriteRenderer.sprite = denySprite;
    // //     }
    // // }

    // public override void prepare(ItemSO elem)
    // {
    //     myElem = elem;

    //     setPointer = Instantiate(setPointerTemplate, GetMousePos(), Quaternion.identity, transform);
    //     rb = setPointer.GetComponent<Rigidbody2D>();

    //     setPointer.GetComponent<CircleCollider2D>().radius = myElem.GetObjectBoundariesRadius();
    // }

    // public override void clean()
    // {
    //     Destroy(setPointer);
    // }

    // public override void SetSprite(Sprite sp) {
    //     setPointer.GetComponent<SpriteRenderer>().sprite = sp;
    // }

    // public override bool MouseClickHandler(Vector3 mousePos) 
    // {
    //     if (!(setPointer.GetComponent<SetPointerCD>().CanBePlaced() &&
    //           gridManager.GetComponent<GridManager>().IsPositionOnCoveredTiles(GetMousePos()))) 
    //         { 
    //             return false; 
    //         }

    //     setPointer.GetComponent<SetPointerCD>().ResetCounter();

    //     Transform parent = transform.Find("Item Container").transform;
    //     Instantiate(myElem.GetPrefabObj(), GetMousePos(), Quaternion.identity, parent);

    //     return true;
    // }


}
