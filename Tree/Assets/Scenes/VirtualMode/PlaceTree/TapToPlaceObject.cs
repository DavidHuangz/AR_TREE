using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlaceObject : MonoBehaviour
{
    private VirtualHandler vh;

    // Audio
    public AudioSource heavyRainSound;

    public AudioSource plantSound;

    public AudioSource waterCanSound;

    public AudioSource nutrientSound;

    // Game objects
    public GameObject plantButton;

    public GameObject normalSoil;

    public GameObject wetSoil;

    public GameObject drySoil;

    public GameObject seed;

    public GameObject seedling;

    public GameObject seedlingLeaf;

    public GameObject sapling;

    public GameObject forest;

    public GameObject field;

    public GameObject rain;

    public GameObject nutrientParticles;

    public GameObject waterCanParticles;

    // Objects that need to be Destroyed or instantited
    private GameObject PlantObject;

    private GameObject SoilObject;

    private GameObject WeatherObject;

    private GameObject particleObject;

    public GameObject placementIndicator;

    private Pose PlacementPose;

    private ARRaycastManager aRRaycastManager;

    private bool placementPoseIsValid;

    // Prevent repeated instantiation of the same object
    private int soil;

    private int plant;

    private int weather;

    // Settings
    public float particleTime = 5.0f;

    public bool rainStatus;

    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        GameObject mainCanvas = GameObject.Find("MainCanvas");
        vh = mainCanvas.GetComponent<VirtualHandler>();
        placementPoseIsValid = false;
        PlantObject = null;
        SoilObject = null;
        WeatherObject = null;
        particleObject = null;
        soil = 0;
        plant = 0;
        rainStatus = false;
        plantButton.transform.gameObject.SetActive(false);
    }

    void Update()
    {
        // Only have indcator if plant is not spawned yet
        if (PlantObject == null)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
        }
        PlantStatus();
        SoilStatus();
        WeatherStatus();
    }

    // Check if first seed is placed
    public bool seedlingPlaced()
    {
        if (PlantObject == null)
        {
            return false;
        }
        return true;
    }

    // Change plant appearance depending on growth percentage
    private void PlantStatus()
    {
        int stage = (int) vh.getGrowth();
        if (stage > 84 && plant != 5)
        {
            plant = 5;

            Destroy (PlantObject);
            PlantObject =
                Instantiate(field,
                PlacementPose.position,
                PlacementPose.rotation);
        }
        else if (stage > 58 && plant < 4)
        {
            plant = 4;

            Destroy (PlantObject);
            PlantObject =
                Instantiate(forest,
                PlacementPose.position,
                PlacementPose.rotation);
        }
        else if (stage > 36 && plant < 3)
        {
            plant = 3;

            Destroy (PlantObject);
            PlantObject =
                Instantiate(sapling,
                PlacementPose.position,
                PlacementPose.rotation);
        }
        else if (stage > 20 && plant < 2)
        {
            plant = 2;

            Destroy (PlantObject);
            PlantObject =
                Instantiate(seedlingLeaf,
                PlacementPose.position,
                PlacementPose.rotation);
        }
        else if (stage > 5 && plant < 1)
        {
            plant = 1;

            Destroy (PlantObject);
            PlantObject =
                Instantiate(seedling,
                PlacementPose.position,
                PlacementPose.rotation);
        }
    }

    // First time planting soil and seed
    public void PlantSeedling()
    {
        // Remove indicaitor and plantbutton
        Destroy (placementIndicator);
        Destroy (plantButton);
        placementPoseIsValid = false;

        SoilObject =
            Instantiate(drySoil,
            PlacementPose.position,
            PlacementPose.rotation);
        PlantObject =
            Instantiate(seed, PlacementPose.position, PlacementPose.rotation);

        plantSound.Play();
    }

    public void RainStatus()
    {
        rainStatus = !rainStatus;
    }

    // Show particles for nutrient button
    public void showNutrientParticles()
    {
        nutrientSound.Play();

        Destroy (particleObject);
        particleObject =
            Instantiate(nutrientParticles,
            PlacementPose.position,
            PlacementPose.rotation);
        Destroy (particleObject, particleTime);
    }

    // Show particles for water can button
    public void showWaterCanParticles()
    {
        waterCanSound.Play();

        Destroy (particleObject);
        particleObject =
            Instantiate(waterCanParticles,
            PlacementPose.position,
            PlacementPose.rotation);
        Destroy (particleObject, particleTime);
    }

    // Change weather effects depending on weather
    public void WeatherStatus()
    {
        if (rainStatus && weather < 1)
        {
            weather = 1;
            Destroy (WeatherObject);

            WeatherObject =
                Instantiate(rain,
                PlacementPose.position,
                PlacementPose.rotation);

            heavyRainSound.Play();
        }
        else if (!rainStatus && weather > 0)
        {
            weather = 0;
            Destroy (WeatherObject);
            heavyRainSound.Stop();
        }
    }

    private void SoilStatus()
    {
        int waterStatus = (int) vh.getWater();

        // Soil and placement indicator together
        if (placementPoseIsValid)
        {
            Destroy (SoilObject);
            SoilObject =
                Instantiate(drySoil,
                PlacementPose.position,
                PlacementPose.rotation);
        }

        // Change soil appearance depeneding on water level
        if (seedlingPlaced())
        {
            // Too much water
            if (waterStatus > 100 && soil != 3)
            {
                soil = 3;
                Destroy (SoilObject);
                SoilObject =
                    Instantiate(wetSoil,
                    PlacementPose.position,
                    PlacementPose.rotation);
            } // Little
            else if (waterStatus < 50 && soil != 2)
            {
                soil = 2;
                Destroy (SoilObject);
                SoilObject =
                    Instantiate(drySoil,
                    PlacementPose.position,
                    PlacementPose.rotation);
            }
            else if ((waterStatus >= 50 && waterStatus <= 100) && soil != 1)
            // Normal Water
            {
                soil = 1;
                Destroy (SoilObject);
                SoilObject =
                    Instantiate(normalSoil,
                    PlacementPose.position,
                    PlacementPose.rotation);
            }
        }
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            // Toggle plantButton on
            plantButton.transform.gameObject.SetActive(true);
            placementIndicator.SetActive(true);
            placementIndicator
                .transform
                .SetPositionAndRotation(PlacementPose.position,
                PlacementPose.rotation);
        }
        else
        {
            // Toggle plantButton off
            plantButton.transform.gameObject.SetActive(false);
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter =
            Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing =
                new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            PlacementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}
