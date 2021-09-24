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
        // only reduce soil moisture evaporation when there is inadequate rain
        if (weather.rain_data_total() < 1)
        {
            water_level -= 5;
        }
        else
        {
            water_level -= 2;
        }

        // increase soil moisture evaporation when the temperature is warm
        if (weather.temperature >= 20)
        {
            water_level -= 2;
        }

        change_water_level_text();
        water_data.Add (water_level);
    }
}
