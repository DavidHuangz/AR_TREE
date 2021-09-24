using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeafHealthStatus : MonoBehaviour
{
    public Sprite healthlyLeaf;

    public Sprite deadLeaf;

    public Sprite waterShortageLeaf;

    public Sprite nutrientShortageLeaf;

    private Image leafImage;

    // Access other classes
    private VirtualHandler vh;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject mainCanvas = GameObject.Find("UIManager");
        vh = mainCanvas.GetComponent<VirtualHandler>();
        leafImage = this.GetComponent<Image>();
        leafImage.sprite = healthlyLeaf;
    }

    // Update is called once per frame
    void Update()
    {
        leafStatus();
    }

    private void leafStatus()
    {
        int waterStatus = (int) vh.getWater();
        int nutrientStatus = (int) vh.getNutrient();

        if (nutrientStatus < 50 && waterStatus < 50)
        {
            // Too little water and nutrient
            leafImage.sprite = deadLeaf;
        }
        else if (waterStatus < 50)
        {
            // Too little water
            leafImage.sprite = waterShortageLeaf;
        }
        else if (nutrientStatus < 50)
        {
            // Too little nutrient
            leafImage.sprite = nutrientShortageLeaf;
        }
        else
        {
            // Healthly leaf
            leafImage.sprite = healthlyLeaf;
        }
    }
}
