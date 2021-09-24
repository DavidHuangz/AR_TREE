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

    public void reset_button()
    {
        water_level = 50;
        change_water_level_text();
    }

    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e)
    {
        if (weather.rain_data_total() < 2)
        {
            water_level -= 2;
        }
        else
        {
            water_level--;
        }
        change_water_level_text();
        water_data.Add (water_level);
    }
}
