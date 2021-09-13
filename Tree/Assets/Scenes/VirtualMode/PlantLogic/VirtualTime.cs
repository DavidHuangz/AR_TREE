using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualTime : MonoBehaviour
{
    public class OnTickEventArgs : EventArgs
    {
        public int tick;
    }

    public static event EventHandler<OnTickEventArgs> OnTick;

    TapToPlaceObject virtualPlant;

    private float tickMaxTime = 1f;

    private int tick;

    private float tickTimer;

    private void Awake()
    {
        tick = 0;
    }

    private void Start()
    {
        GameObject interaction = GameObject.Find("Interaction");
        virtualPlant = interaction.GetComponent<TapToPlaceObject>();
    }

    void Update()
    {
        // if (virtualPlant.seedlingPlaced())
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
