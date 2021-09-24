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

    public double calculate_growth()
    {
        if (water.water_level >= 50 && water.water_level <= 100)
        {
            if (nutrient.nutrient_level >= 50 && nutrient.nutrient_level <= 100)
            {
                return 1;
            }
            else
            {
                return 0.7;
            }
        }
        else if (nutrient.nutrient_level >= 50 && nutrient.nutrient_level <= 100
        )
        {
            if (water.water_level > 100)
            {
                return 0.3;
            }
            else if (water.water_level > 0)
            {
                return 0.5;
            }
        }
        return 0;
    }

    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e)
    {
        growth += calculate_growth();
        change_growth_text();
        growth_data.Add (growth);
    }
}
