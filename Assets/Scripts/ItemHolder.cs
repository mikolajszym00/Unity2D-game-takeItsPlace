using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{

    // [SerializeField] GameObject ItemContainer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateHoldingItem(ItemSO item) 
    {
        Vector3 mousePos3 = Input.mousePosition;
        // Vector2 mousePos = new Vector2(mousePos3.x, mousePos3.y);

        Debug.Log("tak");


        GameObject go = new GameObject("heldItem", typeof(SpriteRenderer));
        go.GetComponent<SpriteRenderer>().sprite = item.GetSprite();

        // Debug.Log(Instantiate(choseItem.GetSprite(), new Vector3 (400, 400, 0), Quaternion.identity).GetType());
        Instantiate(go, new Vector3 (400, 400, 0), Quaternion.identity, transform);
        // heldItem = Instantiate(choseItem.GetSprite(), new Vector3 (400, 400, 0), Quaternion.identity); //mousePos3
    }

        void movingItem () // szuka miejsca dla itemu
    {
        // if () // jeśli choseItem != null, nie kliknął ktoś prawego lub nie umieścił na ziemi
        // {
        //     Vector3 mousePos3 = Input.mousePosition;
        //     Vector2 mousePos = new Vector2(mousePos3.x, mousePos3.y);

            

        //     choseItem.GetSprite

        // }
    } 
}
