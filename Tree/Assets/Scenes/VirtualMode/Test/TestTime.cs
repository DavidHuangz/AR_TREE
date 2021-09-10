using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTime : MonoBehaviour
{

    public class OnTickEventArgs : EventArgs {
        public int tick;
    }

    public static event EventHandler<OnTickEventArgs> OnTick;

    private float tickMaxTime = 1f;
    private int tick;
    private float tickTimer;

    private void Awake() {
        tick = 0;
    }

    void Update() {
        tickTimer += Time.deltaTime;
        if (tickTimer >= tickMaxTime) {
            tickTimer -= tickMaxTime;
            tick++;
            if (OnTick != null) {
                OnTick(this, new OnTickEventArgs {tick = tick});
            }
         }
    }

}
