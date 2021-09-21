using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VirtualNutrient : MonoBehaviour
{
    TextMeshProUGUI nutrient_level_text;

    public List<int> nutrient_data;

    public int nutrient_level = 50;

    public void Init(TextMeshProUGUI text)
    {
        nutrient_level_text = text;
        change_nutrient_level_text();
        nutrient_data = new List<int> { nutrient_level };
        VirtualTime.OnTick += VirtualTime_OnTick;
    }

    public void change_nutrient_level_text()
    {
        nutrient_level_text.text = "nutrient Level   " + nutrient_level;
        Debug.Log("nutrient text");
    }

    public void nutrient_button()
    {
        nutrient_level += 50;
        change_nutrient_level_text();
    }

    public void reset_button()
    {
        nutrient_level = 50;
        change_nutrient_level_text();
    }

    public void VirtualTime_OnTick(object sender, VirtualTime.OnTickEventArgs e)
    {
        nutrient_level--;
        change_nutrient_level_text();
        nutrient_data.Add (nutrient_level);
        Debug.Log("nutrient");
    }
}
