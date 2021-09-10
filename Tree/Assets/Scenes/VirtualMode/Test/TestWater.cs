using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TestWater : MonoBehaviour
{
    TestRain rain;
    TextMeshProUGUI water_level_text;
    TextMeshProUGUI rainfall_text;
    public int water_level = 50;

    public void TestWaterInit(TestRain rain_object, TextMeshProUGUI text, TextMeshProUGUI rainfall) {
        water_level_text = text;
        rainfall_text = rainfall;
        rain = rain_object;
        change_water_level_text();
        TestTime.OnTick += delegate (object sender, TestTime.OnTickEventArgs e) {};
        TestTime.OnTick += TestTime_OnTick;
    }

    public void change_water_level_text() {
        water_level_text.text = "Water Level   " + water_level;
        rainfall_text.text = "Rain =  " + rain.rain_data_total();
    }

    public void water_button() {
        water_level += 50;
        change_water_level_text();
    }

    public void reset_button() {
        water_level = 50;
        change_water_level_text();
    }

    public void TestTime_OnTick(object sender, TestTime.OnTickEventArgs e) {
        if (rain.rain_data_total() < 2) {
            water_level -= 2;
        } else {
            water_level--;
        }
        change_water_level_text();
    }
}
