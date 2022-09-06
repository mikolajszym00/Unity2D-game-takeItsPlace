using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TradeHandler : MonoBehaviour
{
    [SerializeField] GameObject inventoryObj;
    Inventory inventory;

    Sprite component;
    Sprite product;
    String buildingname;

    Slider slider;

    [SerializeField] GameObject componentStockValueObj;
    [SerializeField] GameObject productStockValueObj;

    TextMeshProUGUI componentStockValueSetter;
    TextMeshProUGUI productStockValueSetter;

    void Awake() 
    {
        inventory = inventoryObj.GetComponent<Inventory>();

        slider = transform.Find("Slider").gameObject.GetComponent<Slider>();

        componentStockValueSetter = componentStockValueObj.GetComponent<TextMeshProUGUI>();
        productStockValueSetter = productStockValueObj.GetComponent<TextMeshProUGUI>();
    }

    public void InitValues(String _buildingname, Sprite[] _component, Sprite[] _product)
    {
        buildingname = _buildingname;
        component = _component[0];
        product =_product[0];

        transform.Find("Name").GetComponent<TextMeshProUGUI>().text = buildingname;
        transform.Find("Component").Find("Elem").GetComponent<Image>().sprite = component;
        transform.Find("Product").Find("Elem").GetComponent<Image>().sprite = product;
    }

    public void SetSlider()
    {
        slider.maxValue = inventory.GetItemQuantity(component);
        slider.value = 0;

        componentStockValueSetter.text = "0";
        productStockValueSetter.text = "0";
    }

    public void OnSliderChange()
    {
        componentStockValueSetter.text = slider.value.ToString();

        productStockValueSetter.text = Mathf.FloorToInt(slider.value/4).ToString(); // mnożnik do zmiany
    }
}
