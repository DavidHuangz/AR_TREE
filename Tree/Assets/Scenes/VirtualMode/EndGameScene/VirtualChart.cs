using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

public class VirtualChart : MonoBehaviour
{
    public BarChart growth_chart;

    public LineChart rainfall_chart;

    public LineChart temperature_chart;

    List<int> water_data;

    List<int> nutrient_data;

    List<double> growth_data;

    List<double> rain_data;

    List<double> temperature_data;

    public void Start()
    {
        loadData();
        chartSetup();
    }

    public void chartSetup()
    {
        growth_chart.ClearData();
        rainfall_chart.ClearData();
        temperature_chart.ClearData();

        for (int i = 0; i < growth_data.Count; i++)
        {
            growth_chart.AddXAxisData("" + i);
            growth_chart.AddData(0, water_data[i]);
            growth_chart.AddData(1, nutrient_data[i]);
            growth_chart.AddData(2, growth_data[i]);
        }

        for (int j = 0; j < rain_data.Count; j++)
        {
            rainfall_chart.AddXAxisData("" + j);
            rainfall_chart.AddData(0, rain_data[j]);
            temperature_chart.AddXAxisData("" + j);
            temperature_chart.AddData(0, temperature_data[j]);
        }
    }

    public void loadData()
    {
        VirtualData data = VirtualSave.LoadVirtualData();
        if (data != null)
        {
            water_data = data.water_data;

            nutrient_data = data.nutrient_data;

            growth_data = data.growth_data;

            rain_data = data.rain_lifetime;

            temperature_data = data.temperature_lifetime;
        }
    }
}
