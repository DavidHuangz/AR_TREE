using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VirtualData
{
    public int water_level;
    public int nutrient_level;

    public VirtualData (Water water) {
        water_level = water.water_level;
    }

    public VirtualData (Nutrient nutrient)
    {
        nutrient_level = nutrient.nutrient_level;
    }
}
