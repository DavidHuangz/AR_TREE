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

    private string speedTxtBackup;

    // Button panel
    public GameObject PauseBtn;

    public GameObject ResumeBtn;

    private void Awake()
    {
        GameObject interaction = GameObject.Find("Interaction");
        virtualPlant = interaction.GetComponent<TapToPlaceObject>();

        PauseBtn.transform.gameObject.SetActive(false);
        ResumeBtn.transform.gameObject.SetActive(true);

        speedTxt.text = "Time: Normal";
        speedTxtBackup = speedTxt.text;
        tickMaxTime = 5f;
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
            PauseBtn.transform.gameObject.SetActive(true);
            ResumeBtn.transform.gameObject.SetActive(false);
            speedTxt.text = "Time: Stop";
            tickMaxTimeBackup = tickMaxTime;
            tickMaxTime = 0f;
        }
        else
        {
            ResumeBtn.transform.gameObject.SetActive(true);
            PauseBtn.transform.gameObject.SetActive(false);
            speedTxt.text = speedTxtBackup;
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
                speedTxt.text = "Time: Fast";
                tickMaxTime = 3f;
                tickTimer = 0;
                break;
            // 1min
            case 3f:
                speedTxt.text = "Time: Normal";
                tickMaxTime = 5f;
                tickTimer = 0;
                break;
            // 1hr
            case 5f:
                // Max range is 24hrs
                speedTxt.text = "Time: Slow";
                tickMaxTime = 10f;
                tickTimer = 0;
                break;
            default:
                break;
        }
        speedTxtBackup = speedTxt.text;
    }

    public void Fastforward()
    {
        btnSound.Play();

        switch (tickMaxTime)
        {
            // 1min
            case 3f:
                // min range is 1s
                speedTxt.text = "Time: Fastest";
                tickMaxTime = 1f;
                tickTimer = 0;
                break;
            // 1hr
            case 5f:
                speedTxt.text = "Time: Fast";
                tickMaxTime = 3f;
                tickTimer = 0;
                break;
            // day
            case 10f:
                speedTxt.text = "Time: Normal";
                tickMaxTime = 5f;
                tickTimer = 0;
                break;
            default:
                break;
        }
        speedTxtBackup = speedTxt.text;
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
