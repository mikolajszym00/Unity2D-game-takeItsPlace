using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    protected void SetName(string buildingName)
    {
        transform.Find("Name").GetComponent<TextMeshProUGUI>().text = buildingName;
    }
}
