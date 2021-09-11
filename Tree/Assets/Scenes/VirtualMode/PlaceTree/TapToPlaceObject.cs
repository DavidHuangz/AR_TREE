using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;

public class TapToPlaceObject : MonoBehaviour
{
    public GameObject normalSoil;
    public GameObject wetSoil;
    public GameObject seedling;
    public GameObject sapling;
    public GameObject tree;
    public GameObject field;
    public GameObject rainDrop;

    private int stage;
    private float startTime, endTime;


    // Objects that need to be Destroyed or instantited
    private GameObject PlantObject;
    private GameObject SoilObject;
    private GameObject WeatherObject;

    public GameObject placementIndicator;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    void Start()
    {
        PlantObject = null;
        SoilObject = null;
        WeatherObject = null;
        startTime = 0f;
        endTime = 0f;
        stage = 0;
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        // Only have indcator if plant is not spawned yet 
        if (PlantObject == null) {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
            if (CheckForLongPress())
                {
                    placementIndicator.SetActive(false); // Remove placement indicator
                    PlaceObject();
                }
        } 
    }

	private bool CheckForLongPress() {
		if (placementPoseIsValid && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) { // If the user puts her finger on screen
        startTime = Time.time;
        }

        if (Input.touches[0].phase == TouchPhase.Ended) { // If the user raises her finger from screen
        endTime = Time.time;
        }

        if (endTime - startTime > 2f) { // Long press for one second 
            return true;
            startTime = 0f;
            endTime = 0;
        }
        return false;
	}

    private void PlaceObject()
    {
    // switch (stage)
    // {
    //     case 1:
    //         PlantObject = Instantiate(seedling, PlacementPose.position, PlacementPose.rotation);
    //         break;

    //     case 2:
    //         PlantObject = Instantiate(sapling, PlacementPose.position, PlacementPose.rotation);
    //         break;

    //     case 3:
    //         PlantObject = Instantiate(tree, PlacementPose.position, PlacementPose.rotation);
    //         break;

    //     case 4:
    //         PlantObject = Instantiate(field, PlacementPose.position, PlacementPose.rotation);
    //         break;
    
    //     default:
    //         break;
    // }
        SoilObject = Instantiate(normalSoil, PlacementPose.position, PlacementPose.rotation);
        PlantObject = Instantiate(seedling, PlacementPose.position, PlacementPose.rotation);
        // stage++;
    }

    public void PlaceRainDrop() {
        Destroy(WeatherObject);
        WeatherObject = Instantiate(rainDrop, PlacementPose.position, PlacementPose.rotation);
    }

    public void PlaceFieldAppleTree() {
        Destroy(PlantObject);
        SoilObject = Instantiate(field, PlacementPose.position, PlacementPose.rotation);
    }

    public void PlaceWetSoil() {
        Destroy(SoilObject);
        SoilObject = Instantiate(wetSoil, PlacementPose.position, PlacementPose.rotation);
    }

    public void PlaceNormalSoil() {
        Destroy(SoilObject);
        SoilObject = Instantiate(normalSoil, PlacementPose.position, PlacementPose.rotation);
    }

    public void DestroyPlantObject() {
        Destroy(PlantObject);
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            PlacementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}