using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VirtualHandler : MonoBehaviour
{
    VirtualWater water;
    VirtualNutrient nutrient;
    VirtualHealth health;
    VirtualRain rain;
    ProgressBar progress;
    public TextMeshProUGUI water_level_text;
    public TextMeshProUGUI nutrient_level_text;
    public TextMeshProUGUI growth_text;
    public TextMeshProUGUI rain_text;
    public TextMeshProUGUI rainfall_text;

    void Start()
    {
        water = gameObject.AddComponent<VirtualWater>();
        nutrient = gameObject.AddComponent<VirtualNutrient>();
        health = gameObject.AddComponent<VirtualHealth>();
        rain = gameObject.AddComponent<VirtualRain>();
        progress = gameObject.GetComponent<ProgressBar>();

        // subscribe to time tick system
        VirtualTime.OnTick += delegate (object sender, VirtualTime.OnTickEventArgs e) {};
        VirtualTime.OnTick += VirtualTime_OnTick;

        // pass in the UI text and link objects
        water.Init(rain, water_level_text);
        nutrient.Init(nutrient_level_text);
        health.Init(water, growth_text);
        rain.Init(rain_text, rainfall_text);

        // check and load existing data
        load();
    }

    public void water_button() {
        water.water_button();
    }

    public void nutrient_button() {
        nutrient.nutrient_button();
    }

    public void rain_change() {
        rain.rain_button();
    }

    public void save() {
        VirtualSave.SaveVirtualData(water, nutrient, health, rain);
    }

    public void load() {
        VirtualData data = VirtualSave.LoadVirtualData();
        if (data != null) {
            water.water_level = data.water_level;
            nutrient.nutrient_level = data.nutrient_level;
            health.growth = data.health_level;
            if (data.rain_data_list != null) {
                rain.rain_data = data.rain_data_list;
            }
            health.change_growth_text();
        }
    }

    public void reset_button() {
        water.water_level = 50;
        nutrient.nutrient_level = 50;
        health.growth = 0;
        rain.rain_data.Clear();
        health.change_growth_text();
    }

    
    // update progress bar every tick
    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e) {
        float target = health == null? 0 : (float)health.growth;
        // progress.IncrementProgress(target);
    }

    public float getWater() {
        return water == null? 0 : (float)water.water_level;
    }

    public float getNutrient() {
        return water == null? 0 : (float)nutrient.nutrient_level;
    }

    public float getGrowth() {
        return health == null? 0 : (float)health.growth;
    }
}
