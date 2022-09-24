using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderControler : MonoBehaviour
{
    [SerializeField] protected float initValue = 100f;
    
    [SerializeField] protected Slider slider;
    [SerializeField] protected GameObject valueDisplayer;

    float prevValue;

    void Start() {
        SetMaxValue(initValue);    
        prevValue = initValue;
    }

    public float GetValue()
    {
        return slider.value;
    }

    public void SetMaxValue(float maxValue)
    {
        slider.maxValue = maxValue;
        DisplayNewValue();
    }

    public void ChangeValue(float value)
    {
        if (slider.value + value >= 100f)
        {
            slider.value = 100;
        } else {
            if (slider.value + value <= 0)
            {
                Debug.Log("coś osiągnęło 0"); // ma popchnąć informację do dziecka
                slider.value = 0;
            } else {
                slider.value += value;
            }
        }

        DisplayNewValue();
    }

    void DisplayNewValue()
    {
        if (Math.Abs(prevValue - slider.value) < 1f) { return; } // jeśli zmiana będzie duża to dopiero pokaże

        int v = Mathf.FloorToInt(slider.value);
        int m = Mathf.FloorToInt(slider.maxValue);
        
        valueDisplayer.GetComponent<TextMeshProUGUI>().text = $"{v}/{m}";

        prevValue = slider.value;
    }

}
