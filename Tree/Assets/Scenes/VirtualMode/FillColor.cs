using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FillColor : MonoBehaviour
{
    public Slider slider1; //connected the slider

    public Image slider1Fill; //connected the Image Fill from the slider

    // Access other classes
    private VirtualHandler vh;

    // Start is called before the first frame update
    void Start()
    {
        GameObject mainCanvas = GameObject.Find("UIManager");
        vh = mainCanvas.GetComponent<VirtualHandler>();
        slider1Fill.color =
            Color.Lerp(Color.green, Color.green, slider1.value / 100);
    }

    // Update is called once per frame
    void Update()
    {
        growthStatus();
    }

    private void growthStatus()
    {
        int waterStatus = (int) vh.getWater();
        int nutrientStatus = (int) vh.getNutrient();

        if (nutrientStatus < 50 || waterStatus < 50)
        {
            // no growth
            slider1Fill.color =
                Color.Lerp(Color.gray, Color.gray, slider1.value / 100);
        }
        else
        {
            // Growth
            slider1Fill.color =
                Color.Lerp(Color.green, Color.green, slider1.value / 100);
        }
    }
}
