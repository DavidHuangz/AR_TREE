using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestVirtualData
{
    public int water_level;
    public double health_level;
    public List<double> rain_data_list;
    public bool rain_state;

    public TestVirtualData (TestWater water, TestHealth health, TestRain rain) {
        water_level = water.water_level;
        health_level = health.growth;
        rain_data_list = rain.rain_data;
        rain_state = rain.rainy;
    }
}
