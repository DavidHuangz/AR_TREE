using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VirtualHealth : MonoBehaviour
{
    public TextMeshProUGUI growth_text;

    public double growth = 0;

    public List<double> growth_data;

    public List<double> daily_growth_data;

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
        daily_growth_data = new List<double>();
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
                // both water and nutrients between 50 to 100
                return 1;
            }
            else
            {
                // water between 50 to 100 and any nutrients level
                return 0.7;
            }
        }
        else if (nutrient.nutrient_level >= 50 && nutrient.nutrient_level <= 100
        )
        {
            if (water.water_level > 100)
            {
                // nutrients between 50 to 100 and excess water
                return 0.3;
            }
            else if (water.water_level > 0)
            {
                // nutrients between 50 to 100 and insufficient water
                return 0.5;
            }
        }
        else if (water.water_level > 0 && nutrient.nutrient_level > 0)
        {
            // both water and nutrients between 0 to 50
            return 0.5;
        }

        // both water and nutrients are 0
        return 0;
    }

    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e)
    {
        double day_growth = calculate_growth();

        // growth += day_growth;
        // cap growth to 100
        growth = growth <= 100 - day_growth ? growth + day_growth : 100;
        change_growth_text();
        growth_data.Add (growth);
        daily_growth_data.Add (day_growth);
    }
}
