using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlaceObject : MonoBehaviour
{
    private VirtualHandler vh;

    public GameObject plantButton;

    public GameObject normalSoil;

    public GameObject wetSoil;

    public GameObject drySoil;

    public GameObject seedling;

    public GameObject sapling;

    public GameObject tree;

    public GameObject field;

    public GameObject rainDrop;

    // Objects that need to be Destroyed or instantited
    private GameObject PlantObject;

    private GameObject SoilObject;

    private GameObject WeatherObject;

    public GameObject placementIndicator;

    private Pose PlacementPose;

    private ARRaycastManager aRRaycastManager;

    private bool placementPoseIsValid;

    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        GameObject mainCanvas = GameObject.Find("MainCanvas");
        vh = mainCanvas.GetComponent<VirtualHandler>();
        placementPoseIsValid = false;
        PlantObject = null;
        SoilObject = null;
        WeatherObject = null;
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
        PlantGrowthStage();
        SoilStatus();
    }

    public bool seedlingPlaced()
    {
        if (PlantObject == null)
        {
            return false;
        }
        return true;
    }

    private void PlantGrowthStage()
    {
        int stage = (int) vh.getGrowth();
        if (stage > 20)
        {
            Destroy (PlantObject);
            PlantObject =
                Instantiate(field,
                PlacementPose.position,
                PlacementPose.rotation);
        }
        else if (stage > 10)
        {
            Destroy (PlantObject);
            PlantObject =
                Instantiate(tree,
                PlacementPose.position,
                PlacementPose.rotation);
        }
        else if (stage > 2)
        {
            Destroy (PlantObject);
            PlantObject =
                Instantiate(sapling,
                PlacementPose.position,
                PlacementPose.rotation);
        }
    }

    public void PlantSeedling()
    {
        // Remove indicaitor and plantbutton
        Destroy (placementIndicator);
        Destroy (plantButton);

        SoilObject =
            Instantiate(normalSoil,
            PlacementPose.position,
            PlacementPose.rotation);
        PlantObject =
            Instantiate(seedling,
            PlacementPose.position,
            PlacementPose.rotation);
    }

    public void PlaceRainDrop()
    {
        Destroy (WeatherObject);
        WeatherObject =
            Instantiate(rainDrop,
            PlacementPose.position,
            PlacementPose.rotation);
    }

    private void SoilStatus()
    {
        int waterStatus = (int) vh.getWater();

        // Too much water
        if (waterStatus > 100)
        {
            Destroy (SoilObject);
            SoilObject =
                Instantiate(wetSoil,
                PlacementPose.position,
                PlacementPose.rotation);
        } // Little
        else if (waterStatus < 50)
        {
            Destroy (SoilObject);
            SoilObject =
                Instantiate(drySoil,
                PlacementPose.position,
                PlacementPose.rotation);
        }
        else
        // Normal Water
        {
            Destroy (SoilObject);
            SoilObject =
                Instantiate(normalSoil,
                PlacementPose.position,
                PlacementPose.rotation);
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
