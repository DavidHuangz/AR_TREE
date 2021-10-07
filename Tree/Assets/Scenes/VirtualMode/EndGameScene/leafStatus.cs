using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class leafStatus : MonoBehaviour
{
    private VirtualChart vc;

    public Sprite deadLeaf;

    public Sprite waterShortageLeaf;

    public Sprite nutrientShortageLeaf;

    private Image leafImage;

    void Start()
    {
        GameObject mainCanvas = GameObject.Find("MainCanvas");
        vc = mainCanvas.GetComponent<VirtualChart>();
        leafImage = this.GetComponent<Image>();

        if (vc.condition == "water")
        {
            leafImage.sprite = waterShortageLeaf;
        }
        else if (vc.condition == "nutrient")
        {
            leafImage.sprite = nutrientShortageLeaf;
        }
        else
        {
            leafImage.sprite = deadLeaf;
        }
    }
}
