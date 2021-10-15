using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class VirtualWeather : MonoBehaviour
{
    public TextMeshProUGUI rain_text;

    public TextMeshProUGUI rainfall_text;

    public List<double> rain_data;

    private List<double> precipitation_data;

    private List<double> temperature_data;

    public List<double> rain_lifetime;

    public List<double> temperature_lifetime;

    public bool raining = false;

    public double precipitation = 0;

    public double temperature = 0;

    public void Init(TextMeshProUGUI rainfall)
    {
        // get unity UI components
        rainfall_text = rainfall;

        // set up weather data system
        rain_data = new List<double> { 0 };
        temperature_data = new List<double>();
        rain_lifetime = new List<double>();
        temperature_lifetime = new List<double>();

        precipitation_data_setup();

        select_rainfall();
        select_temperature();

        // subscribe to time tick sysstem
        VirtualTime.OnTick += VirtualTime_OnTick;
    }

    private void precipitation_data_setup()
    {
        precipitation_data =
            new List<double> {
                0.05,
                0.00,
                0.06,
                0.00,
                0.00,
                1.50,
                0.00,
                0.02,
                0.00,
                0.80,
                0.00,
                0.20,
                0.00,
                0.00,
                0.04,
                0.00,
                0.00,
                0.00,
                0.00,
                0.00,
                0.00,
                0.00,
                0.00,
                0.00,
                0.00,
                0.00,
                0.00,
                0.00,
                0.00,
                0.00,
                0.00,
                0.00,
                0.00,
                0.01,
                0.15,
                0.19,
                0.04,
                0.31,
                0.00,
                1.45,
                0.01,
                0.00,
                0.00,
                0.90,
                0.50,
                0.00,
                0.14,
                0.00,
                0.00,
                0.33,
                0.52,
                0.01,
                0.00,
                0.00,
                0.00,
                0.00,
                0.01,
                0.30,
                0.06,
                0.02,
                1.00
            };
    }

    private void select_temperature()
    {
        if (raining)
        {
            temperature = Random.Range(15, 20);
        }
        else
        {
            temperature = Random.Range(17, 24);
        }
        temperature_lifetime.Add (temperature);
    }

    public double rain_data_total()
    {
        return rain_data == null ? 0 : rain_data.Sum();
    }

    public void change_rainfall_text()
    {
        rainfall_text.text =
            "Rainfall (last 7 days): " + rain_data_total() + " mm";
    }

    public void select_rainfall()
    {
        // only keep newest 7 points of rain data
        if (rain_data.Count >= 7)
        {
            rain_data.RemoveAt(0);
        }

        // get a random element from precipitation data available
        int element = Random.Range(0, precipitation_data.Count() - 1);

        // select the rain data and change from inch to mm
        precipitation = precipitation_data[element] * 2.54 * 10;
        raining = precipitation > 0 ? true : false;
        rain_data.Add (precipitation);
        rain_lifetime.Add (precipitation);
        change_rainfall_text();
    }

    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e)
    {
        select_rainfall();
        select_temperature();
    }
}
