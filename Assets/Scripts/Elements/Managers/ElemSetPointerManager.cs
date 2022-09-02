using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElemSetPointerManager : ElementManager
{
    [SerializeField] GameObject gridManager;

    [SerializeField] GameObject setPointerTemplate;

    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] Sprite denySprite;

    protected ItemSO myElem;

    protected GameObject setPointer;
    protected Rigidbody2D rb;

    void Update()
    {
        if (setPointer) 
        { 
            MoveSetPointer();
            // itemDetector.ChangeSprite(); 
        }
    }

    void MoveSetPointer()
    {
        Vector2 position = Vector2.Lerp(setPointer.transform.position, GetMousePos(), moveSpeed);
        rb.MovePosition(position);
    } 

    // void ChangeSprite() // nie podoba mi się to, wykonuje się cały czas
    // {
    //     if (true) // trzeba zmienić
    //     {
    //         mySpriteRenderer.sprite = mySprite;
    //     }
    //     else
    //     {
    //         mySpriteRenderer.sprite = denySprite;
    //     }
    // }

    public override void prepare(ItemSO elem)
    {
        myElem = elem;

        setPointer = Instantiate(setPointerTemplate, GetMousePos(), Quaternion.identity, transform);
        rb = setPointer.GetComponent<Rigidbody2D>();

        setPointer.GetComponent<CircleCollider2D>().radius = myElem.GetObjectBoundariesRadius();
    }

    public override void clean()
    {
        Destroy(setPointer);
    }

    public override void SetSprite(Sprite sp) {
        setPointer.GetComponent<SpriteRenderer>().sprite = sp;
    }

    public override bool MouseClickHandler(Vector3 mousePos) 
    {
        if (!(setPointer.GetComponent<SetPointerCD>().CanBePlaced() &&
              gridManager.GetComponent<GridManager>().IsPositionOnCoveredTiles(GetMousePos()))) 
            { 
                return false; 
            }
            
        return true;
    }

    protected Vector3 GetMousePos()
    {
        Vector3 mousePos3 = Input.mousePosition;

        mousePos3 = Camera.main.ScreenToWorldPoint(mousePos3);

        return new Vector3(mousePos3.x, mousePos3.y, 0); // mysz jest tam gdzie kamera czyli na -1
    }
}