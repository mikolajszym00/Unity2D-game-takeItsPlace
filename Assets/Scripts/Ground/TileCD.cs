using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCD : MonoBehaviour
{

    bool isTile = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triggered");

        if (other.tag == "BaredTile" || other.tag == "CoveredTile") 
        {
            isTile = true;
        }
    }


    public bool IsThereATile((int i, int j) coord)
    {

        // Debug.Log("before");

        // transform.position = new Vector3(coord.i, coord.j, 0);

        // Debug.Log("after");

        if (isTile)
        {
            isTile = false;
            return true;
        }
        return false;
    }

}
