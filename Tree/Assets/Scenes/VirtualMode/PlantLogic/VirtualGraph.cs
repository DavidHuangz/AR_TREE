using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

public class VirtualGraph : MonoBehaviour
{
    public LiquidChart waterchart;

    Serie waterseries;

    VirtualHandler vh;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject mainCanvas = GameObject.Find("MainCanvas");
        vh = mainCanvas.GetComponent<VirtualHandler>();
        waterseries = waterchart.series.GetSerie(0); 

        updateChart();
        
        VirtualTime.OnTick += VirtualTime_OnTick;
    }

    public void updateChart()
    {
        waterchart.ClearData();
        double water = (double) vh.getWater();
        if (water >= 50) {
            waterchart.vessel.color = new Color32(0, 92, 6, 255); // outline
            waterseries.itemStyle.color = new Color32(0, 92, 6, 220); // liquid

        } else {
            waterchart.vessel.color = new Color32(166, 0, 17, 255);
            waterseries.itemStyle.color = new Color32(166, 0, 17, 220);
        }
        waterchart.AddData(0, water);
    }

    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e)
    {
        updateChart();
    }
}
