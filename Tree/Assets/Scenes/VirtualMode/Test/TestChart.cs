using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

public class TestChart : MonoBehaviour
{
    int i = 0;

    public LineChart chart;

    public BarChart bchart;

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
        chart.AddSerie(SerieType.Bar);
        chart.AddSerie(SerieType.Line);

        // bchart.title.text = "Bar";
        // bchart.title.show = true;
        // bchart.ClearData();
    }

    public void TestTime_OnTick(object sender, TestTime.OnTickEventArgs e)
    {
        chart.AddXAxisData("" + i);
        chart.AddData(0, th.getWater());
        chart.AddData(1, th.getGrowth());
        i++;
    }
}
