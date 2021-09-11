using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VirtualHealth : MonoBehaviour
{
    public TextMeshProUGUI growth_text;
    public double growth = 0;

    VirtualWater water;
    
    public void Init(VirtualWater water_object, TextMeshProUGUI text)
    {
        water = water_object;
        growth_text = text;
        change_growth_text();
        VirtualTime.OnTick += VirtualTime_OnTick;
    }

    public void change_growth_text() {
        growth_text.text = "Growth   " + growth + " %";
    }

    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e) {
        if (water.water_level >= 50) {
            growth += 1;
        }
        change_growth_text();
    }
}
