using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VirtualData
{
    public int water_level;
    public int nutrient_level;
    public double health_level;
    public List<double> rain_data_list;
    public bool rain_state;

    public VirtualData (VirtualWater water, VirtualNutrient nutrient, VirtualHealth health, VirtualRain rain) {
        water_level = water.water_level;
        nutrient_level = nutrient.nutrient_level;
        health_level = health.growth;
        rain_data_list = rain.rain_data;
        rain_state = rain.rainy;
    }
}
