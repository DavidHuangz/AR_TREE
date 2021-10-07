using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getTime : MonoBehaviour
{
    public GameObject water_txt;

    public GameObject fertilise_txt;

    public GameObject lifetime_txt;

    void Start()
    {
        water_txt.GetComponent<UnityEngine.UI.Text>().text = "--";
        fertilise_txt.GetComponent<UnityEngine.UI.Text>().text = "--";
        lifetime_txt.GetComponent<UnityEngine.UI.Text>().text = "--";
    }

    public void setWater()
    {
        var date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        water_txt.GetComponent<UnityEngine.UI.Text>().text = date;
    }

    public void setFertile()
    {
        var date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        fertilise_txt.GetComponent<UnityEngine.UI.Text>().text = date;
    }

    public void setLifetime()
    {
        lifetime_txt.GetComponent<UnityEngine.UI.Text>().text = "";
    }
}
