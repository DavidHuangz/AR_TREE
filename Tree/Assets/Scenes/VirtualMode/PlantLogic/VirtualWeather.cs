using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class VirtualWeather : MonoBehaviour
{
    TextMeshProUGUI rain_text;

    TextMeshProUGUI rainfall_text;

    public List<double> rain_data;

    public List<double> precipitation_data;

    public List<double> temperature_data;

    public List<double> rain_lifetime;

    public List<double> temperature_lifetime;

    public bool raining = false;

    public double precipitation = 0;

    public double temperature = 0;

    public void Init(TextMeshProUGUI rain_button, TextMeshProUGUI rainfall)
    {
        // get unity UI components
        rain_text = rain_button;
        rainfall_text = rainfall;

        // set up weather data system
        rain_data = new List<double> { 0 };
        temperature_data = new List<double>();
        rain_lifetime = new List<double>();
        temperature_lifetime = new List<double>();

        change_rainfall_text();
        precipitation_data_setup();
        temperature_data_setup();

        // subscribe to time tick sysstem
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

    public void temperature_data_setup()
    {
        temperature_data =
            new List<double> {
                60.1,
                61.5,
                65.5,
                53.1,
                59.5,
                61.7,
                61.7,
                65.1,
                64.8,
                67.5,
                61.3,
                66.4,
                62.4,
                64.2,
                63.9,
                57.9,
                66.0,
                63.3,
                65.5,
                61.3,
                56.1,
                60.3
            };
    }

    public double rain_data_total()
    {
        return rain_data == null ? 0 : rain_data.Sum();
    }

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

        // select the rain data
        precipitation = precipitation_data[element];
        raining = precipitation > 0 ? true : false;
        rain_data.Add (precipitation);
        rain_lifetime.Add (precipitation);
        change_rainfall_text();
        change_rain_state_text();

        // select the corresponding temperature data
        temperature = temperature_data[element];
        temperature_lifetime.Add (temperature);
    }
}
