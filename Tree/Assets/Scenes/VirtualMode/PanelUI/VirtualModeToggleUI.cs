using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class VirtualModeToggleUI : MonoBehaviour
{
    public GameObject Water;
    public GameObject Nutrient;
    public GameObject Main;

    void start()
    {
    }

    public void setWaterActive()
    {
        Water.transform.gameObject.SetActive(true);
        Main.transform.gameObject.SetActive(false);
    }

    public void setNutrientActive()
    {
        Nutrient.transform.gameObject.SetActive(true);
        Main.transform.gameObject.SetActive(false);
    }

    public void setMain()
    {
        Main.transform.gameObject.SetActive(true);
        Water.transform.gameObject.SetActive(false);
        Nutrient.transform.gameObject.SetActive(false);
    }
}
