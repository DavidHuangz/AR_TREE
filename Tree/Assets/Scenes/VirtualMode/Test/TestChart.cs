using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

public class TestChart : MonoBehaviour
{
    int i = 0;

    public LineChart chart;

    public BarChart bchart;

    public LiquidChart lchart;

    Serie waterseries;

    TestHandler th;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        th = canvas.GetComponent<TestHandler>();

        chartSetup();
        TestTime.OnTick += TestTime_OnTick;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void chartSetup()
    {
        chart.title.text = "Line Simple";
        chart.title.show = true;

        // chart.xAxes[0].show = true;
        // chart.xAxes[1].show = false;
        // chart.yAxes[0].show = true;
        // chart.yAxes[1].show = false;
        // chart.xAxes[0].type = Axis.AxisType.Category;
        // chart.yAxes[0].type = Axis.AxisType.Value;
        // chart.xAxes[0].splitNumber = 10;
        chart.xAxes[0].boundaryGap = true;
        chart.ClearData();

        // bchart.title.text = "Bar";
        // bchart.title.show = true;
        // bchart.ClearData();

        lchart.ClearData();
        waterseries = lchart.series.GetSerie(0); 
    }

    public void TestTime_OnTick(object sender, TestTime.OnTickEventArgs e)
    {
        chart.AddXAxisData("" + i);
        chart.AddData(0, th.getWater());
        chart.AddData(1, th.getGrowth());
        i++;
        lchart.ClearData();
        double water = th.getWater();
        if (water >= 50) {
            lchart.vessel.color = new Color32(0, 92, 6, 255);
            waterseries.itemStyle.color = new Color32(0, 92, 6, 255);

        } else {
            lchart.vessel.color = new Color32(166, 0, 17, 255);
            waterseries.itemStyle.color = new Color32(166, 0, 17, 255);
        }
        lchart.AddData(0, th.getWater());
    }
}
