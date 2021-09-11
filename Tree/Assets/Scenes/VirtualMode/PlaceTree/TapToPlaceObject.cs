using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlaceObject : MonoBehaviour
{
    private VirtualHandler vh;

    public GameObject normalSoil;

    public GameObject wetSoil;

    public GameObject seedling;

    public GameObject sapling;

    public GameObject tree;

    public GameObject field;

    public GameObject rainDrop;

    private float

            startTime,
            endTime;

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
        GameObject mainCanvas = GameObject.Find("MainCanvas");
        vh = mainCanvas.GetComponent<VirtualHandler>();
        placementPoseIsValid = false;
        PlantObject = null;
        SoilObject = null;
        WeatherObject = null;
        startTime = 0f;
        endTime = 0f;
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        // Only have indcator if plant is not spawned yet
        if (PlantObject == null)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
            if (CheckForLongPress())
            {
                placementIndicator.SetActive(false); // Remove placement indicator
                PlaceObject();
            }
        }
        PlantGrowthStage();
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

    private bool CheckForLongPress()
    {
        if (
            placementPoseIsValid &&
            Input.touchCount > 0 &&
            Input.touches[0].phase == TouchPhase.Began
        )
        {
            // If the user puts her finger on screen
            startTime = Time.time;
        }
        else if (Input.touches[0].phase == TouchPhase.Ended)
        {
            // If the user raises her finger from screen
            endTime = Time.time;
        }

        if ((endTime - startTime) > 2f)
        {
            // Long press for two second
            startTime = 0f;
            endTime = startTime;
            return true;
        }
        return false;
    }

    private void PlaceObject()
    {
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

    public void PlaceWetSoil()
    {
        Destroy (SoilObject);
        SoilObject =
            Instantiate(wetSoil,
            PlacementPose.position,
            PlacementPose.rotation);
    }

    public void PlaceNormalSoil()
    {
        Destroy (SoilObject);
        SoilObject =
            Instantiate(normalSoil,
            PlacementPose.position,
            PlacementPose.rotation);
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator
                .transform
                .SetPositionAndRotation(PlacementPose.position,
                PlacementPose.rotation);
        }
        else
        {
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
