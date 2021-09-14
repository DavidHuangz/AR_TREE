using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VirtualHealth : MonoBehaviour
{
    public TextMeshProUGUI growth_text;

    public double growth = 0;

    public List<double> growth_data;

    VirtualWater water;

    VirtualNutrient nutrient;

    public void Init(
        VirtualWater water_object,
        VirtualNutrient nutrient_object,
        TextMeshProUGUI text
    )
    {
        water = water_object;
        nutrient = nutrient_object;
        growth_text = text;
        growth_data = new List<double> { 0 };
        change_growth_text();
        VirtualTime.OnTick += VirtualTime_OnTick;
    }

    public void change_growth_text()
    {
        growth_text.text = "Growth   " + growth + " %";
    }

    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e)
    {
        if (water.water_level >= 50 && nutrient.nutrient_level >= 50)
        {
            growth += 1;
        }
        change_growth_text();
        growth_data.Add (growth);
    }
}
