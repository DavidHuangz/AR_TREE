using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

public class VirtualGraph : MonoBehaviour
{
    int i = 0;

    public LiquidChart waterchart;

    public LiquidChart nutrientchart;

    Serie waterseries;

    Serie nutrientseries;

    VirtualHandler vh;

    void Awake()
    {
        GameObject mainCanvas = GameObject.Find("MainCanvas");
        vh = mainCanvas.GetComponent<VirtualHandler>();
        waterseries = waterchart.series.GetSerie(0); 
        nutrientseries = nutrientchart.series.GetSerie(0); 

        updateChart();
        
        VirtualTime.OnTick += VirtualTime_OnTick;
    }

    public void updateChart()
    {
        waterchart.ClearData();
        nutrientchart.ClearData();
        double water = (double) vh.getWater();
        double nutrient = (double) vh.getNutrient();

        if (water >= 50) {
            waterchart.vessel.color = new Color32(0, 92, 6, 255); // outline
            waterseries.itemStyle.color = new Color32(0, 92, 6, 220); // liquid

        } else {
            waterchart.vessel.color = new Color32(166, 0, 17, 255);
            waterseries.itemStyle.color = new Color32(166, 0, 17, 220);
        }

        if (nutrient >= 50) {
            nutrientchart.vessel.color = new Color32(0, 92, 6, 255); // outline
            nutrientseries.itemStyle.color = new Color32(79, 37, 0, 255); // nutrient

        } else {
            nutrientchart.vessel.color = new Color32(166, 0, 17, 255);
            nutrientseries.itemStyle.color = new Color32(174, 139, 114, 220);
        }
        waterchart.AddData(0, water);
        nutrientchart.AddData(0, nutrient);
    }

    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e)
    {
        updateChart();
    }
}
