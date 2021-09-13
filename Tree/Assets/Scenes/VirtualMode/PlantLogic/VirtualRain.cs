using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class VirtualRain : MonoBehaviour
{
    TextMeshProUGUI rain_text;

    TextMeshProUGUI rainfall_text;

    public List<double> rain_data;

    public List<double> precipitation_data;

    public bool raining = false;

    public void Init(TextMeshProUGUI rain_button, TextMeshProUGUI rainfall)
    {
        rain_data = new List<double> { 0 };
        rain_text = rain_button;
        rainfall_text = rainfall;
        change_rainfall_text();
        precipitation_data_setup();
        VirtualTime.OnTick += VirtualTime_OnTick;
    }

    public void precipitation_data_setup()
    {
        precipitation_data =
            new List<double> {
                0.05,
                0.00,
                0.06,
                0.00,
                0.00,
                0.00,
                0.02,
                0.00,
                0.00,
                0.00,
                0.00,
                0.04,
                0.01,
                0.15,
                0.19,
                0.04,
                0.31,
                1.45,
                0.01,
                0.00,
                0.00,
                0.00
            };
    }

    public double rain_data_total()
    {
        return rain_data == null ? 0 : rain_data.Sum();
    }

    // public void rain_button()
    // {
    //     raining = !raining;
    //     change_rain_state_text();
    // }
    public void change_rain_state_text()
    {
        rain_text.text = raining ? "Rain" : "No Rain";
    }

    public void change_rainfall_text()
    {
        rainfall_text.text = "Rainfall = " + rain_data_total();
    }

    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e)
    {
        // only keep newest 7 points of rain data
        if (rain_data.Count >= 7)
        {
            rain_data.RemoveAt(0);
        }

        // get a random element from precipitation data available
        int element = Random.Range(0, precipitation_data.Count() - 1);
        double precipitation = precipitation_data[element];
        raining = precipitation > 0 ? true : false;
        rain_data.Add (precipitation);
        change_rainfall_text();
        change_rain_state_text();
    }
}
