using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestHandler : MonoBehaviour
{
    TestWater water;
    TestHealth health;
    public TextMeshProUGUI water_level_text;
    public TextMeshProUGUI growth_text;

    // Start is called before the first frame update
    void Start()
    {
        water = gameObject.AddComponent<TestWater>() as TestWater;
        health = gameObject.AddComponent<TestHealth>() as TestHealth;
        water.TestWaterInit(water_level_text);
        health.TestHealthInit(water, growth_text);
    }

    public void water_button() {
        water.water_button();
    }
}
