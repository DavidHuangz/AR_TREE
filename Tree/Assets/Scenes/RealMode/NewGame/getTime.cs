using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class getTime : MonoBehaviour
{
    public GameObject txt;
    // Start is called before the first frame update
    void Start()
    {
        txt.GetComponent<UnityEngine.UI.Text>().text = "--";
    }

    // Update is called once per frame
    public void setTime()
    {
        var date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        txt.GetComponent<UnityEngine.UI.Text>().text = date;
    }
}
