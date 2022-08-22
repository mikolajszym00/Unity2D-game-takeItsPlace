using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItemCD : ItemCollisionDetector
{

                // Debug.Log(coords.i);
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Tile") { // jeśli jest równe zero nie można stwiać, bo wyszedł z zasięgu wszystkich
            counter += 1;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Tile") { // tu powinno byc tag coveredTile
            counter -= 1;
        }
    }

    public override bool CanBePlaced()
    {
        return counter != 0 && !gridManager.IsMouseOverTiles();
    }
}
