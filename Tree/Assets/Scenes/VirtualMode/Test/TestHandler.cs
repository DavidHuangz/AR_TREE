using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestHandler : MonoBehaviour
{
    TestWater water;

    TestHealth health;

    TestRain rain;

    public TextMeshProUGUI water_level_text;

    public TextMeshProUGUI growth_text;

    public TextMeshProUGUI rain_text;

    public TextMeshProUGUI rainfall_text;

    void Start()
    {
        water = gameObject.AddComponent<TestWater>();
        health = gameObject.AddComponent<TestHealth>();
        rain = gameObject.AddComponent<TestRain>();

        // pass in the UI text and link objects
        water.TestWaterInit (rain, water_level_text, rainfall_text);
        health.TestHealthInit (water, growth_text);
        rain.TestRainInit (rain_text);
    }

    public void water_button()
    {
        water.water_button();
    }

    public void reset()
    {
        water.reset_button();
    }

    public void rain_change()
    {
        rain.rain_button();
    }

    public void save_button()
    {
        TestVirtualSave.SaveTestVirtualData (water, health, rain);
    }

    public void load_button()
    {
        TestVirtualData data = TestVirtualSave.LoadTestVirtualData();
        if (data != null)
        {
            water.water_level = data.water_level;
            health.growth = data.health_level;
            rain.rain_data = data.rain_data_list;
            rain.rainy = data.rain_state;
            water.change_water_level_text();
            rain.change_rain_state_text();
        }
    }

    public int getWater()
    {
        return water.water_level;
    }

    public int getGrowth()
    {
        return (int) health.growth;
    }
}
