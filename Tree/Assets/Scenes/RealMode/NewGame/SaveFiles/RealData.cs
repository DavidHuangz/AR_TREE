using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RealData
{
    public int water_level;
    public int nutrient_level;

    public RealData (Water water) {
        water_level = water.water_level;
    }

    public RealData (Nutrient nutrient)
    {
        nutrient_level = nutrient.nutrient_level;
    }
}
