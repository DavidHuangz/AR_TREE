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

    public TextMeshProUGUI rainfall_text;

    public TextMeshProUGUI tick_text;

    private int tick = 0;

    public int apples = 8;

    private int unhealthycounter = 0;

    private int waterdeficient = 0;

    private int nutrientdeficient = 0;

    private string condition = "";

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
        weather.Init (rainfall_text);

        // // check and load existing data
        // load();
        tick_text.GetComponent<UnityEngine.UI.Text>().text = "Lifetime: Day 0";
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
        VirtualSave.SaveVirtualData (
            water,
            nutrient,
            health,
            weather,
            condition
        );
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

            if (data.daily_growth_data != null)
            {
                health.daily_growth_data = data.daily_growth_data;
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
        tick_text.text = "Lifetime: Day " + tick;
        float target = health == null ? 0 : (float) health.growth;
        progress.IncrementProgress (target);

        // reduce apple harvest quantity if the tree has been unhealthy for 5 days continously
        if (water.water_level == 0 && nutrient.nutrient_level == 0)
        {
            unhealthycounter++;
            if (unhealthycounter % 5 == 0)
            {
                apples = apples > 0 ? apples - 1 : 0;
            }
        }
        else
        {
            unhealthycounter = 0;
        }

        if (water.water_level == 0)
        {
            waterdeficient++;
        }
        else
        {
            waterdeficient = 0;
        }

        if (nutrient.nutrient_level == 0)
        {
            nutrientdeficient++;
        }
        else
        {
            nutrientdeficient = 0;
        }
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

    public double getPrecipitation()
    {
        return weather.precipitation;
    }

    public double getTemp()
    {
        return weather.temperature;
    }

    public int getApples()
    {
        return apples;
    }

    public int getDay()
    {
        return tick;
    }

    public string getPlantCondition()
    {
        if (unhealthycounter >= 7)
        {
            condition = "unhealthy";
        }
        else if (waterdeficient >= 10)
        {
            condition = "water";
        }
        else if (nutrientdeficient >= 10)
        {
            condition = "nutrient";
        }
        return condition;
    }
}
