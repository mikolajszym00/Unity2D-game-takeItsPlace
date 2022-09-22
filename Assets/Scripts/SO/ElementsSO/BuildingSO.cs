using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "BuildingSO")]
public class BuildingSO : ElemSO
{
    [SerializeField] float objectBoundariesRadius; // chyba nie potrzebne

    [SerializeField] UpgradePathSO upgradePath;

    public float GetObjectBoundariesRadius()
    {
        return objectBoundariesRadius;
    }

    public UpgradePathSO GetUpgradePath()
    {
        return upgradePath;
    }
}
