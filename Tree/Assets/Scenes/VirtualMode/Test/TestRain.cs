using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class TestRain : MonoBehaviour
{
    TextMeshProUGUI rain_text;
    public List<double> rain_data;
    public bool rainy = false;
    
    public void TestRainInit(TextMeshProUGUI text) {
        rain_data = new List<double>();
        rain_text = text;
        TestTime.OnTick += TestTime_OnTick;
    }

    public void TestTime_OnTick(object sender, TestTime.OnTickEventArgs e) {
        // only keep newest 7 points of rain data
        if (rain_data.Count >= 2) {
            rain_data.RemoveAt(0);
        } 
        rain_data.Add(rainy ? 1 : 0);
    }

    public double rain_data_total() {
        return rain_data == null ? 0 : rain_data.Sum();
    }

    public void rain_button() {
        rainy = !rainy;
        change_rain_state_text();
    }

    public void change_rain_state_text() {
        rain_text.text = rainy ? "Rain" : "No Rain";
    }
}
