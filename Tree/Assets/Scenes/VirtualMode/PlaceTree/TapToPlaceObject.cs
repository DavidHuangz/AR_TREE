using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;

public class TapToPlaceObject : MonoBehaviour
{
    public GameObject seedling;
    public GameObject sapling;
    public GameObject tree;
    public GameObject field;

    private int stage;
    private float startTime, endTime;

    public GameObject placementIndicator;
    private GameObject spawnedObject;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    void Start()
    {
        startTime = 0f;
        endTime = 0f;
        stage = 0;
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (CheckForLongPress())
        {
            PlaceObject();
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
    switch (stage)
    {
        case 1:
            spawnedObject = Instantiate(seedling, PlacementPose.position, PlacementPose.rotation);
            break;

        case 2:
            spawnedObject = Instantiate(sapling, PlacementPose.position, PlacementPose.rotation);
            break;

        case 3:
            spawnedObject = Instantiate(tree, PlacementPose.position, PlacementPose.rotation);
            break;

        case 4:
            spawnedObject = Instantiate(field, PlacementPose.position, PlacementPose.rotation);
            break;
    
        default:
            break;
    }
        stage++;

    }

    public void DestroyObject() {
        Destroy(spawnedObject);
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