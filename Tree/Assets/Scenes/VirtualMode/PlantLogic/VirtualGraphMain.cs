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

    Serie waterseries;

    Serie nutrientseries;

    private VirtualHandler vh;

    // Start is called before the first frame update
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

    public void updateChart()
    {
        double water = (double) vh.getWater();
        double nutrient = (double) vh.getNutrient();
        double growth = (double) vh.getGrowth();

        waterchart.ClearData();
        nutrientchart.ClearData();

        if (water >= 50)
        {
            waterchart.vessel.color = new Color32(0, 92, 6, 255); // outline
            waterseries.itemStyle.color = new Color32(0, 92, 6, 220); // liquid
        }
        else
        {
            waterchart.vessel.color = new Color32(166, 0, 17, 255);
            waterseries.itemStyle.color = new Color32(166, 0, 17, 220);
        }

        if (nutrient >= 50)
        {
            nutrientchart.vessel.color = new Color32(0, 92, 6, 255); // outline
            nutrientseries.itemStyle.color = new Color32(79, 37, 0, 255); // nutrient
        }
        else
        {
            nutrientchart.vessel.color = new Color32(166, 0, 17, 255);
            nutrientseries.itemStyle.color = new Color32(174, 139, 114, 220);
        }
        waterchart.AddData(0, water);
        nutrientchart.AddData(0, nutrient);

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
