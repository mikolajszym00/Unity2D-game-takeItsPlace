using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAct : MonoBehaviour
{
    [SerializeField] float initDurability = 5f;
    [SerializeField] float durability;

    [SerializeField] GameObject hand;
    [SerializeField] bool heroCollision = false;

    void Start()
    {
        durability = initDurability;
    }

    void Update()
    {
        Act();
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
        if (heroCollision && hand.GetComponent<HandAction>().GetActKeyIsPushed() == 1)
        {
            durability -= Time.deltaTime; // można mnożyć w celu zmniejszenia
        }
        else
        {
            durability = initDurability;
        }

        if (durability <= 0) {
            Destroy(gameObject);
        }

    }

}
