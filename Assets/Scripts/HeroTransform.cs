using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTransform : MonoBehaviour
{

    SpriteRenderer mySpriteRenderer;
    [SerializeField] bool isFat = false;
    [SerializeField] Sprite[] stateArray;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    public bool GetState()
    {
        return isFat;
    }

    public void SetState() // wywoła się jak zmieni się isFat
    {
        if (isFat)
        {
            mySpriteRenderer.sprite = stateArray[1];
        }
        else 
        {
            mySpriteRenderer.sprite = stateArray[0];
        }
    }
}
