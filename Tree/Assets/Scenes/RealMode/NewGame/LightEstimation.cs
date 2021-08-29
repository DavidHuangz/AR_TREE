using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using System;

public class LightEstimation : MonoBehaviour
{

    public Color? mainLightColor { get; private set; }

    [SerializeField]
    private ARCameraManager arCameraManager;

    [SerializeField]
    private Text brightnessValue;

    [SerializeField]
    private Text tempValue;

    [SerializeField]
    private Text colorCorrectionValue;

    private Light currentLight;

    private void Awake()
    {
        currentLight = GetComponent<Light>();
    }

    private void OnEnable()
    {
        arCameraManager.frameReceived += FrameUpdated;
    }

    private void OnDisable()
    {
        arCameraManager.frameReceived -= FrameUpdated;
    }

    private void FrameUpdated(ARCameraFrameEventArgs args)
    {
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            brightnessValue.text = $"Brightness: {args.lightEstimation.averageBrightness.Value}";
            currentLight.intensity = args.lightEstimation.averageBrightness.Value;
        }

        if (args.lightEstimation.colorCorrection.HasValue)
        {
            tempValue.text = $"Color correction: {args.lightEstimation.colorCorrection.Value}";
            currentLight.color = args.lightEstimation.colorCorrection.Value;
        }

        if (args.lightEstimation.mainLightColor.HasValue)
        {
            mainLightColor = args.lightEstimation.mainLightColor;
            colorCorrectionValue.text = $"Main Color: {(mainLightColor.Value / Mathf.PI).gamma}";
        }
        }
}