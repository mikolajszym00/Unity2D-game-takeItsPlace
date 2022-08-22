using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacing : MonoBehaviour
{

    [SerializeField] ItemSO myItem;
    [SerializeField] GameObject setPointer;

    void OnSet()
    {
        Destroy(setPointer);

        Vector3 pos = GetComponent<ItemSetter>().GetMousePos();
        Transform parent = transform.Find("Item Container").transform;


        Instantiate(myItem.GetPrefabFeatures(), pos, Quaternion.identity, parent);
    }

    void OnDestroy() 
    {
        Destroy(setPointer);

    }
}
