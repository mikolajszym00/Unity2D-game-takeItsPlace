using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "BuildingSO")]
public class BuildingSO : ElemSO
{
    [SerializeField] float objectBoundariesRadius;

    public float GetObjectBoundariesRadius()
    {
        return objectBoundariesRadius;
    }
}
