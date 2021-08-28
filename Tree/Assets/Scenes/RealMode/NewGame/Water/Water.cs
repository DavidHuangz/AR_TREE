using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    public TextMeshProUGUI water_level_text;
    public int water_level = 50;

    void Start() {
        LoadVirtual();
        change_water_level_text();
    }

    public void water_button() {
        water_level += 50;
    }
    public void change_water_level_text() {
        water_level_text.text = "Water Level:  " + water_level;
    }
    public void reset_water_level () {
        water_level = 50;
    }

    // Save & Load
    public void SaveVirtual() {
        VirtualSave.SaveVirtualData(this);
    }
    public void LoadVirtual() {
        VirtualData data = VirtualSave.LoadVirtualData();
        if (data != null) {
            water_level = data.water_level;
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
