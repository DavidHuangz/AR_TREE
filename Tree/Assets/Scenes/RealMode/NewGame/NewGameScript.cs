using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void WaterCanMode()
    {
        SceneManager.LoadScene("WaterCan");
    }

    public void NutrientMode()
    {
        SceneManager.LoadScene("Nutrient");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("RealPlantModeMenu");
        }
    }
}