using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VirtualNutrient : MonoBehaviour
{
    TextMeshProUGUI nutrient_level_text;
    public int nutrient_level = 50;

    public void Init(TextMeshProUGUI text) {
        nutrient_level_text = text;
        change_nutrient_level_text();
        VirtualTime.OnTick += VirtualTime_OnTick;
    }

    public void change_nutrient_level_text() {
        nutrient_level_text.text = "nutrient Level   " + nutrient_level;
    }

    public void nutrient_button() {
        nutrient_level += 50;
        change_nutrient_level_text();
    }

    public void reset_button() {
        nutrient_level = 50;
        change_nutrient_level_text();
    }

    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e) {
        nutrient_level--;
        change_nutrient_level_text();
    }
}
