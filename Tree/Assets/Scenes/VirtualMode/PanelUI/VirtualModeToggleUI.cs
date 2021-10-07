using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VirtualModeToggleUI : MonoBehaviour
{
    public GameObject Water;

    public GameObject Nutrient;

    public GameObject Main;

    public AudioSource BtnSound;

    void start()
    {
    }

    public void setWaterActive()
    {
        BtnSound.Play();
        Water.transform.gameObject.SetActive(true);
        Main.transform.gameObject.SetActive(false);
    }

    public void setNutrientActive()
    {
        BtnSound.Play();
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
