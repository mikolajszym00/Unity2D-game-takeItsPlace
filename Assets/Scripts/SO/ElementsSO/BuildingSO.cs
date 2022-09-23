using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "BuildingSO")]
public class BuildingSO : ElemSO
{
    [SerializeField] UpgradePathSO upgradePath;

    public UpgradePathSO GetUpgradePath()
    {
        return upgradePath;
    }
}
