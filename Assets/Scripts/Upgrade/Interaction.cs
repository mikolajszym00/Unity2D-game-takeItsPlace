using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;

    bool isEnabled = false;

    public void SetCircleVisability(bool newVisability)
    {
        isEnabled = newVisability;

        sr.enabled = isEnabled;
        transform.Find("inner_circle").gameObject.SetActive(isEnabled);
    }
}
