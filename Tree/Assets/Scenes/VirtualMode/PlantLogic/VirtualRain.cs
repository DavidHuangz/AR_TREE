using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class VirtualRain : MonoBehaviour
{
    TextMeshProUGUI rain_text;
    TextMeshProUGUI rainfall_text;
    public List<double> rain_data;
    public bool rainy = false;
    
    public void Init(TextMeshProUGUI rain_button, TextMeshProUGUI rainfall) {
        rain_data = new List<double>{0};
        rain_text = rain_button;
        rainfall_text = rainfall;
        change_rainfall_text();
        VirtualTime.OnTick += VirtualTime_OnTick;
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

    public void change_rainfall_text() {
        rainfall_text.text = "Rainfall = " + rain_data_total();
    }

    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e) {
        // only keep newest 7 points of rain data
        if (rain_data.Count >= 7) {
            rain_data.RemoveAt(0);
        } 
        rain_data.Add(rainy ? 1 : 0);
        change_rainfall_text();
    }
}
