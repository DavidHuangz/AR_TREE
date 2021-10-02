using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCheckWeatherMoreInfo : MonoBehaviour
{
    public GameObject moreInfoPanel;

    public GameObject WeatherPanel;

    public GameObject WeatherBt;

    public AudioSource checkInfoBtnSound;

    // Open panel
    public void openPanel()
    {
        checkInfoBtnSound.Play();
        moreInfoPanel.transform.gameObject.SetActive(true);
        WeatherPanel.transform.gameObject.SetActive(false);
        WeatherBt.transform.gameObject.SetActive(false);
    }

    // Close panel
    public void closePanel()
    {
        checkInfoBtnSound.Play();
        moreInfoPanel.transform.gameObject.SetActive(false);
        WeatherPanel.transform.gameObject.SetActive(true);
        WeatherBt.transform.gameObject.SetActive(true);
    }
}
