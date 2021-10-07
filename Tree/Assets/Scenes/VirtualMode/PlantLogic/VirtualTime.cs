using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VirtualTime : MonoBehaviour
{
    // Audio
    public AudioSource btnSound;

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
        GameObject interaction = GameObject.Find("Interaction");
        virtualPlant = interaction.GetComponent<TapToPlaceObject>();

        speedTxt.text = "Growth per day";
        tickMaxTime = 86400f;
        tickMaxTimeBackup = tickMaxTime;
        tick = 0;
        ToggleBool = false;
    }

    public void ToggleTime()
    {
        btnSound.Play();

        //Toggle time
        if (!ToggleBool)
        {
            speedTxt.text = "Time: Stop";
            tickMaxTimeBackup = tickMaxTime;
            tickMaxTime = 0f;
        }
        else
        {
            speedTxt.text = "Time: Resume";
            tickMaxTime = tickMaxTimeBackup;
        }
        ToggleBool = !ToggleBool;
    }

    public void FastBackward()
    {
        btnSound.Play();

        switch (tickMaxTime)
        {
            // 1s
            case 1f:
                speedTxt.text = "Growth per min";
                tickMaxTime = 60f;
                tickTimer = 0;
                break;
            // 1min
            case 60f:
                speedTxt.text = "Growth per hr";
                tickMaxTime = 3600f;
                tickTimer = 0;
                break;
            // 1hr
            case 3600f:
                // Max range is 24hrs
                speedTxt.text = "Growth per day";
                tickMaxTime = 86400f;
                tickTimer = 0;
                break;
            default:
                break;
        }
    }

    public void Fastforward()
    {
        btnSound.Play();

        switch (tickMaxTime)
        {
            // 1min
            case 60f:
                // min range is 1s
                speedTxt.text = "Growth per sec";
                tickMaxTime = 1f;
                tickTimer = 0;
                break;
            // 1hr
            case 3600f:
                speedTxt.text = "Growth per min";
                tickMaxTime = 60f;
                tickTimer = 0;
                break;
            // day
            case 86400f:
                speedTxt.text = "Growth per hr";
                tickMaxTime = 3600f;
                tickTimer = 0;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        if (virtualPlant.seedlingPlaced() && tickMaxTime != 0)
        {
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
        }
    }
}
