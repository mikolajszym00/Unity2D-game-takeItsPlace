using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPointerCD : MonoBehaviour
{
    int counter = 0;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Boundary" || other.tag == "BaredTile") {
            counter += 1;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Boundary" || other.tag == "BaredTile") {
            counter -= 1;
        }
    }

    public bool CanBePlaced() 
    {
        return counter == 0 ? true: false;
    }

    public void ResetCounter()
    {
        counter = 0;
    }
}
