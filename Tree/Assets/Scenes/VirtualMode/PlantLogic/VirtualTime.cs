using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VirtualTime : MonoBehaviour
{
    public TextMeshProUGUI speedTxt;

    public class OnTickEventArgs : EventArgs
    {
        public int tick;
    }

    public static event EventHandler<OnTickEventArgs> OnTick;

    TapToPlaceObject virtualPlant;

    private float tickMaxTime;

    private float tickMaxTimeBackup;

    private int tick;

    private float tickTimer;

    private bool ToggleBool;

    private void Awake()
    {
        speedTxt.text = "Speed: Normal";
        tickMaxTime = 1f;
        tickMaxTimeBackup = tickMaxTime;
        tick = 0;
        ToggleBool = false;
    }

    private void Start()
    {
        GameObject interaction = GameObject.Find("Interaction");
        virtualPlant = interaction.GetComponent<TapToPlaceObject>();
    }

    public void ToggleTime()
    {
        //Toggle time
        if (!ToggleBool)
        {
            speedTxt.text = "Speed: Stop";
            tickMaxTimeBackup = tickMaxTime;
            tickMaxTime = 0f;
        }
        else
        {
            speedTxt.text = "Speed: Resume";
            tickMaxTime = tickMaxTimeBackup;
        }
        ToggleBool = !ToggleBool;
    }

    public void FastBackward()
    {
        switch (tickMaxTime)
        {
            // 1s
            case 1f:
                speedTxt.text = "Speed: 1min";
                tickMaxTime = 60f;
                break;
            // 1min
            case 60f:
                speedTxt.text = "Speed: 1hr";
                tickMaxTime = 3600f;
                break;
            // 1hr
            case 3600f:
                // Max range is 24hrs
                speedTxt.text = "Speed: 1day";
                tickMaxTime = 86400f;
                break;
            default:
                break;
        }
    }

    public void Fastforward()
    {
        switch (tickMaxTime)
        {
            // 1min
            case 60f:
                // min range is 1s
                speedTxt.text = "Speed: 1s";
                tickMaxTime = 1f;
                break;
            // 1hr
            case 3600f:
                speedTxt.text = "Speed: 1min";
                tickMaxTime = 60f;
                break;
            // day
            case 86400f:
                speedTxt.text = "Speed: 1hr";
                tickMaxTime = 3600f;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        // if (virtualPlant.seedlingPlaced() && tickMaxTime != 0)
        // {
            tickTimer += Time.deltaTime;
            if (tickTimer >= tickMaxTime)
            {
                tickTimer -= tickMaxTime;
                tick++;
                if (OnTick != null)
                {
                    OnTick(this, new OnTickEventArgs { tick = tick });
                }
            }
        // }
    }
}
