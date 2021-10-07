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
        LoadReal();
        change_nutrient_level_text();
    }

    public void nutrient_button()
    {
        nutrient_level += 50;
    }
    public void change_nutrient_level_text()
    {
        nutrient_level_text.text = "Nutrient Level  " + nutrient_level;
    }
    public void reset_nutrient_level()
    {
        nutrient_level = 50;
    }

    // Save & Load
    public void SaveReal()
    {
        RealSave.SaveRealDataNutrient(this);
    }
    public void LoadReal()
    {
        RealData data = RealSave.LoadRealDataNutrient();
        if (data != null)
        {
            nutrient_level = data.nutrient_level;
        }
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SaveReal();
            SceneManager.LoadScene("NewGame");
        }
    }
}
