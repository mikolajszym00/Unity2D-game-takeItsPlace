using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularItemCD : ItemCollisionDetector
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Boundary") {
            counter += 1;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Boundary") {
            counter -= 1;
        }
    }

    public override bool CanBePlaced()
    {
        return counter == 0 ? true : false;
    }
}
