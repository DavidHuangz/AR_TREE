using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetTime : MonoBehaviour
{
    private VirtualHandler vh;

    public TextMeshProUGUI water_txt;

    public TextMeshProUGUI fertilise_txt;

    void Start()
    {
        GameObject mainCanvas = GameObject.Find("UIManager");
        vh = mainCanvas.GetComponent<VirtualHandler>();

        water_txt.text = "Last Watered: ";
        fertilise_txt.text = "Last Fertilised: ";
    }

    public void setWater()
    {
        water_txt.text = "Last Watered: Day " + vh.getDay();
    }

    public void setFertile()
    {
        fertilise_txt.text = "Last Fertilised: Day " + vh.getDay();
    }
}
