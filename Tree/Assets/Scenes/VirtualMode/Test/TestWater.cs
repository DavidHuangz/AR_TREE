using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TestWater : MonoBehaviour
{
    public TextMeshProUGUI water_level_text;
    public int water_level = 50;

    public void TestWaterInit(TextMeshProUGUI text) {
        water_level_text = text;
        change_water_level_text();
        TestTime.OnTick += delegate (object sender, TestTime.OnTickEventArgs e) {};
        TestTime.OnTick += TestTime_OnTick;
    }

    public void change_water_level_text() {
        water_level_text.text = "Water Level   " + water_level;
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
        water_level--;
        change_water_level_text();
    }
}
