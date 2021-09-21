using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

public class VirtualGraphMain : MonoBehaviour
{
    private int i = 0;

    public BarChart growthchart;

    private VirtualHandler vh;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject mainCanvas = GameObject.Find("MainCanvas");
        vh = mainCanvas.GetComponent<VirtualHandler>();

        growthchart.ClearData();
        updateChart();

        VirtualTime.OnTick += VirtualTime_OnTick;
    }

    public void updateChart()
    {
        double water = (double) vh.getWater();
        double nutrient = (double) vh.getNutrient();
        double growth = (double) vh.getGrowth();
        growthchart.AddXAxisData("" + i);
        growthchart.AddData(0, water);
        growthchart.AddData(1, nutrient);
        growthchart.AddData(2, growth);
        i++;
    }

    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e)
    {
        updateChart();
    }
}
