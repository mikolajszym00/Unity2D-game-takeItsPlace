using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAct : MonoBehaviour
{
    [SerializeField] float initDurability = 5f;
    float durability;

    [SerializeField] int loot = 2; // mozna dodac randomozowanie
    [SerializeField] Sprite drop;

    GameObject hand;
    bool heroCollision = false;

    SpriteRenderer mySpriteRenderer;

    GameObject inventoryObj;
    Inventory inventory;

    PlacedBuildingHuman placedBuildingHuman;

    Vector3 position;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        inventoryObj = transform.parent.gameObject;
        inventory = inventoryObj.GetComponent<Inventory>();

        durability = initDurability;
    }

    void Update()
    {
        Act();
    }

    public void InitItem(Vector3 pos, PlacedBuildingHuman pbh)
    {
        position = pos;
        placedBuildingHuman = pbh;
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Hand") 
        {
            hand = other.gameObject;
            heroCollision = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Hand") 
        {
            heroCollision = false;
        }
    }

    void Act() 
    {
        if (heroCollision && hand.GetComponent<HandAction>().IsAtacking())
        {
            durability -= Time.deltaTime; // można mnożyć w celu zmniejszenia
        }
        else
        {
            durability = initDurability;
        }

        if (durability <= 0) {
            inventory.AddToInventory(drop, loot);
            placedBuildingHuman.checkDowngrades(gameObject, mySpriteRenderer.sprite, position);

            Destroy(gameObject);
        }
    }
}
