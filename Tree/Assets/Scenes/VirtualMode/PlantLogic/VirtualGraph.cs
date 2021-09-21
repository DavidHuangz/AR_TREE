using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

public class VirtualGraph : MonoBehaviour
{
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

        updateChart();

        VirtualTime.OnTick += VirtualTime_OnTick;
    }

    public void updateChart()
    {
        double water = (double) vh.getWater();
        double nutrient = (double) vh.getNutrient();

        waterchart.ClearData();
        nutrientchart.ClearData();

        if (water >= 50)
        {
            // Set colours to green
            waterchart.vessel.color = new Color32(0, 92, 6, 255); // outline
            waterseries.itemStyle.color = new Color32(0, 92, 6, 220); // liquid
        }
        else
        {
            // Set colours to red
            waterchart.vessel.color = new Color32(166, 0, 17, 255);
            waterseries.itemStyle.color = new Color32(166, 0, 17, 220);
        }

        if (nutrient >= 50)
        {
            // Set colours to green & dark brown
            nutrientchart.vessel.color = new Color32(0, 92, 6, 255); // outline
            nutrientseries.itemStyle.color = new Color32(79, 37, 0, 255); // nutrient
        }
        else
        {
            // Set colours to red & light brown
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
