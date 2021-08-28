using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Nutrient : MonoBehaviour
{
    public TextMeshProUGUI nutrient_level_text;
    public int nutrient_level = 50;

    void Start()
    {
        LoadVirtual();
        change_nutrient_level_text();
    }

    public void nutrient_button()
    {
        nutrient_level += 50;
    }
    public void change_nutrient_level_text()
    {
        nutrient_level_text.text = "Nutrient Level: " + nutrient_level;
    }
    public void reset_nutrient_level()
    {
        nutrient_level = 50;
    }

    // Save & Load
    public void SaveVirtual()
    {
        VirtualSave.SaveVirtualDataNutrient(this);
    }
    public void LoadVirtual()
    {
        VirtualData data = VirtualSave.LoadVirtualDataNutrient();
        if (data != null)
        {
            nutrient_level = data.nutrient_level;
        }
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SaveVirtual();
            SceneManager.LoadScene("NewGame");
        }
    }
}
