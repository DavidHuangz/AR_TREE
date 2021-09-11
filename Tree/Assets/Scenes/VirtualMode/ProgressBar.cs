using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    private Slider slider;

    public float FillSpeed = 0.5f;
    private float targetProgress = 0;
    private float newProgress = 0;

   private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        IncrementProgress(0f);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = newProgress;
    }

    public void IncrementProgress(float target)
    {
        newProgress = target;

    }
}