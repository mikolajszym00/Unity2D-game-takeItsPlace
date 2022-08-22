using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemSetter : MonoBehaviour // ma być ElementSetter, rozdzielić itemy od ground
{

    ItemSO myItem;

    GameObject setPointer;
    Rigidbody2D rb;
    ItemCollisionDetector itemDetector;

    Vector2 position = new Vector2(0f, 0f);
    [SerializeField] float moveSpeed = 0.1f;

    [SerializeField] protected GameObject gridManagerObj; 
    protected GridManager gridManager;

    void Start()
    {
        GetComponent<PlayerInput>().DeactivateInput();
        gridManager = gridManagerObj.GetComponent<GridManager>();
    }

    void Update()
    {
        if (setPointer) 
        { 
            // MoveSetPointer();
            // itemDetector.ChangeSprite(); 
        }
    }

    void SetRadius() 
    {
        setPointer.GetComponent<CircleCollider2D>().radius = myItem.GetObjectBoundariesRadius();
    }

    public void CreateSetPointer(ItemSO item) 
    {
        GetComponent<PlayerInput>().ActivateInput();

        myItem = item;

        setPointer = Instantiate(myItem.GetSetPointerTemplate(), GetMousePos(), Quaternion.identity, transform);
        rb = setPointer.GetComponent<Rigidbody2D>();

        if (!myItem.IsGround()) { SetRadius(); } 

        itemDetector = setPointer.GetComponent<ItemCollisionDetector>();
        itemDetector.SetSprite(myItem.GetSprite());
   }

    void MoveSetPointer()
    {
        position = Vector2.Lerp(setPointer.transform.position, GetMousePos(), moveSpeed);

        rb.MovePosition(position);
    } 

    public Vector3 GetMousePos()
    {
        Vector3 mousePos3 = Input.mousePosition;
        mousePos3 = Camera.main.ScreenToWorldPoint(mousePos3);
        return new Vector3(mousePos3.x, mousePos3.y, 0); // mysz jest tam gdzie kamera czyli na -1
    }

    void OnSet()
    {
        if (!itemDetector.CanBePlaced()) { return; }

        Destroy(setPointer); // czy można więcej na raz kłaść (problem moze byc z trigger enter)
        GetComponent<PlayerInput>().DeactivateInput(); // czy można więcej na raz kłaść

        if (myItem.IsGround())
        {
            gridManager.CoverTile(myItem.GetSprite());
        }
        else 
        {
            Transform parent = transform.Find("Item Container").transform;
            Instantiate(myItem.GetPrefabFeatures(), GetMousePos(), Quaternion.identity, parent);
        }

    }

    void OnDestroy() 
    {
        Destroy(setPointer);

        GetComponent<PlayerInput>().DeactivateInput();
        if (itemDetector) { itemDetector.ResetCounter(); } // coś dziwnego
    }

}
