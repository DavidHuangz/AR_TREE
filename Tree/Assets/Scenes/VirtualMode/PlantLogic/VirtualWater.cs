using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VirtualWater : MonoBehaviour
{
    VirtualWeather weather;

    TextMeshProUGUI water_level_text;

    public List<int> water_data;

    public int water_level = 50;

    public void Init(VirtualWeather weather_object, TextMeshProUGUI text)
    {
        water_level_text = text;
        weather = weather_object;
        water_data = new List<int> { water_level };
        change_water_level_text();
        VirtualTime.OnTick += VirtualTime_OnTick;
    }

    public void change_water_level_text()
    {
        water_level_text.text = "Water Level   " + water_level;
    }

    public void water_button()
    {
        water_level += 50;
        change_water_level_text();
    }

    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e)
    {
        if (weather.rain_data_total() >= 25)
        {
            water_level = water_level;
        }
        else if (weather.rain_data_total() >= 20)
        {
            water_level = water_level >= 1 ? water_level - 1 : 0;
        }
        else if (weather.rain_data_total() >= 15)
        {
            water_level = water_level >= 2 ? water_level - 2 : 0;
        }
        else if (weather.rain_data_total() >= 10)
        {
            water_level = water_level >= 3 ? water_level - 3 : 0;
        }
        else if (weather.rain_data_total() >= 5)
        {
            water_level = water_level >= 4 ? water_level - 4 : 0;
        }
        else
        {
            // almost no rainfall in the past 7 days
            water_level = water_level >= 5 ? water_level - 5 : 0;
        }

        // increase soil moisture evaporation when the temperature is warm
        if (weather.temperature >= 20)
        {
            water_level = water_level >= 2 ? water_level - 2 : 0;
        }

        change_water_level_text();
        water_data.Add (water_level);
    }
}
