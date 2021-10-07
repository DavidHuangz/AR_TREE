using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestHealth : MonoBehaviour
{
    public TextMeshProUGUI growth_text;
    public double growth = 0;

    TestWater water;
    
    public void TestHealthInit(TestWater water_object, TextMeshProUGUI text)
    {
        water = water_object;
        growth_text = text;
        change_growth_text();
        TestTime.OnTick += TestTime_OnTick;
    }

    public void change_growth_text() {
        growth_text.text = "Growth   " + growth + " %";
    }

    public void TestTime_OnTick(object sender, TestTime.OnTickEventArgs e) {
        if (water.water_level >= 50) {
            growth += 1;
        }
        change_growth_text();
    }
}
