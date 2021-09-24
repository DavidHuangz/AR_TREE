using System.Collections;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class FillColor : MonoBehaviour
{
    public Slider slider1; //connected the slider

    public Image slider1Fill; //connected the Image Fill from the slider

    // Start is called before the first frame update
    void Start()
    {
        slider1Fill.color =
            Color.Lerp(Color.green, Color.green, slider1.value / 100);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
