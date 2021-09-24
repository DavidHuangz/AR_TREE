using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

public class VirtualGraphMain : MonoBehaviour
{
    private int i = 0;

    public BarChart growthchart;

    public LiquidChart waterchart;

    public LiquidChart nutrientchart;

    private Serie waterseries;

    private Serie nutrientseries;

    private VirtualHandler vh;

    void Awake()
    {
        GameObject mainCanvas = GameObject.Find("UIManager");
        vh = mainCanvas.GetComponent<VirtualHandler>();
        waterseries = waterchart.series.GetSerie(0);
        nutrientseries = nutrientchart.series.GetSerie(0);

        growthchart.ClearData();
        updateChart();

        VirtualTime.OnTick += VirtualTime_OnTick;
    }

    public void graphSetUp()
    {
        double water = (double) vh.getWater();
        double nutrient = (double) vh.getNutrient();
        double growth = (double) vh.getGrowth();

        waterchart.ClearData();
        nutrientchart.ClearData();

        // change graph to red outlines when the water and nutrient are in an unhealthy state
        if (water >= 100)
        {
            // waterchart.vessel.color = new Color32(0, 92, 6, 255); // outline green
            waterseries.itemStyle.color = new Color32(0, 19, 37, 220); // liquid
        }
        else if (water >= 50)
        {
            // waterchart.vessel.color = new Color32(0, 92, 6, 255); // outline green
            waterseries.itemStyle.color = new Color32(8, 67, 118, 220); // liquid
        }
        else
        {
            // waterchart.vessel.color = new Color32(98, 130, 159, 255);  // outline green
            waterseries.itemStyle.color = new Color32(98, 130, 159, 255);
        }

        if (nutrient >= 100)
        {
            // nutrientchart.vessel.color = new Color32(0, 92, 6, 255); // outline green
            nutrientseries.itemStyle.color = new Color32(39, 21, 0, 255); // nutrient
        }
        else if (nutrient >= 50)
        {
            // nutrientchart.vessel.color = new Color32(0, 92, 6, 255); // outline green
            nutrientseries.itemStyle.color = new Color32(79, 37, 0, 255); // nutrient
        }
        else
        {
            // nutrientchart.vessel.color = new Color32(166, 0, 17, 255);
            nutrientseries.itemStyle.color = new Color32(174, 139, 114, 220);
        }
        waterchart.AddData(0, water);
        nutrientchart.AddData(0, nutrient);
    }

    public void updateChart()
    {
        graphSetUp();

        growthchart.AddXAxisData("" + i);
        growthchart.AddData(0, vh.getWater());
        growthchart.AddData(1, vh.getNutrient());
        growthchart.AddData(2, vh.getDailyGrowth() * 100);
        i++;
    }

    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e)
    {
        updateChart();
    }
}
