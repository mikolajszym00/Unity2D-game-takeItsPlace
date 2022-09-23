using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IconDisplayer : MonoBehaviour
{
    [SerializeField] protected GameObject elemIconPrefab;

    public void DestroyIcons()
    {
        foreach (Transform icon in transform)
        {
            Destroy(icon.gameObject);
        }
    }
}
