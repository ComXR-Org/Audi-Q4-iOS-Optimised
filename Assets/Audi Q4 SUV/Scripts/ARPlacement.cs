using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour
{

    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    public Camera arCamera;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    //public Text fpsText;
    //public float deltaTime;

    void Start()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
       
    }

    // need to update placement indicator, placement pose and spawn 
    void Update()
    {
        if (!arObjectToSpawn.activeInHierarchy && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
            //placementIndicator.gameObject.SetActive(false);
        }


        UpdatePlacementPose();
        UpdatePlacementIndicator();

        /*deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "FPS " + Mathf.Ceil(fps).ToString();*/


    }
    void UpdatePlacementIndicator()
    {
        if (!arObjectToSpawn.gameObject.activeInHierarchy && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = arCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }
    }

    void ARPlaceObject()
    {

        //GameObject g = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
        //spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
        
        arObjectToSpawn.gameObject.SetActive(true);
        arObjectToSpawn.transform.position = PlacementPose.position;
        arObjectToSpawn.transform.rotation = PlacementPose.rotation;
        
    }
    public void ResetScene()
    {
        // Reload the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }



}

