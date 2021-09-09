using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth
{

// // 0% -  50% plant lack
// // 50% - 100% plant healthy
// // 100% - ∞% plant too much

// // Nutrient level decreases by 50% per year, ~1% per week, 0.13% per day

// // Water level decreases 5% per day
// // Rainfall of 2.5cm a week will make the water level decrease by 2.5% per day instead

//     public bool healthy;
//     public float growth_level;

//     void CheckHealth () {
//         water_level = Water.water_level;
//         nutrient_level = Nutrient.nutrient_level;

//         if (water_level > 50 && water_level < 100) {
//             if (nutrient_level > 50 && nutrient_level < 100) {
//                 healthy = true;
//             }
//             healthy = false;
//         } else {
//             healthy = false;
//         }
//     }

//     void UpdateGrowth() {
//         if (healthy) {
//             int days = 1; // compare the days for the number of days growth
//             growth_level += 0.036 * days; // per day percentage growth
//         }
//     }

}
