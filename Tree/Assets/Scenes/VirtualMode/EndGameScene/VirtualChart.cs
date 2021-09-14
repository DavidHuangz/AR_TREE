using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

public class VirtualChart : MonoBehaviour
{
    int i = 0;

    public LineChart chart;

    // public BarChart bchart;
    List<int> water_data;

    List<int> nutrient_data;

    List<double> growth_data;

    List<double> rain_data_list;

    public void Start()
    {
        loadData();
        chartSetup();
    }

    public void chartSetup()
    {
        chart.title.text = "Tree Lifetime Chart";
        chart.title.show = true;

        chart.xAxes[0].boundaryGap = true;
        chart.ClearData();
        chart.AddSerie(SerieType.Line);
        chart.AddSerie(SerieType.Line);
        chart.AddSerie(SerieType.Line);

        for (int i = 0; i < growth_data.Count; i++)
        {
            chart.AddXAxisData("" + i);
            chart.AddData(0, water_data[i]);
            chart.AddData(1, nutrient_data[i]);
            chart.AddData(2, growth_data[i]);
        }

        // bchart.title.text = "Bar";
        // bchart.title.show = true;
        // bchart.ClearData();
    }

    public void loadData()
    {
        VirtualData data = VirtualSave.LoadVirtualData();
        if (data != null)
        {
            water_data = data.water_data;

            nutrient_data = data.nutrient_data;

            growth_data = data.growth_data;

            // rain_data = data.rain_data_list;
        }
    }
}
