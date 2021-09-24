using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VirtualHandler : MonoBehaviour
{
    VirtualWater water;

    VirtualNutrient nutrient;

    VirtualHealth health;

    VirtualWeather weather;

    public ProgressBar progress;

    public TextMeshProUGUI water_level_text;

    public TextMeshProUGUI nutrient_level_text;

    public TextMeshProUGUI growth_text;

    public TextMeshProUGUI rain_text;

    public TextMeshProUGUI rainfall_text;

    public GameObject tick_text;

    int tick = 0;

    void Awake()
    {
        water = gameObject.AddComponent<VirtualWater>();
        nutrient = gameObject.AddComponent<VirtualNutrient>();
        health = gameObject.AddComponent<VirtualHealth>();
        weather = gameObject.AddComponent<VirtualWeather>();

        // subscribe to time tick system
        VirtualTime.OnTick +=
            delegate (object sender, VirtualTime.OnTickEventArgs e)
            {
            };
        VirtualTime.OnTick += VirtualTime_OnTick;

        // pass in the UI text and link objects
        water.Init (weather, water_level_text);
        nutrient.Init (nutrient_level_text);
        health.Init (water, nutrient, growth_text);
        weather.Init (rain_text, rainfall_text);

        // // check and load existing data
        // load();
        tick_text.GetComponent<UnityEngine.UI.Text>().text = "Day 0";
    }

    public void water_button()
    {
        water.water_button();
    }

    public void nutrient_button()
    {
        nutrient.nutrient_button();
    }

    public void save()
    {
        VirtualSave.SaveVirtualData (water, nutrient, health, weather);
    }

    public void load()
    {
        VirtualData data = VirtualSave.LoadVirtualData();
        if (data != null)
        {
            water.water_level = data.water_level;
            nutrient.nutrient_level = data.nutrient_level;
            health.growth = data.health_level;

            if (data.water_data != null)
            {
                water.water_data = data.water_data;
            }

            if (data.nutrient_data != null)
            {
                nutrient.nutrient_data = data.nutrient_data;
            }

            if (data.growth_data != null)
            {
                health.growth_data = data.growth_data;
            }

            if (data.rain_data != null)
            {
                weather.rain_data = data.rain_data;
            }

            if (data.rain_lifetime != null)
            {
                weather.rain_lifetime = data.rain_lifetime;
            }

            if (data.temperature_lifetime != null)
            {
                weather.temperature_lifetime = data.temperature_lifetime;
            }

            health.change_growth_text();
        }
    }

    public void reset_button()
    {
        water.water_level = 50;
        nutrient.nutrient_level = 50;
        health.growth = 0;
        health.change_growth_text();
        weather.rain_data.Clear();
        weather.rain_lifetime.Clear();
        weather.temperature_lifetime.Clear();
    }

    // update progress bar every tick
    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e)
    {
        tick++;
        tick_text.GetComponent<UnityEngine.UI.Text>().text = "Day " + tick;
        float target = health == null ? 0 : (float) health.growth;
        progress.IncrementProgress (target);
    }

    public float getWater()
    {
        return water == null ? 0 : (float) water.water_level;
    }

    public float getNutrient()
    {
        return nutrient == null ? 0 : (float) nutrient.nutrient_level;
    }

    public float getGrowth()
    {
        return health == null ? 0 : (float) health.growth;
    }

    public double getDailyGrowth()
    {
        return health.calculate_growth();
    }

    public bool getRainState()
    {
        return weather.raining;
    }
}
