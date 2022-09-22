using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContainer : ScriptableObject
{
    GameObject[] elements;

    public void init(int size)
    {
        elements = new GameObject[size];
    }

    public int Length()
    {
        return elements.Length;
    }

    public GameObject GetElem(int index)
    {
        return elements[index];
    }

    public void SetElem(int index, GameObject element)
    {
        elements[index] = element;
    }

    public bool levelCompleted()
    {
        foreach (GameObject elem in elements)
        {
            if(!elem)
            {
                return false;
            }
        }

        return true;
    }
}
