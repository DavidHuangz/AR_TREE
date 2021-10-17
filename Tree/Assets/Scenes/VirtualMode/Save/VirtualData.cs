using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VirtualData
{
    public int water_level;

    public List<int> water_data;

    public int nutrient_level;

    public List<int> nutrient_data;

    public double health_level;

    public List<double> growth_data;

    public List<double> daily_growth_data;

    public List<double> rain_data;

    public List<double> rain_lifetime;

    public List<double> temperature_lifetime;

    public bool rain_state;

    public string status;

    public VirtualData(
        VirtualWater water,
        VirtualNutrient nutrient,
        VirtualHealth health,
        VirtualWeather weather,
        string condition
    )
    {
        status = condition;
        water_level = water.water_level;
        water_data = water.water_data;
        nutrient_data = nutrient.nutrient_data;
        nutrient_level = nutrient.nutrient_level;
        health_level = health.growth;
        growth_data = health.growth_data;
        daily_growth_data = health.daily_growth_data;
        rain_data = weather.rain_data;
        rain_state = weather.raining;
        rain_lifetime = weather.rain_lifetime;
        temperature_lifetime = weather.temperature_lifetime;
    }
}
